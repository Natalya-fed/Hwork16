using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using System.Text.Encodings.Web;

namespace Hwork16._2
{
    class Program
    {
        static void Main(string[] args)
        {
            double max = 0;
            string Name = "";
            string path = @"D:\!ОБУЧЕНИЕ\Проекты\Задание 16\Hwork16\Hwork16\bin\Debug\Products.json";
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            Product [] array = JsonSerializer.Deserialize<Product[]>(File.ReadAllText(path));
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"Код: {array[i].CodeProduct}\nНаименование: {array[i].NameProduct}\nЦена: {array[i].PriceProduct}");
                Console.WriteLine("-----------------------------------------------------");
                if (array[i].PriceProduct > max)
                {
                    max = array[i].PriceProduct;
                    Name = array[i].NameProduct;
                }
            }
            Console.WriteLine($"\n");
            Console.WriteLine($"Самый дорогой товар - {Name}, цена которого составляет {max:f2}");
            Console.ReadKey();
        }
        class Product
        {
            [JsonPropertyName("Код")]
            public int CodeProduct { get; set; }
            [JsonPropertyName("Наименование")]
            public string NameProduct { get; set; }
            [JsonPropertyName("Цена")]
            public float PriceProduct { get; set; }
        }
    }
}
