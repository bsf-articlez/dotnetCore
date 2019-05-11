namespace Mvc01.Models
{
    public class Machine
    {
        // backing fields => field use with property.
        private decimal _totalAmount = 0;
        private bool _isPowerOn = false;
        private bool _isOpened = false;
        private bool _isOn = false;
        private bool _isLidOpen = false;
        
        public decimal TotalAmount => _totalAmount;
        public bool IsPowerOn => _isPowerOn;
        public bool IsOpened => _isOpened;
        public bool IsOn => _isOn;
        public bool _ILidOpen => _isLidOpen;

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

        public void AcceptsCoin(decimal amount)
        {
            _totalAmount += amount;
        }

        public void ResetAmount()
        {
            _totalAmount = 0;
        }

        public void PowerOn()
        {
            _isPowerOn = true;
        }

        public void PowerOff()
        {
            _isPowerOn = false;
        }
        public void Open()
        {
            _isOpened = true;
        }

        public void Close()
        {
            _isOpened = false;
        }

        public void CancelBuying()
        {
            _totalAmount = 0m;
        }
    }
}
