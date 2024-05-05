/*Lâp trình hướng sự kiện , tạo event với delegate và EvenHandler trong c#
*/
/*
publisher -> class - phát sự kiện
subcriber -> class - nhận sự kiện
*/
public delegate void SuKienNhap(int x);
class Dulieunhap : EventArgs { // phải khởi tạo thằng này thì mới có thể đăng kí nhập dữ liệu với publisher.
    public int data {set;get;}
    public Dulieunhap(int x) => data = x;
}
class UserInput{
    public event SuKienNhap sukiennhapso; /*khi khai báo thằng này bằng event thì nó chỉ được thực hiện 2 phương thức += hoặc -= chứ không gán riêng lẻ được =-> đảm bảo tính hướng sự kiện*/
    public event EventHandler sukiennhapso2; // ~ delegate void Kieu(object? sender , EventArgs args);
    public void Input(){
        do
        {
            Console.WriteLine("Vui Long Nhap So : ");
            string s = Console.ReadLine();
            int i = int.Parse(s);
            // phat su kien
            sukiennhapso?.Invoke(i); //gọi đến Event Handler -> thực hiện hết các đăng kí với publisher
        } while (true); // crtl + c để thoat
    }
    public void Input2(){
        do
        {
            Console.WriteLine("Vui Long Nhap So : ");
            string s = Console.ReadLine();
            int i = int.Parse(s);
            // phat su kien
            sukiennhapso2?.Invoke(this , new Dulieunhap(i)); 
        } while (true); 
    }
    
}


// subcriber với Event Handler
class TinhNhanHai{
    public void Sub(UserInput input){
        input.sukiennhapso2 += NhanDoi;
    }
    public void NhanDoi(object sender , EventArgs eventArgs){
        Dulieunhap dulieunhap = (Dulieunhap)eventArgs;
        int i = dulieunhap.data;
        Console.WriteLine($"So gap do so {i} la { i  * 2}");
    }
}
 
// subcriber
class TinhCan {
    public  void Sub(UserInput input){ // thằng nay như điểm chung chuyển / tức hàm nào muốn nhận cái input ở trên thì phải đăng kí với thằng này thì nó mới cho phép nhận vào cái input ở bên trên.
        input.sukiennhapso += Can; 
        
    }
    public void Can(int i ){
        Console.WriteLine($"Can bac 2 cua so {i} la {Math.Sqrt(i)}");
    }
}
class BinhPhuong{
     public  void Sub(UserInput input){ 
        input.sukiennhapso += TinhBinhPhuong; 
    }
    public void TinhBinhPhuong(int i ){
        Console.WriteLine($"Binh phuong cua so {i} la {(i * i)}");
    }
}
class Program{
    static void Main(string[] args){
        //publisher
        
        UserInput userInput = new UserInput();
        // userInput.sukiennhapso += (int x) =>{// them bieu thuc lambda
        //     Console.WriteLine("So vua nhap la : " + x);
        // }; 
        // TinhCan tinhCan = new TinhCan();
        // tinhCan.Sub(userInput);
        // BinhPhuong binhPhuong = new BinhPhuong();
        // binhPhuong.Sub(userInput);


        // bieu thuc lambda voi event handler
        userInput.sukiennhapso2 += (sender , e) => {
            Dulieunhap dulieunhap = (Dulieunhap)e;
            Console.WriteLine("Du lieu vua nhap la " + dulieunhap.data);
        };
        TinhNhanHai tinhNhanHai = new TinhNhanHai();
        tinhNhanHai.Sub(userInput);
        userInput.Input2();
        
    }
}