using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace Storage
{
    enum Action
    {
        Exit,
        Add,
        Edit,
        Print,
        Delete,
        Save,
        Select        
    }
    class Menu
    {
        Warehouse warehouse;
        Product product;
        public Action action = Action.Add;              
        public Menu(Warehouse warehouse, Product product)
        {
            this.warehouse = warehouse;
            this.product = product;                     
        }
        public void ListMenu()
        {            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n{"СКЛАД",22}");   //отступы от края
            Console.WriteLine
                ($"{"1.Добавить товар", 23}\n" +
                 $"{ "2.Редактировать количество товара", 40}\n" +
                 $"{"3.Просмотреть список товаров", 35}\n" +
                 $"{"4.Удалить товар", 22}\n" +
                 $"{"5.Сохранить", 18}\n" +
                 $"{"6.Отбор товаров по количеству.", 37}\n" +
                 $"{"0.Выйти из программы.", 28}");                 
            Console.WriteLine("--------------------------------------------\n");
            Console.ForegroundColor = ConsoleColor.White;
        }               
        public void MenuSelection(Warehouse warehouse, Product product)
        {           
            Console.Write($"{"Выберите пункт меню ", 27}");            

            int i;            
            string input = Console.ReadLine();
            
            if (!Int32.TryParse(input, out i))
                return;

            action = (Action)i;
            switch (action)
            {
                case Action.Add:
                    Console.Clear();
                    ListMenu();
                    Console.WriteLine($"{"~Создание",21}~");
                    Console.WriteLine($"{"Товар",20}");
                    warehouse.print(warehouse.Products);
                    warehouse.AddProduct(product);
                    Console.WriteLine("--------------------------------------------\n");
                    break;
                case Action.Edit:
                    Console.Clear();                   
                    ListMenu();
                    Console.WriteLine
                        ($"{"~Редактирование количества",32}~\n");
                    Console.Write($"{"Выберите товар: ",23}");
                    product = warehouse.GetProductByName
                        (product.Name = Console.ReadLine());
                    product.EditProduct();                   
                    break;
                case Action.Print:
                    Console.Clear();
                    ListMenu();
                    Console.WriteLine($"{"~Просмотр списка",26}~\n");
                    warehouse.print(warehouse.Products);
                    MenuSelection(warehouse, product);
                    break;
                case Action.Delete:
                    Console.Clear();
                    ListMenu();
                    Console.WriteLine($"{"~Удаление",17}~\n");
                    Console.Write($"{"Выберите товар: ",23}");
                    product = warehouse.GetProductByName
                        (product.Name = Console.ReadLine());
                    warehouse.DeleteProduct(product);
                    Console.WriteLine($"{"Товар удален...",22}");
                    break; 
                case Action.Save:
                    warehouse.SaveListOfFile();
                    Console.WriteLine($"{"Сохранено...",19}");
                    break;
                case Action.Select:
                    Console.Clear();
                    ListMenu();
                    Console.WriteLine($"{"~Отбор по количеству",30}~\n");
                    Console.Write($"{"Укажите пороговое значение: ",35}");                   
                    List<Product>list = warehouse.GetProductsWithLowQuantity
                        (product.Quantity = uint.Parse(Console.ReadLine()));
                    warehouse.print(list);                 
                    break;  
                case Action.Exit:
                    Console.WriteLine($"\n{"Завершение сеанса...",27}");
                    break;
                default:
                    Console.Clear();
                    ListMenu();
                    Console.WriteLine($"{"Ошибка ввода...\n",23}");                                  
                    break;
            }
            
        }
    }
}
