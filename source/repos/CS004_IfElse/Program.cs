// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
int a ; 
a = int.Parse(Console.ReadLine());
if ( a % 2 == 0 ){
    Console.WriteLine("a la so chan!");
}
else {
    Console.WriteLine("a la so le !");
}

// toan tu 3 ngoi
int b , c ;
Console.WriteLine("Nhap hai so b va c:");
b = int.Parse(Console.ReadLine());
c = int.Parse(Console.ReadLine());
int max = b > c ? b : c ; // toan tu 3 ngoi
Console.WriteLine($"So lon nhat trong hai so b va c la {max}");

// cau truc swith case 
Console.Clear();

int abc ;
Console.WriteLine("Nhap a :");
abc = int.Parse(Console.ReadLine());
switch(abc){
    case 1: 
          Console.WriteLine("a bang 1");
          break;
    case 2:
          Console.WriteLine("a bang 2");
          break; 
    default:
          Console.WriteLine("so a khong hop le !");
          break; 
}

// mot bieu mau menu don gian 
Console.Clear();

int m , n;
Console.WriteLine("Nhap so m va so n :");
m = int.Parse(Console.ReadLine());
n = int.Parse(Console.ReadLine());

Console.WriteLine("hay nhap lenh!");
Console.WriteLine("1 : tinh tong");
Console.WriteLine("2 : tinh hieu");
Console.WriteLine("3 : tinh nhan");
Console.WriteLine("4 : tinh chia");

char ccc ;
l1: // can co nhan nay thi lenh goto moi hoat dong!
ccc = Console.ReadKey().KeyChar; // doc lay mot ky tu duoc nhap vao tu ban phim ;
switch(ccc){
    case '1' : 
       Console.WriteLine("Phep cong " + (m + n));
       break;
    case '2' :
       Console.WriteLine("Phep tru " + (m - n));
       break;
    case '3' :
       Console.WriteLine("Phep nhan " + (m * n));
       break;
    case '4' :
       Console.WriteLine("Phep chia " + (m / n));
       break;
    default :
       Console.WriteLine("Phep tinh khong hop le!");
       goto l1; // quay lai switch
       break;
}



