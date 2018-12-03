using System;

namespace classwork
{

    public class Item {

        public string Name {
            get;
        }

        public double Price {
            get;
        }

        public int Quantity {
            get;
        }

        public Item() {}

        public Item(string Name, double Price, int Quantity) {
            this.Name = Name;
            this.Price = Price;
            this.Quantity = Quantity;
        }

        public override string ToString()
        {
            return $"{Name} Costs {Price} and  Quantity is{Quantity}";
        }
    }

    public class ShoppingCart {
        private int _itemCount;
        private double _totalPrice;
        private int _capacity;
        private Item[] _cart;

        public ShoppingCart() {
            _itemCount = 0;
            _capacity = 5;
            Array.Resize(ref _cart, _capacity);
        }

        public void AddToCart(Item a) {
            if (_itemCount == _capacity) {
                IncreaseSize();
            }
            _cart[_itemCount++] = a;
            _totalPrice += a.Price * a.Quantity;
        }

        private void IncreaseSize() {
            Array.Resize(ref _cart, _capacity + 3);
            _capacity += 3;
        }


    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
