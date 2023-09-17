using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Storage
{   
    class Warehouse 
    {
        List<Product> products;  
        public List <Product> Products        
        { 
            get => products; 
            set => products = value; 
        }

        readonly string path = "./ListProduct.xml";       
        XmlSerializer xmlSerialize;
        public Warehouse()
        {
            products = new List<Product>();
            xmlSerialize = new XmlSerializer(typeof(List<Product>));

            if(File.Exists(path))
                LoadFile();
        }
        public List<Product> AddProduct(Product product)
        {
            product = new Product();
            product.CreateProduct();
            products.Add(product);                    
            return products;
        }
        public Product GetProductByName(string name)
        {
            name.ToLower();
            return products.FirstOrDefault(s => s.Name == name.ToLower());      
        }
        public void DeleteProduct(Product product)
        {
            products.Remove(product);
        }
        public void SaveListOfFile()
        { 
            using (var fs = File.Open(path, FileMode.OpenOrCreate,
                FileAccess.Write))          
                xmlSerialize.Serialize(fs, products); //Сериализация            
        }  
        void LoadFile()
        {            
            using (var fs = File.Open(path, FileMode.OpenOrCreate,
                FileAccess.Read))          
                products = xmlSerialize.Deserialize(fs) as List<Product>; //Десериализация 
        }
        public IEnumerator GetEnumerator() => products.GetEnumerator();
        public void print(List<Product> prod)
        {           
            foreach (var item in prod)
                Console.WriteLine($"{item}\n");          
        }
        public List<Product> GetProductsWithLowQuantity(uint threshold)
        {
            return products.FindAll(s => s.Quantity <= threshold);              
        }
    }
}
