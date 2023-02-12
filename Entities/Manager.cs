using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;

namespace StorageManager {
    class Manager {
        public void StartToManager (){
            string rootPath = @"C:\Users\Felipe Hunter\Programação\Programs C#\Storage_Manager";
            List<Product> productInfo = new List<Product>();

            try {

                if (CheckForItems(rootPath) != 0){
                    System.Console.WriteLine("1 - Load Current Products\n2 - Create a new list");
                    int answer = int.Parse(Console.ReadLine());

                    if (answer == 1){
                        LoadTextFromFile (rootPath, productInfo);
                    }else {
                        CreateFolderAndSummary (rootPath);
                        WriteFile(productInfo, rootPath);
                    }
                }         
            }
            catch (IOException e){
                System.Console.WriteLine("Error: " + e.Message);
            }
        }

        void CreateFolderAndSummary (string path){
            // Verificar se pasta já foi criada, se não criar uma
            if (!Directory.Exists(path+"/out")){
                Directory.CreateDirectory(path+"/out");
            }
            // Verificar o arquivo Summary.csv
            if (!File.Exists(path+"/out/Summary.csv")){
                File.Create(path+"/out/Summary.csv");
            }
            /* / Create a saving file
            if (!File.Exists(path+"/out/SaveData.csv")){
                File.Create(path+"/out/SaveData.csv");
            } */
        }

        void WriteFile (List<Product> productInfo, string rootPath){
            System.Console.WriteLine();
            System.Console.Write("How many products do you want to register? ");
                int n = int.Parse(Console.ReadLine());
                for (int i=0; i < n; i++){
                    System.Console.Write("Product Name: ");
                    string name = Console.ReadLine();
                    System.Console.Write("Product Price: ");
                    double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    System.Console.Write("Product Quantity: ");
                    int quantity = int.Parse(Console.ReadLine());

                    productInfo.Add (new Product(name, price, quantity));
                }

                foreach (Product p in productInfo){
                    using (StreamWriter sw = File.AppendText(rootPath+"/out/Summary.csv")){
                        sw.WriteLine(p);
                    }
                }

                // Save quantity of current products created
                using (StreamWriter sw = File.CreateText(rootPath+"/out/SaveData.csv")){
                    sw.Write(productInfo.Count);
                    // System.Console.WriteLine("Has saved " + productInfo.Count + " Files.");
                } 
        }

        int CheckForItems (string path){
            using (StreamReader sr = File.OpenText(path+"/out/SaveData.csv")){
                return int.Parse(sr.ReadLine());
            }
        }
        void LoadTextFromFile (string path, List<Product> products){
            // Load itens
            string[] summary = File.ReadAllLines(path+"/out/Summary.csv");
            using (StreamReader sr = File.OpenText(path+"/out/Summary.csv")){
                foreach (string s in summary){
                    string[] item = s.Split(',');
                    string name = item[0];
                    double price = double.Parse(item[1]);
                    int quantity = int.Parse(item[2]);
                    products.Add (new Product(name, price, quantity));
                }
            }

            // Show Items
            System.Console.WriteLine("Product: ");
            foreach (Product p in products){
                System.Console.WriteLine(p);
            }
        }
    }
}