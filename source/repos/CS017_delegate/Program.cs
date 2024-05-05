using System;
namespace CS017{
    public delegate void ShowDialog(string message); // thằng này là biến đại diện , muốn gọi đến phương thức này thì hàm được setup phải có cùng kiểu biểu diễn , trả về và có cùng tham số truyền

    class Program{
        static void Info(string s){
            Console.WriteLine(s) ;
        }
        static void Warming(string s){
            Console.WriteLine(s) ;
        }
        static int TinhTong(int a, int b){
            return a + b ;
        }
        static double TinhChia(int a, int b){
            return a / b;
        }
        static void Main()
        {
            ShowDialog log = null; // nó có tính chất là có thể nối thi hành
            log += Info ;
            log += Warming;
            log.Invoke("Xin Chao c#");


            /// Action , Func  delegate-generic : có thể dùng trực tiếp cái này mà không cần khai báo trước
            Action action ; // ~ delegate void kieu();
            Action<string,int> acction1; // ~ delegate void tenkieu(string s, int i );

            Func<int> f1; //~ delegate int Kieu(); không tham số
            Func<string,string,int> f2; //~ delegate string kieu(string s1, int s2); có hai tham số

             Func<int, int, int> func;
            int a = 10;
            int b = 2;
            func = TinhTong;
            Console.WriteLine("Tong cua a va b la" + func(a,b));
        }
    }
}