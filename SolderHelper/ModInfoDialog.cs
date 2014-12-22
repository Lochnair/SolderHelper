using System;
using System.Windows.Forms;

namespace SolderHelper
{
    public partial class ModInfoDialog
    {
        public ModInfoDialog()
        {
            InitializeComponent();
        }

        public string Slug { get; set; }
        public string Version { get; set; }

        private void ModInfoDialog_Load(object sender, EventArgs e)
        {
            Text = Slug;
            txt_modSlug.Text = Slug;
            txt_version.Text = Version;
        }

        private void OK_Button_Click(Object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_modSlug.Text))
            {
                MessageBox.Show("Mod Slug can't be empty");
                return;
            }

            if (string.IsNullOrEmpty(txt_version.Text))
            {
                MessageBox.Show("Version can't be empty");
                return;
            }

            DialogResult = DialogResult.OK;
            Slug = txt_modSlug.Text;
            Version = txt_version.Text;
            Close();
        }
    }
}