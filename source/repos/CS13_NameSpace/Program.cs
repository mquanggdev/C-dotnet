using System;
namespace CS13_Namespace
{
    class Program
    {
        static void Main()
        {
            SanPham.Product prod = new SanPham.Product();
            prod.Name = "Ipad";
            prod.Price = 10001;
            prod.discription = "Day la IPad";
            prod.GetInfo();
        }
    }
}