using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ScreenFighter
{
    class ScreenShooter
    {
        private Config config;

        public ScreenShooter(Config config)
        {
            this.config = config;
        }

        public void SaveFullScreenShot()
        {
            Rectangle bounds = Screen.GetBounds(Point.Empty);
            using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
                }
                try
                {
                    bitmap.Save(
                        generateFullFileName(config.FolderPathFullScreenShot),
                        config.ImageFormat);
                }
                catch (Exception)
                {
                    MessageBox.Show("Invalid path.");
                }
            }
        }

        private string generateFullFileName(string folderPath)
        {
            return Path.Combine(folderPath,
                DateTime.Now.ToString("yyyyMMdd-HHmmss-fff") +
                "." +
                config.ImageFormat.ToString().ToLower());
        }
    }
}
