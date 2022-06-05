using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luval.StatusLight.Core
{
    /// <summary>
    /// Provides the methods to control the status light based on the device events
    /// </summary>
    public class StatusController : IDisposable, IStatusController
    {
        /// <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="deviceStatusManager">The instance for the <see cref="IDeviceStatusManager"/></param>
        /// <param name="lightController">The instance for the <see cref="ILightController"/></param>
        /// <param name="logger">The instance for the <see cref="ILogger"/></param>
        public StatusController(IDeviceStatusManager deviceStatusManager, ILightController lightController, ILogger logger)
        {
            Logger = logger;
            DeviceStatusManager = deviceStatusManager;
            LightController = lightController;
        }

        /// <inheritdoc/>
        public void Start()
        {
            DeviceStatusManager.DeviceStatusChanged += DeviceStatusManager_DeviceStatusChanged;
            DeviceStatusManager.StartMonitoring();
        }

        private void DeviceStatusManager_DeviceStatusChanged(object? sender, DeviceStatusEventArgs e)
        {
            Logger.LogInformation("Camera Status: {0}   Microphone Status: {1}", e.CameraInUse, e.MicrophoneInUse);
            try
            {
                if (e.CameraInUse || e.MicrophoneInUse) LightController.TurnOn();
                else LightController.TurnOff();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Failed to connect with light");
            }
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            DeviceStatusManager?.StopMonitoring();
            DeviceStatusManager?.Dispose();
            DeviceStatusManager = null;
            LightController = null;
        }

        /// <inheritdoc/>
        public IDeviceStatusManager DeviceStatusManager { get; private set; }

        /// <inheritdoc/>
        public ILightController LightController { get; private set; }

        /// <inheritdoc/>
        public ILogger Logger { get; private set; }

    }
}
