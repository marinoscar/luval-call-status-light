using Microsoft.Win32;
using System.Timers;

namespace Luval.StatusLight.Core
{
    /// <summary>
    /// Provides the methods to detect is the camera or mic are in use
    /// </summary>
    public class DeviceStatusManager : IDisposable, IDeviceStatusManager
    {
        #region Variable Declaration

        private System.Timers.Timer? _timer;
        private DeviceStatusParams _params;
        private bool _cameraStatus;
        private bool _micStatus;

        #endregion

        /// <inheritdoc/>
        public event EventHandler<DeviceStatusEventArgs> DeviceStatusChanged;
        /// <inheritdoc/>
        public event EventHandler<CameraStatusEventArgs> CameraStatusChanged;
        /// <inheritdoc/>
        public event EventHandler<MicrophoneStatusEventArgs> MicrophoneStatusChanged;

        #region Static Methods

        /// <summary>
        /// Detects if the camera is in use
        /// </summary>
        /// <returns>True if the camera is in use, otherwise false</returns>
        public static bool IsCameraInUse()
        {
            return IsDeviceInUse(@"SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\webcam\NonPackaged");
        }

        /// <summary>
        /// Detects if the microphone is in use
        /// </summary>
        /// <returns>True if the microphone is in use, otherwise false</returns>
        public static bool IsMicInUse()
        {
            return IsDeviceInUse(@"SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\microphone\NonPackaged");
        }

        private static bool IsDeviceInUse(string regKey)
        {
            using (var key = Registry.CurrentUser.OpenSubKey(regKey))
            {
                foreach (var subKeyName in key.GetSubKeyNames())
                {
                    using (var subKey = key.OpenSubKey(subKeyName))
                    {
                        if (subKey.GetValueNames().Contains("LastUsedTimeStop"))
                        {
                            var endTime = subKey.GetValue("LastUsedTimeStop") is long ? (long)subKey.GetValue("LastUsedTimeStop") : -1;
                            if (endTime <= 0)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        #endregion


        /// <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="options">The options for the class</param>
        public DeviceStatusManager(DeviceStatusParams options)
        {
            _params = options;
            _cameraStatus = options.InitialStatus;
            _micStatus = options.InitialStatus;
        }

        /// <inheritdoc/>
        public void StartMonitoring()
        {
            _timer = new System.Timers.Timer(_params.TestIntervalInMs);
            _timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            _timer.Enabled = true;
            _timer.Start();
        }

        /// <inheritdoc/>
        public void StopMonitoring()
        {
            if (_timer == null) return;
            _timer.Enabled = false;
            _timer.Stop();
            _timer.Dispose();
            _timer = null;
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            StopMonitoring();
        }


        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            var cam = DeviceStatusManager.IsCameraInUse();
            var mic = DeviceStatusManager.IsMicInUse();

            if (cam != _cameraStatus || mic != _micStatus)
            {
                var handler = DeviceStatusChanged;
                if (handler != null) handler(this, new DeviceStatusEventArgs(cam, mic));
            }
            if (cam != _cameraStatus)
            {
                var handler = CameraStatusChanged;
                if (handler != null) handler(this, new CameraStatusEventArgs(cam));
            }
            if (mic != _micStatus)
            {
                var handler = MicrophoneStatusChanged;
                if (handler != null) handler(this, new MicrophoneStatusEventArgs(mic));
            }

            _cameraStatus = cam;
            _micStatus = mic;
        }
    }



}