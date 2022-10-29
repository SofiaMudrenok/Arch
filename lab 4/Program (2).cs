using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{   
    internal class Program
    {
        public class Product
        {
            public string name { get; set; }
            public float price { get; set; }

            public Product(string name, float price)
            {
                this.name = name;
                this.price = price;
            }
            public override string ToString()
            {
                return $"{name} with price: {price};\n";
            }
        }
        public class Basket
        {
            private List<Product> _state = new List<Product>();

            public Basket() { }

            public Basket Add(Product product)
            {
                _state.Add(product);
                return this;
            }

            public void ShowProducts()
            {
                foreach (Product product in _state)
                {
                    Console.WriteLine(product);
                }
            }

            public IMemento Save()
            {
                return new ConcreteMemento(this._state);
            }

            public void Restore(IMemento memento)
            {
                if (!(memento is ConcreteMemento))
                {
                    throw new Exception("Unknown memento class " + memento.ToString());
                }

                this._state = memento.GetState();
                //Console.Write($"Originator: My state has changed to: {_state}");
            }

            public override string ToString()
            {   
                string result = string.Empty;
                foreach (Product product in _state)
                {
                    result += product.ToString();
                }
                return result;
            }
        }

        public interface IMemento
        {
            List<Product> GetState();
        }

        public class ConcreteMemento : IMemento
        {
            private List<Product> _state;

            public ConcreteMemento(List<Product> state)
            {
                _state = state;
            }

            public List<Product> GetState()
            {
                return this._state;
            }
        }

        public class Caretaker
        {
            private List<IMemento> _mementos = new List<IMemento>();

            private Basket _originator = null;

            public Caretaker(Basket originator)
            {
                this._originator = originator;
            }

            public void Backup()
            {
                //Console.WriteLine("Caretaker: Saving Originator's state...");
                this._mementos.Add(this._originator.Save());
            }

            public void Undo()
            {
                if (this._mementos.Count == 0)
                {
                    //Console.WriteLine("Caretaker: Tere is no history to undo");
                    return;
                }

                var memento = this._mementos[this._mementos.Count - 1];
                this._mementos.Remove(memento);

                this._originator.Restore(memento);
            }
        }

        static void Main(string[] args)
        {
            Basket basket = new Basket();
            Caretaker caretaker = new Caretaker(basket);

            basket
                .Add(new Product("Apple", 5))
                .Add(new Product("Banana", 10))
                .Add(new Product("Potato", 7));
            caretaker.Backup();

            basket.Add(new Product("Orange", 15));
            caretaker.Backup();

            basket.Add(new Product("Watermelon", 12));
            caretaker.Backup();

            caretaker.Undo();

            Console.WriteLine(basket);
        }
    }
}
