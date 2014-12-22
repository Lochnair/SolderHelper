using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Ionic.Zip;

namespace SolderHelper
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void BrowseFolder(ref TextBox textBox)
        {
            var dialog = new FolderBrowserDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBox.Text = dialog.SelectedPath;
            }
        }

        private void btn_browseMods_Click(object sender, EventArgs e)
        {
            BrowseFolder(ref txt_mods);
        }

        private void btn_browseOutput_Click(object sender, EventArgs e)
        {
            BrowseFolder(ref txt_output);
        }

        private void btn_run_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_mods.Text) | !Directory.Exists(txt_mods.Text))
            {
                MessageBox.Show("Choose a mods folder first!");
                return;
            }

            if (string.IsNullOrEmpty(txt_output.Text) | !Directory.Exists(txt_output.Text))
            {
                MessageBox.Show("Choose a output folder first!");
                return;
            }

            var mods = GetFiles(txt_mods.Text, "*.jar|*.zip", SearchOption.TopDirectoryOnly);
            var output = txt_output.Text;

            foreach (var path in mods)
            {
                var fInfo = new FileInfo(path);
                var dialog = new ModInfoDialog();
                var name = fInfo.Name.Replace(fInfo.Extension, "").ToLower();

                try
                {
                    dynamic versionStart = name.LastIndexOf("-") + 1;
                    dialog.Slug = name.Substring(0, versionStart - 1);
                    dialog.Version = name.Substring(versionStart, name.Length - versionStart);
                }
                catch
                {
                    dialog.Slug = name;
                }

                dialog.ShowDialog();

                using (var zip = new ZipFile())
                {
                    var entry = zip.AddFile(path, "/mods/");
                    Directory.CreateDirectory(output + "\\" + dialog.Slug);
                    zip.AddDirectoryByName("/config");
                    zip.Save(output + "\\" + dialog.Slug + "\\" + dialog.Slug + "-" + dialog.Version + ".zip");
                }
            }
        }

        private string[] GetFiles(string directory, string searchPattern, SearchOption searchOption)
        {
            var searchPatterns = searchPattern.Split('|');
            var files = new List<string>();

            foreach (var pattern in searchPatterns)
            {
                files.AddRange(Directory.GetFiles(directory, pattern, searchOption));
            }

            files.Sort();

            return files.ToArray();
        }
    }
}