using System;

namespace Project
{
    public class Candy
    {
        public string Name { get; private set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public Candy(String name, decimal Price, int Stock)//initialisation de mon objet/variable Candy
        {
            this.Name = name;//le mot cl� this remplace la variable de type Candy
            this.Price = Price;
            this.Stock = Stock;
        }

        public override string ToString()//fonction ToString() qui retourne la nom de la variable de type Candy
        {
            return this.Name;
        }
    }
}