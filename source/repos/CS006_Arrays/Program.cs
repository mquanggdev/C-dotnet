// See https://aka.ms/new-console-template for more information
using System;
using System.Linq;
namespace CS006
{
    class Program {
        static void Main(string[] args){
            Console.WriteLine("Hello, World!");
            string[] sinhvien = new string[] {"Nguyen Van A" , "Nguyen Van B" , "Nguyen Van C"};
            Console.WriteLine("Do dai cua mang sinh vien la : " + sinhvien.Length);
            Console.WriteLine("Mang nay la mang " + sinhvien.Rank + " chieu");
            for (int i = 0; i < sinhvien.Length; i++)
            {
                Console.WriteLine(sinhvien[i]);
            }
            foreach ( var x in sinhvien){
                Console.WriteLine(x);
            }
            Console.Clear();


            // cac phuong thuc doi voi mang so 
            int[] numbers = new int[] {0,1,2,3,4,5,6,7,8,9};
            Console.WriteLine("Min value " + numbers.Min());
            Console.WriteLine("Max value " + numbers.Max());
            Console.WriteLine("Sum arrays " + numbers.Sum());

            Array.Sort(numbers); // sap xep mang
            foreach(var it in numbers){
                Console.Write(it + ", ");
            }


            // Mang 2 chieu
            Console.Clear();
            int[,] numbers2 = new int[,]{{1,2,3},{2,3,4}}; // khoi tao mot mang 2 chieu
            // duyet mang 2 chieu
            for( int i = 0 ; i <  numbers2.GetLength(0) ; i++){ // getLenght(0) -> tra ve so phan tu trong chieu thu 1
                for ( int j = 0 ; j < numbers2.GetLength(1) ;j++ ){ // getlength(1) -> tra ve so phan tu trong chieu thu 2
                    Console.WriteLine(numbers2[i,j]);
                }
                Console.WriteLine();
            }
        }
    }
}