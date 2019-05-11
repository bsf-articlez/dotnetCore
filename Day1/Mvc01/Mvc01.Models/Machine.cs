using System;

namespace Mvc01.Models
{
    public class Machine
    {
        // backing fields => field use with property.
        private decimal _totalAmount = 0;
        private bool _isOn = false;
        private bool _isLidOpen = false;

        //public Machine() : this(0)
        //{

        //}
        public Machine(int id)
        {
            Id = id;
        }
        public int Id { get; set; }

        public decimal TotalAmount => _totalAmount;
        public bool IsOn => _isOn;
        public bool IsLidOpen => _isLidOpen;

        public void TogglePower()
        {
            if (_isOn) TurnOff();
            else TurnOn();
        }
        public void OpenLid()
        {
            if (_isOn) return;

            _isLidOpen = true;
        }

        public void CloseLid()
        {
            _isLidOpen = false;
        }

        private void TurnOn()
        {
            if (_isLidOpen) return;

            _isOn = true;
        }

        private void TurnOff()
        {
            _isOn = false;

            CancelBuying();
        }

        public void ToggleLid()
        {
            if (_isLidOpen) CloseLid();
            else OpenLid();
        }

        public void AcceptsCoin(decimal amount)
        {
            if (!_isOn) return;

            _totalAmount += amount;
        }

        public void CancelBuying()
        {
            _totalAmount = 0m;
        }
    }
}
