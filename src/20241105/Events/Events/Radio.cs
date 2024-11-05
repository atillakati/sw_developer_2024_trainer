using System;

namespace Events
{
    public delegate void RadioPowerStateChangedHandler(Radio radio);

    public class PowerStateChangedEventArgs : EventArgs
    {
        public RadioState NewState { get; set; }
    }


    public class Radio
    {
        private string _senderName;
        private double _frequency;
        private RadioState _state;

        public event EventHandler<PowerStateChangedEventArgs> PowerStateChanged;

        public Radio()
        {
            _senderName = "NoName";
            _frequency = 86.5;
            _state = RadioState.Off;
        }

        public RadioState State
        {
            get { return _state; }
        }

        public double Frequency
        {
            get { return _frequency; }
            set { _frequency = value; }
        }

        public string SenderName
        {
            get { return _senderName; }
            set { _senderName = value; }
        }

        public bool SetPowerState(RadioState newState)
        {
            if (_state == RadioState.Defective)
            {
                return false;
            }

            _state = newState;
            if(_state == RadioState.On)
            {
                //fire the event
                if (PowerStateChanged != null)
                {
                    PowerStateChanged(this, new PowerStateChangedEventArgs { NewState = _state });
                }
            }

            return true;
        }

        public void Play()
        {
            if (_state == RadioState.On)
            {
                Console.WriteLine($"Spiele Sender '{_senderName}' auf {_frequency} MHz...");
            }
        }

        public override string ToString()
        {
            return $"State: {_state} Sender: {_senderName} Frequenz: {_frequency} MHz";
        }
    }
}