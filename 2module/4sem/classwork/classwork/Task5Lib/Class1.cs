using System;

namespace Task5Lib
{
    public abstract class UnitsBase {
        protected int _unitCode;
        protected double _price;
        protected string _name;

        public int UnitCode {
            get {
                return _unitCode;
            } protected set {
                _unitCode = value;
            }
        }

        public double Price {
            get { return _price; }
            protected set { _price = value; }
        }

        public string Name {
            get { return _name; }
            protected set { _name = value; }
        }

        public virtual double Dicsount(int percentage) {
            return _price * (100 - percentage) / 100;
        }
        protected UnitsBase(int code, double pr, string name) {
            _unitCode = code;
            _price = pr;
            _name = name;
        }
        protected UnitsBase() {
            _unitCode = 0;
            _price = 0;
            _name = "";
        }
        public override string ToString()
        {
            return $"UnitCode:{UnitCode}, Price:{Price.ToString("F3")}, Name:{Name}";
        }
    }

    public class Book : UnitsBase {
        private int _amountOfPages;
        private bool _isBestSeller;

        public int AmountOfPages
        {
            get { return _amountOfPages; }
            private set { _amountOfPages = value; }
        }
        public bool IsBestSeller {
            get { return _isBestSeller; }
            private set { _isBestSeller = value; }
        }

        public Book() : base() {
            _amountOfPages = 0;
            _isBestSeller = false;
        }

        public Book(int code, double pr, string name, int pages, bool isBestSeller) : base(code,pr, name) {
            _amountOfPages = pages;
            _isBestSeller = isBestSeller;
        }

        public override string ToString()
        {
            return $"UnitCode:{UnitCode}, Price:{Price.ToString("F3")}, Name:{Name}, Pages:{AmountOfPages}, Bestseller:{IsBestSeller}";
        }
    }

    public class Cards : UnitsBase {
        private string _message;

        public string Message {
            get { return _message; }
            private set { _message = value; }
        }

        public Cards() :base() {
            _message = "";
        }

        public Cards(int code, double pr, string name, string message) : base(code,pr,name) {
            _message = message;
        }

        public override string ToString()
        {
            return $"UnitCode:{UnitCode}, Price:{Price.ToString("F3")}, Name:{Name}, message:{Message}";
        }
    }

    public class CD : UnitsBase {
        private int _playingTime;

        public int PlayingTime {
            get { return _playingTime; }
            private set { _playingTime = value; }
        }

        public CD() : base() {
            _playingTime = 0;
        }

        public CD(int code, string name, double price, int playTime) : base(code, price, name) {
            _playingTime = playTime;
        }

        public override string ToString()
        {
            return $"UnitCode:{UnitCode}, Price:{Price.ToString("F3")}, Name:{Name}, PlayTime:{PlayingTime}";
        }
    }
}
