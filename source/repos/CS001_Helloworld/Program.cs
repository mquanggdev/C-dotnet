using System;
namespace CS001
{
    class Program {
        static void Main(string[] args){
          int a = 1001 ;
        //   Console.ForegroundColor = ConsoleColor.DarkGreen; // dat mau chu tren console
          Console.ResetColor() ;
          Console.Title  = "Vi Du su dung Console"; // dat tieu de cho console
          Console.Clear();
          Console.WriteLine("Xin Chao Console!");
          Console.WriteLine("Xin Chao Console lan 2!") ;
          Console.ReadKey() ; // dung lai khi nao an enter thi hien thi
          string hovaten ;
          Console.WriteLine("Vui long nhap ho va ten");
          hovaten = Console.ReadLine() ; // nhap chuoi bang ban phim
          Console.WriteLine("Xin Chao {0}",hovaten) ; // dat ho ten vao cho so 0 roi moi xuat ra man hinh
          int age ;
          Console.WriteLine("Hay nhap so tuoi cua ban!") ;
          string tmp;
          tmp = Console.ReadLine();
          age = int.Parse(tmp);
          Console.WriteLine("Hay nhap chieu cao cua ban!");
          double height ;
          height = Convert.ToDouble(Console.ReadLine()); // cach 2 de viet
          Console.WriteLine("Thong tin cua ban la {0} tuoi {1} chieu cao {2}",hovaten,age,height);// cach in ra khac
          var ab = 12; // khai bao ngam dinh (phai khoi tao gia tri luon cho bien khai bao bang var) , nhu nay thi no ngam dinh hieu a co kieu ky tu la int 
          var b = true; // hieu la kieu boolean .
          const double Pi = 3.14 ; // khai bao la hang so va khong thay doi dc
     }
    }
}