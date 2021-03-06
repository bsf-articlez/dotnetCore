﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Mvc01.Models
{
    public class Machine
    {
        // backing fields => field use with property.
        private decimal _totalAmount = 0;
        private decimal _totalSellAmount = 0;
        private bool _isOn = false;
        private bool _isLidOpen = false;
        private decimal[] _acceptableCoins;

        //public Machine() : this(0)
        //{

        //}
        public Machine(int id) //, decimal[] acceptableCoins = null)
        {
            Id = id;
            //_acceptableCoins = acceptableCoins ?? new[] { 1m, 5m, 10m }; // type inference. // อนุมาณ
            _acceptableCoins = new[] { 1m, 5m, 10m }; // type inference. // อนุมาณ
            // left is null, return right.
        }

        public int Id { get; set; }
        public decimal TotalAmount { get => _totalAmount; private set => _totalAmount = value; }
        public bool IsOn { get => _isOn; private set => _isOn = value; }
        public bool IsLidOpen { get => _isLidOpen; private set => _isLidOpen = value; }
        public decimal[] AcceptableCoins { get => _acceptableCoins; private set => _acceptableCoins = value; }
        public virtual ICollection<Slot> Slots { get; set; } = new HashSet<Slot>();
        public decimal TotalSellAmount { get => _totalSellAmount; private set => _totalSellAmount = value; }

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
            _totalSellAmount = 0;
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
            if (!_isOn) throw new InvalidOperationException("Please turn on machine");
            if (!_acceptableCoins.Contains(amount))
                throw new ArgumentOutOfRangeException(nameof(amount), $"ตู้นี้ไม่รับเหรียญ {amount} บาท ✨");

            _totalAmount += amount;
        }

        public void CancelBuying()
        {
            _totalAmount = 0m;
        }

        public void AcceptBuying(decimal amount)
        {
            _totalSellAmount += amount;
        }

        public void IsSellable(Slot slot)
        {
            slot.SellAble = false;
        }

        public void ReduceProductQuantity(ICollection<Slot> slots, int slotId)
        {
            slots.Where(x => x.Id == slotId).SingleOrDefault().Quantity -= 1;
        }
    }
}
