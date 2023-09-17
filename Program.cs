using System;
using System.Collections.Generic;

namespace Storage
{
    class Program
    {
        static void Main(string[] args)
        {
            Warehouse warehouse = new Warehouse();
            Product product = new Product();          
            Menu menu = new Menu(warehouse, product);

            menu.ListMenu();

            while (menu.action != 0)   //Ноль - выход из программы
                menu.MenuSelection(warehouse, product);  
        }
    }
}
