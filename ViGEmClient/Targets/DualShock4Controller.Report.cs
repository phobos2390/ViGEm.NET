using Nefarius.ViGEm.Client.Targets.DualShock4;

namespace Nefarius.ViGEm.Client.Targets
{
    internal partial class DualShock4Controller
    {
        public void SetButtonState(DualShock4Button button, bool pressed)
        {
            switch (button)
            {
                case DualShock4SpecialButton specialButton:
                    if (pressed)
                        _nativeReport.bSpecial |= (byte)specialButton.Value;
                    else
                        _nativeReport.bSpecial &= (byte)~specialButton.Value;
                    break;
                case DualShock4Button normalButton:
                    if (pressed)
                        _nativeReport.wButtons |= (ushort)normalButton.Value;
                    else
                        _nativeReport.wButtons &= (ushort)~normalButton.Value;
                    break;
            }

            if (AutoSubmitReport)
                SubmitNativeReport(_nativeReport);
        }

        public void SetDPadDirection(DualShock4DPadDirection direction)
        {
            _nativeReport.wButtons &= unchecked((ushort)~0xF);
            _nativeReport.wButtons |= direction.Value;

            if (AutoSubmitReport)
                SubmitNativeReport(_nativeReport);
        }

        public void SetAxisValue(DualShock4Axis axis, byte value)
        {
            switch (axis.Name)
            {
                case "LeftThumbX":
                    _nativeReport.bThumbLX = value;
                    break;
                case "LeftThumbY":
                    _nativeReport.bThumbLY = value;
                    break;
                case "RightThumbX":
                    _nativeReport.bThumbRX = value;
                    break;
                case "RightThumbY":
                    _nativeReport.bThumbRY = value;
                    break;
            }

            if (AutoSubmitReport)
                SubmitNativeReport(_nativeReport);
        }

        public void SetIMUValue(DualShock4IMU axis, short value) {
            switch (axis.Name) {
                case "GyroX":
                    _nativeReport.wGyroX = value;
                    break;
                case "GyroY":
                    _nativeReport.wGyroY = value;
                    break;
                case "GyroZ":
                    _nativeReport.wGyroZ = value;
                    break;
                case "AccelX":
                    _nativeReport.wAccelX = value;
                    break;
                case "AccelY":
                    _nativeReport.wAccelY = value;
                    break;
                case "AccelZ":
                    _nativeReport.wAccelZ = value;
                    break;
            }

            if (AutoSubmitReport)
                SubmitNativeReport(_nativeReport);
        }

        public void SetIMUTimestamp(short ts) {
            _nativeReport.wTimestamp = ts;

            if (AutoSubmitReport)
                SubmitNativeReport(_nativeReport);
        }

        public void SetSliderValue(DualShock4Slider slider, byte value)
        {
            switch (slider.Name)
            {
                case "LeftTrigger":
                    _nativeReport.bTriggerL = value;
                    break;
                case "RightTrigger":
                    _nativeReport.bTriggerR = value;
                    break;
            }

            if (AutoSubmitReport)
                SubmitNativeReport(_nativeReport);
        }
    }
}
