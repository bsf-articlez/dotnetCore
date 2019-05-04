using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc01.Models
{
    public class Machine
    {
        // backing fields => field use with property.
        private decimal _totalAmount = 0;
        private bool _isPowerOn = false;
        private bool _isOpened = false;

        public decimal TotalAmount => _totalAmount;
        public bool IsPowerOn => _isPowerOn;
        public bool IsOpened => _isOpened;

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
    }
}
