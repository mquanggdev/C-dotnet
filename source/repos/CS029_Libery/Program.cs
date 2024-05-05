using System;
using Newtonsoft.Json;
using MQGdev.Utils ;
namespace CS029_Libery
{
   
    class Program
    {
         class Product {
        public string? Name{set;get;}
        public DateTime Expiry{set;get;}
        public string[]? Sizes{set;get;}
        public Product(){
            
        }
    }
        // dotnet add package Newtonsoft.Json --version 13.0.3
        // dotnet restore 
        // dotnet add tenduan.csproj 
        //dotnet add D:\C#\source\repos\CS029_Libery\CS029_Libery.csproj reference D:\C#\lib\Utils\Utils.csproj
        static void Main()
        {
            double a = 10001 ;
            var kq = CovertMoneyToText.NumberToText(a) ;
            Console.WriteLine(kq) ;
        }
    }
}
