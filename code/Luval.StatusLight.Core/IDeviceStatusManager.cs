
namespace Luval.StatusLight.Core
{
    /// <summary>
    /// Provides an implementation to monitor the status of the devices
    /// </summary>
    public interface IDeviceStatusManager
    {
        /// <summary>
        /// Indetifies when the camera status change from being in use or not
        /// </summary>
        event EventHandler<CameraStatusEventArgs> CameraStatusChanged;
        /// <summary>
        /// Indetifies when the device status change from being in use or not
        /// </summary>
        event EventHandler<DeviceStatusEventArgs> DeviceStatusChanged;
        /// <summary>
        /// Indetifies when the microphone status change from being in use or not
        /// </summary>
        event EventHandler<MicrophoneStatusEventArgs> MicrophoneStatusChanged;

        /// <inheritdoc/>
        void Dispose();

        /// <summary>
        /// Start monitoring for changes on the device status
        /// </summary>
        void StartMonitoring();

        /// <summary>
        /// Stops monitoring the devices
        /// </summary>
        void StopMonitoring();
    }
}