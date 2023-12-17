// See https://aka.ms/new-console-template for more information
using System.Xml.Serialization;
using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        
        var serializer = new XmlSerializer(typeof(Type_TradeFeed));
        var folderPath = @"./trades"; // Replace with your folder path
        foreach (var file in Directory.EnumerateFiles(folderPath, "*.xml"))
        {
            using var fileStream = new FileStream(file, FileMode.Open);
            var result = (Type_TradeFeed)serializer.Deserialize(fileStream);

            if (result is null)
            {
                Console.WriteLine("Unable to read file");
                return;
            }

            Console.WriteLine(result.Common.TransactionNumber + " " + result.Common.UnderlyingCusip + " " +  result.Common.Price);
        }
    }
}
