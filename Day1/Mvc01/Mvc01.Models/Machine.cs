using System;
using System.Collections.Generic;
using System.Linq;

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
        public List<Coin> Coins { get; set; }

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

        public void AcceptsCoin(decimal amount, ref string messageCoinNotAccept)
        {
            if (!_isOn) return;

            var CoinNotAccepts = Coins.Where(x => !x.IsAccept).Select(x => x.Number).ToList();
            if (CoinNotAccepts.Contains(amount))
            {
                messageCoinNotAccept = amount.ToString() + " Bath coin cannot be used.";
                return;
            }

            _totalAmount += amount;
        }

        public void CancelBuying()
        {
            _totalAmount = 0m;
        }

        public void SettingCoinsAccept(decimal[] isAccept)
        {
            if (IsOn) return;

            List<Coin> coinsNew = new List<Coin>();
            foreach (var item in Coins)
            {
                if (isAccept.Contains(item.Number)) coinsNew.Add(new Coin { Number = item.Number, IsAccept = true });
                else coinsNew.Add(new Coin { Number = item.Number, IsAccept = false });
            }

            Coins = coinsNew;
        }
    }
}
