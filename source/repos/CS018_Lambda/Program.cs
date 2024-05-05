// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Action<string> thongbao;
 thongbao = (string s) => Console.WriteLine(s); // ~ delegate void kieu(string) = Action<string> 
 thongbao?.Invoke("Xin Chao");

Action<string,string> ThongBao;
ThongBao = (string name , string id ) => Console.WriteLine(name + " " + id);
ThongBao?.Invoke("Quang","001");

Func<int,int,int> func;

 func = (int a , int b) => {
    int kq = a + b ;
    return kq;
};

Console.WriteLine("Ban co so tuoi la " + func(10,10));

Console.Clear();

//** Một số ví dụ về sử dụng biểu thức lambda trong thư viên C#

int[] array = {2,4,6,3,7,22,55,77,34,332,21}; 

var ketqua = array.Select((int x) => { // Select dùng để thực hiện một loạt các biến đổi trên mỗi phần tử trong collection -> nó thuộc về Linq ; -> dùng với func -> có trả về
    return Math.Sqrt(x);
});
foreach (var item in ketqua){
    Console.WriteLine(item + " ");
}
Console.Clear();

array.ToList().ForEach((int x)=>{ // nó được sử dụng kết hợp  với ToList() để chuyển mảng sang danh sách rồi sau đó ForEach dùng để tìm kiếm ( ForEach là phương thức của danh sách List) . và list dùng với action -> không có trả về
    if (x % 2 == 0){
        Console.WriteLine(x + " la so chan");
    }
});

Console.Clear();
var Chiahet = array.Where((int x) => { // dùng để kiểm tra một điều kiện
    return x % 4 == 0; // trả về true or false
});
foreach (var item in Chiahet)
{
    Console.WriteLine(item);
}