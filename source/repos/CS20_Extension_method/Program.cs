using System;
using ExtensionMethod;
namespace CS20_Extension
{
    // điều kiện là phải viết các phương thức mở rộng nằm trong lớp tĩnh !
    static class ABC{
        public static void Print(this string s, ConsoleColor consoleColor){ // thêm từ khóa this để mở rộng thêm phương thức cho s.
            Console.ForegroundColor = consoleColor;
            Console.WriteLine(s);
        }
    }
    class Program
    {
        public static void Prints(string s, ConsoleColor consoleColor){
            Console.ForegroundColor = consoleColor;
            Console.WriteLine(s);
        }
        static void Main()
        {
            Console.WriteLine("Hello, world!");
            string s = "Xin Chao C#";
            s.Print(ConsoleColor.Blue); // phương thức mở rộng tức là nó có thể sử dụng như thế này thay vì cái bên dưới
            Prints(s,ConsoleColor.Green);

            int t  = 2 ;
            t = t.LuyThua();
            double x = t.TinhCan();
            Console.WriteLine($"Luy thua la: {t}");
            Console.WriteLine($"Tinh can la: {x}");
        }
    }
}
