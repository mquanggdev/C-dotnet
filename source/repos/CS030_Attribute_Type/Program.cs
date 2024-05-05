using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
namespace CS030
{
    // đơn giản là thằng attribute sinh ra để không làm thay đổi hành vi của chương trình , nhiệm vụ chinnhs là thêm các mô tả cho lớp , phương thức , hay thuộc tính 
    /// <summary>
    /// type -> class , struct  , .. int ,bool ..
    /// Attribute 
    /// Reflection : thong tin kieu du lieu , thoi diem thuc thi
    /// Atrribute name  ;
    /// </summary>
    /*
    Mota 
    thongtinchitiet
    */
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property)] // có thể áp dụng cho lớp , phương thức và thuộc tính
    class MotaAttribute:Attribute{
        public string thongtinchitiet{set;get;}
        public MotaAttribute(string thongtinchitiet){
            this.thongtinchitiet = thongtinchitiet ;
        }
    }
    class Program
    {
        [Mota("Lop chua thong tin tren he thong ")]
        
        class User {
            [Mota("Ten nguoi dung")]
            [Required(ErrorMessage = "Ten phai duoc dien day du" )]
            [StringLength(50,MinimumLength = 3 , ErrorMessage = "ten phai dai tu 3 den 100 ky tu")]
            public string Name{set;get;}
            [Mota("Tuoi nguoi dung")]
            [Range(18 , 80 ,ErrorMessage = "Ten phai tu 18 -> 80")]
            public int Age{set;get;}
            [Obsolete("Phuong thuc nay khong ne su dung can thay boi ShowInfo")] // cảnh báo phướng thức bên dưới bị lỗi thời
            public void printInfo() => Console.WriteLine(Name);
        }
        static void Main()
        {
            User user = new User(){
                Name = "Quang", // neu bang null no se hien thi cai erorrMessage da cai ben tren
                Age = 20 
            };
            // var properties = user.GetType().GetProperties();    
            // foreach (PropertyInfo property in properties)
            // {
            //     foreach (var attr in property.GetCustomAttributes(false))
            //     {
            //         MotaAttribute mota = attr as MotaAttribute ;
            //         if ( mota != null){
            //             Console.WriteLine(mota.thongtinchitiet);    
            //             var value = property.GetValue(user) ;
            //             var name = property.Name; 

            //             Console.WriteLine($"({name}) - {mota.thongtinchitiet} :{value} ");
            //         }
            //     }
            // }
            ValidationContext context = new ValidationContext(user) ;
            var result = new List<ValidationResult> () ;
            bool kq = Validator.TryValidateObject(user , context , result , true) ; // nếu cái này bằng true thì tất cả các trường đều hoạt động còn nếu trả về false thì những lỗi sai sẽ được trả vào result
            if ( kq == false){
                result.ToList().ForEach((er) => {
                    Console.WriteLine(er.MemberNames.First());
                    Console.WriteLine(er.ErrorMessage) ;
                });
            }
        }
    }
}
