using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ScreenFighter
{
    class ScreenFighter : IDisposable
    {
        GlobalKeyboardHook globalKeyboardHook;
        NotifyIcon notifyIcon;
        ScreenShooter screenShooter;
        Config config;

        public ScreenFighter()
        {
        }

        public void Initialize()
        {
            // Initialize configuration
            config = new Config();
            if (!config.Load())
                config.Save();

            // Initialize notifyIcon
            notifyIcon = new NotifyIcon();
            notifyIcon.Icon = Properties.Resources.icon;
            notifyIcon.Visible = true;
            notifyIcon.Text = Application.ProductName + " v" + Application.ProductVersion;
            notifyIcon.MouseClick += new MouseEventHandler(notifyIcon_MouseClick);
            //notifyIcon.MouseDoubleClick += new MouseEventHandler(notifyIcon_MouseDoubleClick);

            // Menu
            notifyIcon.ContextMenu = new ContextMenu();
            notifyIcon.ContextMenu.MenuItems.Add("Settings", new EventHandler(notifyIcon_Settings));
            notifyIcon.ContextMenu.MenuItems.Add("Exit", new EventHandler(notifyIcon_Exit));

            // GlobalKeyboardHook
            globalKeyboardHook = new GlobalKeyboardHook();
            globalKeyboardHook.HookedKeys.Add(Keys.PrintScreen);
            globalKeyboardHook.KeyDown += new KeyEventHandler(globalKeyboardHook_KeyDown);

            // ScreenShooter
            screenShooter = new ScreenShooter(config);
        }

        void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                screenShooter.SaveFullScreenShot();
            }
        }

        void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
        }

        void notifyIcon_Settings(object sender, EventArgs e)
        {
            SettingsForm form = new SettingsForm(config);
            DialogResult d = form.ShowDialog();
            if (d == DialogResult.OK)
            {
                config.Save();
            }
        }

        void notifyIcon_Exit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        void globalKeyboardHook_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.PrintScreen)
            {
                screenShooter.SaveFullScreenShot();
                e.Handled = true;
            }
        }

        public void Dispose()
        {
            notifyIcon.Dispose();
            globalKeyboardHook.Dispose();
        }
    }
}
