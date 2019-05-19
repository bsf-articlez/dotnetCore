﻿using System;
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
            MessageCoinNotAccept = "";
        }

        public Machine(int id, List<Coin> coins)
        {
            Id = id;
            Coins = coins;
            MessageCoinNotAccept = "";
        }

        public int Id { get; set; }
        public List<Coin> Coins { get; set; }
        public string MessageCoinNotAccept { get; set; }

        public decimal TotalAmount => _totalAmount;
        public bool IsOn => _isOn;
        public bool IsLidOpen => _isLidOpen;

        public void TogglePower(decimal[] coinIsAccepts)
        {
            if (_isOn)
            {
                TurnOff();
            }
            else
            {
                SettingCoinsAccept(coinIsAccepts);
                TurnOn();
            }
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

            var CoinNotAccepts = Coins.Where(x => !x.IsAccept).Select(x => x.Amount);
            if (CoinNotAccepts.Contains(amount))
            {
                MessageCoinNotAccept = amount + " Bath coin cannot be used.";
                return;
            }

            _totalAmount += amount;
        }

        public void CancelBuying()
        {
            _totalAmount = 0m;
        }

        private void SettingCoinsAccept(decimal[] coinIsAccepts)
        {
            if (_isLidOpen) return;
            if (_isOn) return;

            foreach (var item in Coins)
            {
                item.IsAccept = coinIsAccepts.Contains(item.Amount);
            }
        }

        public static Coin CreateCoin(decimal amount, bool isAccept)
        {
            return new Coin
            {
                Amount = amount,
                IsAccept = isAccept
            };
        }
    }
}
