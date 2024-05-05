using System;
using System.Security.Cryptography;
namespace CS12_OOP_Inheritance {
    class Program {
        static void Main(string[] args){
            Cat cat = new Cat();
            Cat cat2 = new Cat("Con meo");
        }
    }
    class Animal {
        public Animal(){
            Console.WriteLine("Khoi tao Animal");
        }
        public Animal(string a){
            Console.WriteLine($"Khoi tao class Animal voi tham so! - {a}");
        }
        public int Legs{set;get;}
        public float Weight{set;get;}
        public void ShowLegs(){
            Console.WriteLine($"Legs : {Legs}");
        }
    }
    class Cat : Animal{
        public string Food;
        public Cat() : base(){ // khởi tạo cho lớp kế thừa không tham số
            this.Legs = 4;
            this.Food = "Mouse";
            Console.WriteLine("Khoi tao CAT ");
        }
        public Cat(string s) : base(s){ // khởi tạo cho lớp kế thừa có tham số
            Console.WriteLine($"Khoi tao CAT voi tham so {s}");
        }
        public void Eat(){
            Console.WriteLine(Food);
        }
        public new void ShowLegs(){ // tạo một hàm mới có cùng tên lớp cơ sở
            Console.WriteLine("Loai meo co so chan la " + Legs);
        }

        public void ShowInfo(){
            base.ShowLegs();  // gọi lại phương thức trong lớp cơ sở
            ShowLegs(); // phương thức đã tạo trong lớp kế thừa!
        }
    }
}