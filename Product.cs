using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage
{
    public class Product
    {          
        string name; //название
        public string Name 
        { 
            get => name != null ? 
                name.ToLower() : "Не задано";
            set => name = value.ToLower();     
        }
        string description; //описание
        public string Description
        {
            get => description != null ?
                description : "Не задано"; 

            set => description = value;
        }
        decimal price; //цена
        public decimal Price
        { 
            get => price;
            set
            {
                if (value < 0)
                    Console.WriteLine
                        ("Цена не может быть отрицательной");
                else
                    price = value;
            }
        }

        uint quantity; //количество
        public uint Quantity 
        {
            get => quantity;
            set
            {
                if (value < 0)
                    Console.WriteLine
                        ("Количество не может быть отрицательным");
                else
                    quantity = value;
            }
        }
        public void CreateProduct()
        {            
            Console.Write($"{"Наименование ", 20}");
            name = Console.ReadLine();

            Console.Write($"{"Описание ", 16}");
            description = Console.ReadLine();

            Console.Write($"{"Цена ", 12}");
            price = decimal.Parse(Console.ReadLine());

            Console.Write($"{"Количество ", 18}");
            quantity = uint.Parse(Console.ReadLine());           
        }
        public Product EditProduct() //редактировать товар
        {               
            Console.Write($"{"Количество товара: ", 26}");
            quantity = uint.Parse(Console.ReadLine());
            return this;
        }
        public override string ToString()
        {
            return ($"{"Наименование",19} {Name}\n"+
                $"{"Описание",15} {Description}\n"+
                $"{"Цена",11} {Price}\n {"Количество",16}"+
                $" {Quantity}\n");
        }       

    }
}
