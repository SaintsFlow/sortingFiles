﻿using System;
using System.IO;
using System.Collections.Generic;

namespace sortingFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a folder to sort: ");
            string inp = Console.ReadLine();
            sort(inp);
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
