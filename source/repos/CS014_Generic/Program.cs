using System;
namespace Cs14_generic
{
    class Program{
        class Product<A>{
            A ID ;
            public void setId(A id){
                this.ID = id;
            }
            public void Printf(){
                Console.WriteLine("Product: {0}", ID); 
            }
        }
        static void Swap<T> (ref T a , ref T b){
            T t ;
            t = a ;
            a = b ;
            b = t ;
        }
        static void Main(string[] args){
            string a = "Hello";
            string b = "C#";
            Swap(ref a,ref b); // nó sẽ ngầm định là kiểu string
            Console.WriteLine(a + " " + b);

            Product<int> sp1 = new Product<int>();
            sp1.setId(356789);
            sp1.Printf();
        }
    }
    
}