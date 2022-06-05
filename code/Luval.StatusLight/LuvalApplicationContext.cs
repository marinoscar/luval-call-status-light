using Luval.StatusLight.Core;
using Luval.StatusLight.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luval.StatusLight
{
    /// <summary>
    /// Application context for the tray application
    /// </summary>
    public class LuvalApplicationContext : ApplicationContext
    {
        private NotifyIcon _trayIcon;
        private IStatusController _statusController;
        
        /// <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="statusController">The implementation for the <see cref="IStatusController"/></param>
        public LuvalApplicationContext(IStatusController statusController)
        {
            _statusController = statusController;   
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
            _statusController.LightController.TurnOn();
        }

        void TurnOff(object? sender, EventArgs e)
        {
            _statusController.LightController.TurnOff();
        }

        /// <summary>
        /// Starts the monitoring
        /// </summary>
        public void Start()
        {
            _statusController.Start();
        }
    }
}
