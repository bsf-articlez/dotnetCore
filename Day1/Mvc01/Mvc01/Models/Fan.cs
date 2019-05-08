namespace Mvc01.Models
{
    public class Fan
    {
        private int _number;
        private bool _isShook;
        private bool _isWorking;
        private bool _isPlugin;

        public int Number => _number;
        public bool IsShook => _isShook;
        public bool IsWorking => _isWorking;
        public bool IsPlugin => _isPlugin;

        public void AcceptNumber(int number)
        {
            _number = number;
        }

        public void AcceptPush()
        {
            _isShook = true;
        }

        public void AcceptPull()
        {
            _isShook = false;
        }

        public void PowerOn()
        {
            _isWorking = true;
        }

        public void PowerOff()
        {
            _isWorking = false;
        }

        public void Plugin()
        {
            _isPlugin = true;
        }

        public void UnPlug()
        {
            _isPlugin = false;
        }
    }
}
