using System.IO;
using System.Globalization;

namespace StorageManager {
    class LoadFile {

        Manager manager = new Manager();

        public void LoadDataFromFile (){
            if (VerifyForSavedProducts() != 0){
                // Load itens
                using (StreamReader sr = File.OpenText(manager.Path+"/out/Summary.csv")){
                    WriteFile writeFile = new WriteFile();
                    string[] summary = File.ReadAllLines(manager.Path+"/out/Summary.csv");
                    List<Product> products = new List<Product>();
                    foreach (string s in summary){
                        string[] item = s.Split(',');
                        string name = item[0];
                        double price = double.Parse(item[1]);
                        int quantity = int.Parse(item[2]);
                        products.Add (new Product(name, price, quantity));
                        writeFile.WriteFilesOnSummary(products);
                    }
                    // Show Items
                    System.Console.WriteLine("\nLIST:");
                    foreach (Product p in products){
                        System.Console.WriteLine(p);
                    }
                }
            }else {
                System.Console.WriteLine("There is no files saved.");
            }
        }

        int VerifyForSavedProducts (){
            if (Directory.Exists(manager.Path+"/out")){
                using (StreamReader sr = File.OpenText(manager.Path+"/out/SaveData.csv")){
                    return int.Parse(sr.ReadLine());
                }
            }else {
                return 0;
            }
            
        }
    }
}
