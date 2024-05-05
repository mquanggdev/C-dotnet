// See https://aka.ms/new-console-template for more information
using System;
namespace CS006_Methods
{
    class Program{
        static void Main(string[] args){
            // Console.WriteLine("Hello, World!");
            // Hello();
            // var result = CacPhepToan.TinhToan.TongHaiSo(3,5); // phai truy cap tu ten namespace -> ten class > phuong thuc
            // Console.WriteLine(result);

            // XinChao("Quang","Tran"); // day la truyen thong thuong 
            // XinChao(FirstName:"Tran" , LastName:"Quang" ); // truyen nhu nay la khong can thu tu cac tham so

            int a  = 6;
            int resultSet = LuyThua(ref a);
            Console.WriteLine(a); // khong co ref thi a = 6 , co ref thi a = 36 boi vi no da bi bien doi trong ham luy thua
            Console.WriteLine("Luy thua bac 2 cua a la : " + resultSet);
        }

        static void Hello(){
            Console.WriteLine("Hello C#");
        }
        // truyen tham so voi ten
        public static void XinChao(string LastName , string FirstName){
            Console.WriteLine("Xin Chao " + FirstName + " " + LastName);
        }
        // truyen tham chieu va truyen tham tri :
        public static int LuyThua( ref int a){
            a = a * a ; // them ref thi la truyen tham chieu
            return a ;
        }
    }
}
