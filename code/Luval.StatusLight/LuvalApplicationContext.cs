using Luval.StatusLight.Core;
using Luval.StatusLight.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luval.StatusLight
{
    public class LuvalApplicationContext : ApplicationContext
    {
        private NotifyIcon _trayIcon;
        private DeviceStatusManager _deviceStatusManager;
        
        /// <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="apiKey">The API key</param>
        /// <param name="interval">The interval</param>
        public LuvalApplicationContext(string apiKey, double interval)
        {
            _trayIcon = new NotifyIcon()
            {
                Icon = Resources.TrayIcon,
                ContextMenuStrip = new ContextMenuStrip()
                {
                    Items = {
                        new ToolStripMenuItem("Exit", null, Exit),
                        new ToolStripMenuItem("Turn On", null, TurnOn),
                        new ToolStripMenuItem("Turn Off", null, TurnOff)
                    }
                },
                Visible = true
            };
        }

        void Exit(object? sender, EventArgs e)
        {
            _trayIcon.Visible = false;
            Application.Exit();
        }

        void TurnOn(object? sender, EventArgs e)
        {
        }

        void TurnOff(object? sender, EventArgs e)
        {

        }
    }
}
