using System;
using System.Net.NetworkInformation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace CS031
{
    // Dependency injection : một class là phụ thuộc của class kia khi mà class kia hoạt động được khi có class này
    // Thay vì sử dụng trực tiếp khai báo cứng class dữ liệu và dùng nó để tham chiếu thì ta sẽ tham chiếu qua interface -> khi tham chiếu nó sẽ tham chiếu đến interface chứa nó
    // cách dùng interface thì khi thực thi thì thằng được phụ thuộc sẽ có thể lấy bất kỳ một lớp nào được triển khai bởi interface đó
interface IClassB{
    public void ActionB();
}
interface IClassC{
    public void ActionC();
}
class ClassC : IClassC{
    public ClassC() => Console.WriteLine("ClassC is created");
    public void ActionC() => Console.WriteLine("Action in ClassC");
}

class ClassB:IClassB {
    // Phụ thuộc của ClassB là ClassC
    IClassC c_dependency;

    public ClassB(IClassC classc) { c_dependency = classc; 
    Console.WriteLine("ClassB is created");
    }// khi mà tạo classB với tham số truyền vào là ClassC thì nó sẽ gán classC = c_dependency => không khác gì nó tự động khởi tạo ra ClassC

    public void ActionB()
    {
        Console.WriteLine("Action in ClassB");
        c_dependency.ActionC();
        // khi mà gọi đến Acction B thì nó cũng sẽ gọi luôn Acction C -
    }
}

class ClassA {
    // Phụ thuộc của ClassA là ClassB
    IClassB b_dependency;

    public ClassA(IClassB classb) { b_dependency = classb;
    Console.WriteLine("ClassA is created");
    }
    public void ActionA()
    {
        Console.WriteLine("Action in ClassA");
        b_dependency.ActionB();
    }
}
// ví dụ về thêm một class khác thuộc interface
class ClassC1 : IClassC
{
    public ClassC1() => Console.WriteLine ("ClassC1 is created");
    public void ActionC()
    {
        Console.WriteLine("Action in C1");
    }
}

class ClassB1 : IClassB
{
    IClassC c_dependency;
    public ClassB1(IClassC classc)
    {
        c_dependency = classc;
        Console.WriteLine("ClassB1 is created");
    }
    public void ActionB()
    {
        Console.WriteLine("Action in B1");
        c_dependency.ActionC();
    }
}





// Các phụ thuộc mà được khởi tạo bên trong class được phụ thuộc thì sẽ không còn tính linh hoạt : ví dụ như muốn thay đổi class Horn với một tham số là độ lớn tiếng còi thì Song song vào đó ta cũng phải thay đổi bên trong class Car => rất tốn thời gian : Để giải quyết thì ta dùng depnendency injection
/* đây là code ko sử dụng di
// class Horn {
//     public void Beep(){
//         Console.WriteLine("Beep");
//     }
// }
// class Car {
//     public void Beep(){
//         Horn horn = new Horn();
//     }
// }*/
public class Horn {
    int level; // thêm độ lớn còi xe
    public Horn (int level) => this.level = level; // thêm khởi tạo level

    public void Beep () => Console.WriteLine ("Beep - beep - beep ...");
}

public class Car {
    // horn là một Dependecy của Car
    Horn horn;

    // dependency Horn được đưa vào Car qua hàm khởi tạo
    public Car(Horn horn) => this.horn = horn;

    public void Beep () {
        // Sử dụng Dependecy đã được Inject
        horn.Beep ();
    }
}
public class MyService
{
    public string data1{set;get;}
    public int data2{set;get;}
    public void PrintData() => Console.WriteLine($"{data1}/{data2}");
    public MyService( IOptions<MyServiceOptions> options){
        var _options = options.Value;
        data1 = _options.data1;
        data2 = _options.data2;
    }
} 
public class MyServiceOptions{
    public string data1{set;get;}
    public int data2{set;get;}
    
}
    class Program
    {
        static void Main()
        {
            /*IClassC objectC = new ClassC1();
            IClassB objectB = new ClassB1(objectC);
            ClassA objectA = new ClassA(objectB);
            objectA.ActionA();*/
            /*
            DI Container 
            - đăng ký các dịch vụ (các lớp)
            - ServiceProvider -> Get Service 
               + Scoped : một bản thực thi sẽ được tạo bên trong 1 phạm vi nhất định
               + Singleton : Duy nhất một bản thực thi được tạo ra cho hết vòng đời của ServiceProvider
               + Transient  : Một phiên bản của dịch vụ được tạo ra mỗi khi được yêu cầu
            */
            /*
            var  services = new ServiceCollection();
            // đăng ký dịch vụ (IClassC , ClassC , ClassC1)
            services.AddSingleton<IClassC,ClassC>();// tham số 1 : tên dịch vụ , Tham số 2 : là kiểu sẽ tạo ra đối tượng dịch vụ sẽ tham chiếu đến tên dịch vụ
            var provider = services.BuildServiceProvider();
            var a = provider.GetService<IClassC>();
            */
            // tạo tự động và inject(đẩy,tiêm) vào dịch vụ 
            /*var  services = new ServiceCollection();
            services.AddSingleton<ClassA,ClassA>(); // khi cái này được tạo thì nó cũng sẽ tự động tạo ra IclassB tương tự với iClass C
            services.AddSingleton<IClassB,ClassB>();
            services.AddSingleton<IClassC,ClassC1>();
            var provider = services.BuildServiceProvider();
            ClassA a = provider.GetService<ClassA>(); // lấy ra dịch vụ của kiểu class a
            a.ActionA();*/
            // đăng ký dịch vụ với Delegate
            /*
                services.AddSingleton<ServiceType>((IServiceProvider provider) => {
                    //các chỉ thị
                    // ...
                    return (đối tượng kiểu ImplementationType);
                });
            */


            // lưu ý MyServiceOption không phải một inject;
            /**
            var services = new ServiceCollection();//Bằng cách khai báo như này trong ServiceCollection sẽ có 2 hệ thông : 1 là chứa các dependency và một cái chứa các options
            services.AddSingleton<MyService>(); // khi Myservice được khởi tạo , do trong khai báo có sử dụng Ioption thì nó sẽ tự động tìm trong hệ thống có option nào có kiểu MyServiceOptions thì nó lấy ra và inject vào myserviceoption.
            services.Configure<MyServiceOptions>( 
                (MyServiceOptions options) => {
                    options.data1 = "Xin Chao Cac Ban!" ;
                    options.data2 = 2021 ;
                }
            );
            var provider = services.BuildServiceProvider();
            var myservice = provider.GetService<MyService>();
            myservice.PrintData();*/



            // Nap cau hinh tu file 
            ConfigurationRoot configurationRoot ;

            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.SetBasePath(Directory.GetCurrentDirectory());
            configurationBuilder.AddJsonFile("cauhinh.json");
             configurationRoot = (ConfigurationRoot)configurationBuilder.Build();
            //  var key1 = configurationRoot.GetSection("section1").GetSection("key1").Value;
             
            //  var data1 = configurationRoot.GetSection("MyServicOptions").GetSection("data1").Value;
            //  Console.WriteLine(data1);

            var sectionMyServiceOptions = configurationRoot.GetSection("MyServiceOptions");

            var services = new ServiceCollection();
            services.AddSingleton<MyService>();     
            services.Configure<MyServiceOptions>( 
                (sectionMyServiceOptions)
            );
            var provider = services.BuildServiceProvider();
            var myservice = provider.GetService<MyService>();
            myservice.PrintData();
        }
    }
}
