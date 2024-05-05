// See https://aka.ms/new-console-template for more information

using System;
using System.IO.;
namespace cs26_File
{
    class Program
    {
        // thằng này có nhiệm vụ là tìm ra tất cả các file có trong thư mục path . bởi vì nhiều khi trong file lại tồn tại một thư mục khác trong thư mục đấy lại tồn tại nhiều file hoặc nhiều thư mục khác
        static void ListFileDirectory(string path){ 
            string[] directories = Directory.GetDirectories(path);
            string[] files = Directory.GetFiles(path);
            foreach(var file in files){
                Console.WriteLine(file);
            }
            foreach(var directory in directories){
                Console.WriteLine(directory);
                ListFileDirectory(directory); // đệ quy
            }
        }
        static void Main()
        {
            string path = "obj" ;
            ListFileDirectory(path);
        }
    }
}
