using System;
using Vukhi_OOP;
namespace CS10_OOP_Main{
    class Program
    {
          static void Main(string[] args){
            VuKhi two = new VuKhi("Sung luc","001");
            Console.WriteLine($"Name {two.Name} , Id {two.Id}");
            two.Name = "Sung may";
            two.Id = "002";
             Console.WriteLine($"Name {two.Name} , Id {two.Id}");
             two.Name2 = "Sung AKa";
             two.Id = "003";
             Console.WriteLine($"Name {two.Name2} , Id {two.Id}");
          }
    }
}