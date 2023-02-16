using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;

namespace StorageManager {

    class Manager {

        bool endProgram = false;
        WriteFile _writeFile = new WriteFile ();
        LoadFile _loadFile = new LoadFile();
        public string Path = @"C:\Users\Felipe Hunter\Programação\Programs C#\Storage_Manager";
        public List<Product> ProductList = new List<Product>();

        public void StartToManager (){
            try {
                Answer answer = new Answer();
                while (!endProgram){
                    do{
                        System.Console.WriteLine();
                        System.Console.WriteLine("1 - Load Current Products\n2 - Add new product\n3 - Remove from list");
                        answer = Enum.Parse<Answer>(Console.ReadLine());
                    } while ( !Enum.IsDefined<Answer>(answer) );   
                        
                    if (answer == Answer.LoadData){
                        _loadFile.LoadDataFromFile ();
                    }else if (answer == Answer.AddItem){
                        _writeFile.WriteFiles (ProductList);
                    }else if (answer == Answer.RemoveItem){
                        RemoveFromList ();
                    }
                }
            }
            catch (IOException e){
                System.Console.WriteLine("Error: " + e.Message);
            }
        }

        void RemoveFromList (){
            // LoadDataFromFile ();
            for (int i=0; i < ProductList.Count; i++){
                System.Console.WriteLine($"{0}: {1}", i, ProductList[i]);
            }
            System.Console.WriteLine("Debuggin... Test!!!" + ProductList.Count);
        }

        public void AskToFinish (){
            // Ask to finish
            System.Console.WriteLine();
            System.Console.WriteLine("Anything more? y/n");
            char s = char.Parse(Console.ReadLine().ToLower());
            if (s != 'y'){
                endProgram = true;
            }
        }
    }
}