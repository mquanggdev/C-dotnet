using System;
using System.Runtime.Intrinsics;
using System.Security.Cryptography.X509Certificates;

namespace CS021_StaticMethod
{
    class NewCount{
        public static int number = 0;
        public static void Info(){
            Console.WriteLine("So lan duoc goi la " + number);
        }
        public void Count(){
            number++;
        }
    }

    class Student {

        public readonly string name ; // thuộc tính chỉ đọc - nhưng có thể gán thông qua hàm khởi tạo
        public Student(string name){
            this.name = name ;
            Console.WriteLine("Ten cua Ban la " + this.name);
        }

    }


    class Vector{
        private int x{set;get;}
        private int y{set;get;}
        public Vector(){

        }
        public Vector (int x, int y){
            this.x = x; 
            this.y = y;
        }
        public void PrinfVector(){
            Console.WriteLine($"[{x},{y}]");
        }
        public static Vector operator+(Vector a , Vector b){
            Vector c = new Vector();
            c.x = a.x + b.x;
            c.y = a.y + b.y;
            return c;
        }


        // indexer
        public int this[int i]{
            set{
                switch(i){
                    case 0: 
                         x = value;
                         break;
                    case 1: 
                         y = value;
                         break;
                    default  : throw new IndexOutOfRangeException();
                }
            }
            get{
                 switch(i){
                    case 0: 
                         return x;
                    case 1: 
                         return y;
                    default  : throw new IndexOutOfRangeException();
                }
            }
        }
    }
    class Program
    {
        public static void Exam_Static_Readonly(){
            NewCount newCount = new NewCount();
            NewCount newCount1 = new NewCount();
            newCount.Count();
            newCount1.Count();
            NewCount.Info(); // phương thức tĩnh được gọi thông qua hàm chứa nó // output : 2 ;
            Student abc = new Student("quang");
        }
        public static void Exam_OverrloadingMethod_Indexer(){
            Vector v = new Vector(3,2);
            v.PrinfVector();// [3,2]
            Vector v2 = new Vector(4,5);
            Vector c = v + v2;
            c.PrinfVector();

            v[0] = 1;
            v[1] = 2;
            v.PrinfVector();
        }


        static void Main()
        {
            Exam_OverrloadingMethod_Indexer();
        }
    }
}
