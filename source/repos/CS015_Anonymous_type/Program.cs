using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
namespace CS015
{
    class Program {
        class Student{
            public string name {set;get;}
            public int age {set;get;}
            public string address{set;get;}

        }
        static void Main(string[] args){
            List<Student> students = new List<Student>(){
                new Student(){name = "A" , age = 12 , address = "China"},
                new Student(){name = "B" , age = 13 , address = "VietNam"},
                new Student(){name = "C" , age = 12 , address = "USA"},
                new Student(){name = "D" , age = 13 , address  = "Nga"}
            };

            var ans = from sv in students where sv.age <= 12 select new { // truy van linq
                Name = sv.name,
                Age = sv.age,
                Address = sv.address
            };

            foreach(var stu in ans){
                Console.WriteLine($"Name {stu.Name} Age {stu.Age}  Address {stu.Address}");
            }
        }
    }
}