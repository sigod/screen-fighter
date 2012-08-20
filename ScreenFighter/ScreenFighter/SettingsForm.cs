using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ScreenFighter
{
    partial class SettingsForm : Form
    {
        Config config;

        public SettingsForm(Config config)
        {
            InitializeComponent();
            this.config = config;
            Icon = Properties.Resources.icon;
            Text = Application.ProductName + ": Settings";
            textBoxFull.Text = config.FolderPathFullScreenShot;
            
            comboBoxImageFormat.Items.Add(ImageFormat.Png);
            comboBoxImageFormat.Items.Add(ImageFormat.Jpeg);
            comboBoxImageFormat.Items.Add(ImageFormat.Gif);
            comboBoxImageFormat.SelectedItem = config.ImageFormat;
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            // Apply changes to config
            config.FolderPathFullScreenShot = textBoxFull.Text;
            config.ImageFormat = (ImageFormat)comboBoxImageFormat.SelectedItem;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            // Just exit
        }

        private void buttonFull_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = config.FolderPathFullScreenShot;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBoxFull.Text = folderBrowserDialog1.SelectedPath;
            }
        }
    }
}
