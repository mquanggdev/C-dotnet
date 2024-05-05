// See https://aka.ms/new-console-template for more information
using System.Globalization;
using System.Text;

string a = "Say Hello";
string b = "C#";
string mess = string.Concat(a,b) ;// noi chuoi hoac a + b ;
string c = "\\chen them ky tu dac biet \"Tauraus\" abc";
string d = @"abc "" xyx "" ! * % # "; // thang nay duoc them vao truoc dau "" de viet text!-> cai nay tien loi hon
int number = 2 ;
string e = $"day la so {number ,2}"; // thnag nay thi de chen bien vao chuoi! , cai so 2 là cách ra 2 lần rồi mới in number .
string f = "     Xin Chao C#    ";
f = f.Trim(); // loại bỏ đi các khoảng trắng ở đầu và ở cuối , nếu thêm dấu * chẳng hạn thì nếu mà chuỗi có các dấu * ở đầu hoặc cuối thì nó sẽ xóa đi các dấu * đó
f = f.ToUpper(); // chuyen chu in hoa
f = f.ToLower(); // chuyen chu in thuong
string g = "Xin Chao C#";
g = g.Replace("Xin Chao" , "Hello"); // tìm kiếm chuỗi Xin Chao và thay thế bằng Hello;
g = g.Insert(0,"UD "); // chèn UD vào vị trí 0 trong chuỗi.
string h = g.Substring(3 , 2); // lấy ra cái chuỗi 2 ký tự từ vị trí thứ 3! nếu muốn lấy ra một vài ký tự thôi thì điền thêm tham số thứ 2
string k = g.Remove(3,3) ;// xóa đi 3 ký tự từ vị trí 3 ;
string[] arraySplitString = g.Split(' '); // chia cái chuỗi thành cách chuỗi con theo khoảng trắng rồi đẩy vào array
string l = string.Join(' ',arraySplitString); // thằng này thì lại nối chuỗi con của 1 mảng theo khoảng trắng rồi gán vào l



StringBuilder newString = new StringBuilder(); // nên dùng thằng này 
newString.Append("Xin Chao C#"); // nối chuỗi
newString.Replace("Xin Chao","Hello") ;
newString.Clear(); //xóa toàn bộ chuỗi
string sdk = newString.ToString(); //chuyển sang chuỗi thông thường có 1 lần thôi chứ không như chuỗi thông thường
Console.WriteLine(sdk);