using System;
using System.Collections;
using System.Formats.Tar;
using System.Linq;
namespace CS028_Linq
{
    /*Linq : language integrated query -> ngôn ngữ  truy vấn tích hợp
    ~Sql ;
    nguồn dữ liêu : IEnumrable , IEnumrable<T> (Array , List , Stack , Queue )
                    XML , SQL ;
    */
    public class Product
{
    public int ID {set; get;}
    public string Name {set; get;}         // tên
    public double Price {set; get;}        // giá
    public string[] Colors {set; get;}     // các màu sắc
    public int Brand {set; get;}           // ID Nhãn hiệu, hãng
    public Product(int id, string name, double price, string[] colors, int brand)
    {
        ID = id; Name = name; Price = price; Colors = colors; Brand = brand;
    }
    // Lấy chuỗi thông tin sản phẳm gồm ID, Name, Price
    override public string ToString()
       => $"{ID,3} {Name, 12} {Price, 5} {Brand, 2} {string.Join(",", Colors)}";

    }
public class  Brand {
    public string Name {set; get;}
    public int ID {set; get;}
}
    class Program
    {
        static void Main()
        {
            var brands = new List<Brand>() {
                new Brand{ID = 1, Name = "Công ty AAA"},
                new Brand{ID = 2, Name = "Công ty BBB"},
                new Brand{ID = 4, Name = "Công ty CCC"},
            };
            var products = new List<Product>(){
                    new Product(1, "Bàn trà",    400, new string[] {"Xám", "Xanh"},         2),
                    new Product(2, "Tranh treo", 400, new string[] {"Vàng", "Xanh"},        1),
                    new Product(3, "Đèn trùm",   500, new string[] {"Trắng"},               3),
                    new Product(4, "Bàn học",    200, new string[] {"Trắng", "Xanh"},       1),
                    new Product(5, "Túi da",     300, new string[] {"Đỏ", "Đen", "Vàng"},   2),
                    new Product(6, "Giường ngủ", 500, new string[] {"Trắng"},               2),
                    new Product(7, "Tủ áo",      600, new string[] {"Trắng"},               3),
                };
            

            // lay ra san pham co gia 400 -> đây là câu truy vấn đầy đủ
            var query = from paa in products // return IEnumerable<Product>
                        where paa.Price == 400 
                        select paa;
            foreach(var product in query){
                Console.WriteLine(product);
            }
            // các phương thức mở rộng trong linq
            
            
           
            
            int[] numbers = { 1,2,3,4,5,6,7,8,9};
            // select -> return 1 danh sách các phần tử theo thành phần muốn lấy : tức nó chỉ in thành phần đó ra thôi
            var kq = products.Select((p)=>{
                return p.Name;
            });
            // where -> return 1 danh sách các phần tử theo điều kiện return : nó phải in tất cả thông tin của thành phần phù hợp với tiêu chí return
            var kq2 = products.Where((p) => {
                return p.Name.Contains("tr"); // nếu phần tử mà có chứa ký tự "tr" thì phần tử đó sẽ return true;
            });
            foreach (var item in kq2)
            {
                Console.WriteLine(item);
            }
             // Min() , Max , Sum , Average .
            Console.WriteLine($"Max: {numbers.Max()} , Min: {numbers.Min()} , Sum: {numbers.Sum()}, Avg :{numbers.Average()} ");
            // có thể sự dụng các phương thức max_min cho cả object.
            Console.WriteLine("San pham co gia lon nhat " + products.Select(p => p.Price).Max());
            

Console.Clear();

            
            // Join : Kết hợp các nguồn dữ liệu để lấy ra sản phẩm phù hợp : như ở dưới là lấy ra sản phẩm kết hợp từ product và brands và cái so sánh là p.Brand == b.id thì sẽ xác lập kết quả
            var kq4 = products.Join(brands , p => p.Brand , b => b.ID , (p , b) => {
                return new {
                    Ten = p.Name,
                    Thuonghieu = p.Brand
                };
            });

            foreach( var item in kq4){
                Console.WriteLine(item) ;
            }
            // GroupJoin : giống như joins nhưng những kết quả sẽ trả về dưới dạng nhóm theo một tiêu chí : ví dụ như lấy ra các sản phẩm thuộc thương hiệu 1 , các sản phẩm thuộc thương hiệu 2 -> lấy sản phẩm  theo thương hiêu nên cần để brands là thành phần đi lấy group , thằng product sẽ là thằng để lấy ra các sản phẩm thuộc group đó.

            var kq5 = brands.GroupJoin(products , b => b.ID , p => p.Brand , (b , p)=>{
                return new {
                    TenThuongHieu = b.Name ,
                    CacSanPham = p 
                };
            });
            foreach (var gr in kq5) 
            {
                Console.WriteLine(gr.TenThuongHieu);
                foreach (var paa in gr.CacSanPham)
                {
                    Console.WriteLine(paa) ;
                }
            }


Console.Clear();


            // lấy ra n phần tử đầu tiên = take;
            // lấy ra tất cả phần tử bỏ qua n phần tử đầu tiên = skip;
            products.Take(4).ToList().ForEach((p)=>{ //~ p => Console.WriteLine(p);
                Console.WriteLine(p);
            });
            products.Skip(2).ToList().ForEach((p)=>{ //~ p => Console.WriteLine(p);
                Console.WriteLine(p);
            });

Console.Clear();

            // sắp xếp tăng dần = OderBy và giảm dần bằng OrderbyDescending.
            // đảo ngược lại mảng bằng reverse
            Console.WriteLine("Cac san pham sap xep tang dan theo price la :");
            products.OrderBy((p)=>{return p.Price;}).ToList().ForEach((p) => Console.WriteLine(p));
            Console.WriteLine("Cac san pham sap xep giam dan theo id la :");
            products.OrderByDescending(p => p.Brand).ToList().ForEach((p) => Console.WriteLine(p));



Console.Clear();
              



            // GroupBy : nhóm các nhóm theo một tiêu chí nào đó , chẳng hạn như cùng giá trị
            Console.WriteLine("Cac phan tu duoc in theo nhom cung gia la : ");
            Console.WriteLine("---------------------------------------------------------------------------");

            var ketQua = products.GroupBy(p => p.Price); // nó sẽ trả về một cặp key và các value tương ứng với cái key đó
            foreach (var group in ketQua)
            {
                Console.WriteLine(group.Key); // key là mức giá
                foreach (var item in group)
                {
                    Console.WriteLine(item); // value là các sản phẩm có mức giá đó
                }
            }
Console.Clear();
            // Distinct : loại bỏ các phần tử có cùng giá trị và chỉ giữ lại một kết hợp cùng selectmany : lấy ra một mảng dữ liệu trên một trường tiêu chí : ví dụ lấy mảng màu trên tiêu chí lấy ra màu sản phẩm
            Console.WriteLine("Cac mau cua san pham khong trung lap la ");
            Console.WriteLine("---------------------------------------------------------------------------");

            products.SelectMany(p => p.Colors).Distinct().ToList().ForEach( p => Console.WriteLine(p));
Console.Clear();
            // Single: lấy ra phần tử thỏa mãn một điều kiện logic : nếu có một phần tử thỏa mãn logic thì nó sẽ trả về phần tử đó , nếu không có hoặc có nhiều hơn một phần tử thì nó sẽ phát sinh lỗi.
            // SingleOrDefault : thì nó sẽ trả về null nếu không tìm thấy phần tử , nhưng vẫn sẽ phát sinh lỗi nếu có nhiều hơn hai phần tử!
            // ngược lại là Any : kiểm tra phần tử nào thỏa mãn logic : nếu mà thỏa mãn điều kiện logic thì trả về false ví dụ như nếu tìm thấy có 1 phần tử thỏa mãn -> true , không tìm thấy -> false;
            // tiếp theo là All : kiểm tra một loạt các sản phẩm theo một tiêu chí : ví dụ tất cả phần tử có giá trên 200 đúng hay không ? nếu đúng thì nó sẽ trả về true , còn không sẽ trả về false ;
            // Cout : đếm các phần tử thỏa mãn một điều kiện nhất định
            var p = products.Single(p => p.Price == 600);
            Console.WriteLine(p) ; // chỉ có một phần tử có giá 600 nên nó sẽ in ra phần tử đó
            var any = products.Any(p => p.Price == 300);
            Console.WriteLine(any);
            var all = products.All( p => p.Price >= 200);
            Console.WriteLine(all);
            var count = products.Count( p => p.Price >= 300);
            Console.WriteLine(count) ;
Console.Clear();
// một đề bài đơn giản như sau : in ra tên sản phẩm , tên thương hiệu , có giá 300 -> 400 theo giá giảm dần
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine("Lay cac san pham co gia tu 300 -> 400 va in theo gia giam dan la ");
        
            products.Where( p => p.Price >= 300 && p.Price <= 400)
                     .Join(brands,p => p.Brand , b => b.ID , (sp , th) => {
                        return new {
                            Ten = sp.Name,
                            TenTH = th.Name,
                            Gia = sp.Price
                        };
                     })
                     .OrderByDescending((a) => { return a.Gia;})
                     .ToList()
                     .ForEach((p) => {
                        Console.WriteLine($"Info : {p.Ten} {p.TenTH} {p.Gia}");
                     });
// đề tiếp theo làm bằng câu truy vấn Linq : Lấy ra sản phẩm có giá <= 500 và có màu xanh
/* b1 : Xac dinhg nguon = from ten_dulieu in ten_nguon
                          where , order by  ,..
   b2 : lay du lieu = select , groupby,...
*/ 

    Console.WriteLine("---------------------------------------------------------------------------");
    Console.WriteLine("Lay ra cac san pham co gia < 500 va co mau xanh la");
    
    var qr = from product in products
             from color in product.Colors 
             where product.Price <= 500 && color == "Xanh"
             orderby product.Price
             select new {
                Ten = product.Name,
                Gia = product.Price,
                Cacmau = product.Colors // bởi vì một sản phầm có nhiều màu và có màu xanh trong đó là được
             };

        qr.ToList().ForEach((abc) => {
            Console.WriteLine($"{abc.Ten} + {abc.Gia} + {string.Join(',' , abc.Cacmau)}");
        });


    Console.WriteLine("---------------------------------------------------------------------------");
    Console.WriteLine("Lay cac phan tu duoc nhom theo gia");
    
    var qr2 = from product in products
              group product by product.Price into gr // lưu vào biến tạm gr
              orderby gr.Key
              select gr
              ;
        qr2.ToList().ForEach((group) => {
            Console.WriteLine(group.Key);
            group.ToList().ForEach(p => Console.WriteLine(p));
        });


    Console.WriteLine("---------------------------------------------------------------------------");
    Console.WriteLine("Lay cac phan tu ket hop id va ten thuong hieu");

    var qr3 = from product in products
              join brand in brands on product.Brand equals brand.ID
              select new {
                ten = product.Name,
                gia = product.Price,
                thuonghieu = brand.Name
              };
        qr3.ToList().ForEach((pr)=> {
            Console.WriteLine($"{pr.ten,10} {pr.gia,5} {pr.thuonghieu,15}");
        });

    Console.WriteLine("---------------------------------------------------------------------------");
    Console.WriteLine("Lay ra tat ca san pham ke ca san pham khong co thuong hieu");

      var qr4 = from product in products
              join brand in brands on product.Brand equals brand.ID into t
              from b in t.DefaultIfEmpty() // nếu có thương hiệu thì trả true , không thì trả về false
              select new {
                ten = product.Name,
                gia = product.Price,
                thuonghieu = (b != null ) ? b.Name : "No Brand"
              };
        qr4.ToList().ForEach((pr)=> {
            Console.WriteLine($"{pr.ten,10} {pr.gia,5} {pr.thuonghieu,15}");
        });








        }
    }
}
