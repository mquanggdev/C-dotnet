using System;
using System.Reflection;
using CS016_Inteface;
namespace CS16_Virtual{
    class Program{

        class Product {
            public string Name{set;get;}
            public int Price{set;get;}

            public  virtual void showInfo(){
                Console.WriteLine($"Info : {Name}, ${Price}");
            }
        }
        class Iphone : Product{
            public Iphone(){
                Price = 500;
                Name = "IPhone";
            }
            public override void showInfo(){
                base.showInfo();
                Console.WriteLine($"This is {Name}, price : {Price}. It's a smart phone.");
            }
        }
        static void Main(){
            // Iphone ip = new Iphone();
            // ip.showInfo();
            CS016_Inteface.HinhChuNhat h = new CS016_Inteface.HinhChuNhat(4,5);
            
            Console.WriteLine($"DienTich : {h.DienTich()} + ChuVi : {h.ChuVi()}");
        }
    }
}