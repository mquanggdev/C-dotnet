using System;

namespace MyConsoleApp
{
    public class NameExceptionNull : Exception {
        public NameExceptionNull() : base("ten khong duoc rong"){
        }
    }
    public class AgeException : Exception{
        public int age {set;get;}

        public AgeException(int age) : base("Tuoi khong phu hop!"){
            this.age = age;
        }
        public void Detail(){
            Console.WriteLine($"Tuoi {age} , khong nam trong khoang [18,100]");
        }
    }
}
