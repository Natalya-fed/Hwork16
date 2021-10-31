﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using System.Text.Encodings.Web;

namespace Hwork16
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "Products.json";
            if (!File.Exists(path))
            {
                File.Create(path);
            }
            Console.WriteLine("Введите:\n1.Код товара\n2.Название товара\n3.Цена товара");
            const int n = 5;
            Product[] array = new Product[5];
            for (int i = 0; i < n; i++)
            {
                array[i] = new Product();
                Console.WriteLine($"Введите данные по товару № {i + 1}");
                array[i].inputProduct();
            }
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            using (StreamWriter sw = new StreamWriter(path, false))
            {
                string jsonString = JsonSerializer.Serialize(array, options);
                sw.WriteLine(jsonString);
            }
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

            public void inputProduct()
            {
                Console.Write("1.");
                CodeProduct = Convert.ToInt32(Console.ReadLine());
                Console.Write("2.");
                NameProduct = Convert.ToString(Console.ReadLine());
                Console.Write("3.");
                PriceProduct = (float)Convert.ToDouble(Console.ReadLine());
            }
        }
    }
}
