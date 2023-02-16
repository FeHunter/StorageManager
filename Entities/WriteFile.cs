using System.IO;
using System.Globalization;

namespace StorageManager  {
    class WriteFile{

        Manager manager = new Manager();

        public void WriteFiles (List<Product> product){

            System.Console.WriteLine();
            System.Console.Write("How many products do you want to register? ");
            int n = 0;
            do {
                n = int.Parse(Console.ReadLine());
            }while (n <= 0);
            
            for (int i=0; i < n; i++){
                System.Console.Write("Product Name: ");
                string name = Console.ReadLine();
                System.Console.Write("Product Price: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                System.Console.Write("Product Quantity: ");
                int quantity = int.Parse(Console.ReadLine());
                product.Add (new Product(name, price, quantity));
                System.Console.WriteLine();
            }

            CreateOutAndSummary();
            WriteFilesOnSummary (product);
        }

        void CreateOutAndSummary (){
            // Verificar se pasta já foi criada, se não criar uma
            if (!Directory.Exists(manager.Path+"/out")){
                Directory.CreateDirectory(manager.Path+"/out");
            }
            // Verificar o arquivo Summary.csv
            if (!File.Exists(manager.Path+"/out/Summary.csv")){
                File.Create(manager.Path+"/out/Summary.csv");
            }
        }

        public void WriteFilesOnSummary (List<Product> product){
            if (Directory.Exists(manager.Path+"/out")){
                // Write products on the text file
                foreach (Product p in product){
                    using (StreamWriter sw = File.AppendText(manager.Path+"/out/Summary.csv")){
                        sw.WriteLine(p);
                    }
                    
                }
                // Save quantity of current products created
                using (StreamWriter sw = File.CreateText(manager.Path+"/out/SaveData.csv")){
                    sw.Write(product.Count);
                }       
            }
        }
    }
}