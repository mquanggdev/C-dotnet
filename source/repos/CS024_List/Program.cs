using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
namespace CS024_List
{
    class Program
    {
        public static void ExampleList(){
             List<int> ds1 = new List<int>();
            ds1.Add(0);
            ds1.AddRange(new []{1,2,3,4});
            Console.WriteLine("Do dai cua danh sach la");
            Console.WriteLine(ds1.Count);// in ra độ dài của danh sách
            ds1.Insert(ds1.Count, 5); // chèn vào vị trí cuối một phần tử là 5
            Console.WriteLine("Day sau khi them 1 phan tu la :");
            foreach(var x in ds1) Console.WriteLine(x); // duyệt danh sách
            Console.WriteLine("Day sau khi xoa mot phan tu la :");
            ds1.RemoveAt(0); // xóa số 0 khỏi danh sách!
            foreach(var x in ds1) Console.WriteLine(x);



            Console.Clear();



            // tìm kiếm phần tử trong mảng mà chia hết cho 5
            var n = ds1.Find((int e) => { // hàm find là hàm có sẵn trong danh sách, nó trả về phần tử phù hợp điều kiện trong callback
                return e % 5 == 0;
            });
            var r = ds1.FindAll((e)=>{ // trả về một mảng các phần tử nhỏ hơn 2 ;
                return e < 2 ;
            });

        }
        // ví dụ cụ thể
        class Product {
            public string name {set;get;}
            public double price{set;get;}
        }
        static void Main()
        {
           List<Product> ds = new List<Product>() {
               new Product(){ name ="Iphone",price = 999},
               new Product(){ name = "Samsung",price = 888},
           };

           var p = ds.Find((e) => {
                return e.price == 999; 
           });
           var gia = ds.FindAll((e)=>{
                return e.price <= 999 ;
           });
           var start = ds.FindAll((e) => {
                return e.name.StartsWith("I"); // tìm kiếm các chữ bắt đầu bằng I ; 
           });
           if ( p != null){
            Console.WriteLine($"Name {p.name}  Price {p.price}");
           }


           Console.Clear();




           // sắp xếp các phần tử : 
           ds.Sort((p,e) =>{
            if ( p.price == e.price ) return 0;
            if (p.price > e.price ) return 1 ; // -> sắp xếp từ thấp đến cao , nếu muốn ngược lại thì đổi dấu hoặc return - 1;
            return -1 ; // p.price < e.price;
           });
           foreach ( var x in ds){
            Console.WriteLine($"Name {x.name} Price {x.price}");
           }


           // sorted list : 

            SortedList<string,Product> sortList = new SortedList<string, Product>(); // biến đầu tiên là kiểu lưu trữ key , kiểu thứ 2 là lưu trữ value 
            sortList["sanpham1"] = new Product(){ name = "Iphone X" , price = 1000};
            sortList["sanpham2"] = new Product(){ name = "SamSung S23Utral" , price = 1200};

            foreach (KeyValuePair<string,Product> item in sortList)
            {
                var key = item.Key;
                var value = item.Value;
                Console.WriteLine($"{key} - {value.name}");
            }
        }
    }
}
