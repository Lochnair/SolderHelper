using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Ionic.Zip;
using Newtonsoft.Json;
using System.Net;
using System.Text.RegularExpressions;

namespace SolderHelper
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

#if DEBUG
            var desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            txt_mods.Text = desktop + Path.DirectorySeparatorChar + "SolderNew";
            txt_output.Text = desktop + Path.DirectorySeparatorChar + "Solder"; 
#endif
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
                    var mcModInfo = GetMCModInfo(path);

                    dialog.Slug = mcModInfo.Name.GenerateSlug();
                    dialog.Version = mcModInfo.FullVersion;
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

        private MCModInfo GetMCModInfo(string zipPath)
        {
            using (ZipFile zip = new ZipFile(zipPath))
            {
                if (!zip.ContainsEntry("mcmod.info"))
                {
                    throw new Exception("This zip file does not contain a mcmod.info entry");
                }

                try
                {
                    Stream entryStream = zip["mcmod.info"].OpenReader();
                    string json = new StreamReader(entryStream).ReadToEnd();
                    return JsonConvert.DeserializeObject<MCModInfo>(json);
                }
                catch (JsonSerializationException)
                {
                    Stream entryStream = zip["mcmod.info"].OpenReader();
                    string json = new StreamReader(entryStream).ReadToEnd();
                    return JsonConvert.DeserializeObject<MCModInfo[]>(json)[0];
                }
                
            }
        }

        private class MCModInfo
        {
            public string[] Authors { get; set; }
            public string Name { get; set; }
            public string FullVersion
            {
                get
                {
                    if (String.IsNullOrEmpty(MCVersion))
                    {
                        if (String.IsNullOrEmpty(Version))
                        {
                            return null;
                        }

                        return Version;
                    }

                    if (Version.StartsWith(MCVersion))
                    {
                        return Version;
                    }

                    return MCVersion + "-" + Version;
                }
            }
            public string MCVersion { get; set; }
            public string Version { get; set; }
            public Uri url { get; set; }
        }

        private class MCVersion
        {
            public string Version { get; set; }
            public string MD5 { get; set; }
        }   
    }
}