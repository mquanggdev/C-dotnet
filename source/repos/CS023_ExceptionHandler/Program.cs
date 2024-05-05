using System;
using MyConsoleApp;
/*
Trường hợp thực hiện phép chia cho 0 thì chỉ có kiểu int / int bị lỗi
còn nếu a là số kiểu float thì lúc này nó sẽ hiểu b là nhỏ vô cùng => đáp án vẫn sẽ được thực hiện và ra vô cùng
*/
namespace CS023_Exception
{
    class Program
    {
        public static void Example_FileNotFoundException(){
            string path = "test.txt" ;
            try
            {
                string s = File.ReadAllText(path);
                Console.WriteLine(s); 
            }
            catch (FileNotFoundException fn)
            {
                Console.WriteLine(fn.Message);
                Console.WriteLine("Khong tim thay file || file khong ton tai");
            }
            catch(ArgumentNullException ane){
                Console.WriteLine(ane.Message);
                Console.WriteLine("Duong dan file phai khac null");
            }
        }
        public static void Register(string name , int age ){
            if(string.IsNullOrEmpty(name)){
                throw new NameExceptionNull();
            }
            if ( age < 18 || age > 50){
                throw new AgeException(age);
            }
            Console.WriteLine($"Xin Chao {name} {age}");
        }
        static void Main()
        {
           try
           {
            Register("Quang" , 16);
           }
           catch (AgeException e)
           {
            Console.WriteLine(e.Message);
           }
           catch(NameExceptionNull e){
            Console.WriteLine(e.Message);
           }
        }
    }
}
