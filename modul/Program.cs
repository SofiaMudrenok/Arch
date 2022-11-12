using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ConsoleApp1
{
    interface IElixirFactory
    {
        string Create();
    }
    abstract class Elixir
    {
        public int defValue;

        public Elixir(int defValue)
        {
            this.defValue = defValue;
        }
    }

    interface IElixirFactory

    {
        IElixirFactory Create();
    }

    class FireElixir : IElixirFactory
    {

    }

    class WaterElix : FireElixir
    {

    }

    class GamePerson
    {
        public string name;
        public int hpCount;
        public int fireDefence;
        public int waterDefence;

        public GamePerson(string name, int hpCount, int fireDefence, int waterDefence)
        {
            this.name = name;
            this.hpCount = hpCount;
            this.fireDefence = 0;
            this.waterDefence = 0;
        }

        public void drinkElixir()
        {
        }
    }
    class FactoryFirstClass : IAbstractFactory
    {
        public IElixirFactory Create()
        {
            return new FireElixir();
        }

        public FireElixir CreateFire()
        {
            return new WaterElix();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}