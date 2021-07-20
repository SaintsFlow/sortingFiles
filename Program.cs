using System;
using System.IO;
using System.Collections.Generic;

namespace sortingFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length == 0){
                Console.WriteLine("Enter a folder to sort: ");
                string inp = Console.ReadLine(); 
                if(!Directory.Exists(inp))
                {
                    Console.WriteLine("Enter a valid folder");
                } else {
                    sort(args[0]);
                }
            } else {
                if(!Directory.Exists(args[0]))
                {
                    Console.WriteLine("Enter a valid folder");
                } else {
                    sort(args[0]);
                }
            }

        }
        static List<string> getFolderFiles(string folderPath)
        {
            List<string> files = new List<string>();
            var foundedFiles = Directory.EnumerateFiles(folderPath, "*");

            foreach(var file in foundedFiles)
            {
                files.Add(file);
            }
            
            return files;
        }
        static void sort(string folderPath)
        {
            foreach(string file in getFolderFiles(folderPath))
            {
                FileInfo info = new FileInfo(file);
                string fileExtension = info.Extension.Trim('.');

                if(Directory.Exists(folderPath+Path.DirectorySeparatorChar+fileExtension))
                {
                    string fileName = folderPath+Path.DirectorySeparatorChar+fileExtension+Path.DirectorySeparatorChar+info.Name;
                    File.Move(file, fileName);
                }
                else
                {
                    var newDirectory = Directory.CreateDirectory(folderPath+Path.DirectorySeparatorChar+fileExtension);
                    if(Directory.Exists(newDirectory.FullName))
                    {
                        string fileName = newDirectory.FullName+Path.DirectorySeparatorChar+Path.DirectorySeparatorChar+info.Name;
                        File.Move(file,fileName);
                    }
                }

            }
        }
    }
}
