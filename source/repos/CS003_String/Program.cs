// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

string a = "Hello C#";
Console.WriteLine("Do dai cua a la : " + a.Length);
Console.WriteLine("Xau a sau khi viet hoa la : " + a.ToUpper());
Console.WriteLine("Xau a sau khi viet thuong la : " + a.ToLower());
string b = "Va Java";
Console.WriteLine($" C1 : Hai xau a va b sau khi ghep la : {a + " "+ b}");
Console.WriteLine(" C2 : Su dung ham concat() :" + string.Concat(a,b));

Console.Clear();
// Char trong String

Console.WriteLine("Ky tu thu nhat cua xau a la : " + a[0]);
Console.WriteLine("Ky tu e trong xau a nam o vi tri  : " + a.IndexOf('e')); // lay ra vi tri cua phan tu
Console.WriteLine("Chuoi sau khi cat chuoi C# la : " + a.Substring(a.IndexOf("C"))); // lay gai tri tu vi tri cua C# gan vao bien a ;
Console.WriteLine("In chuoi co ky tu dac biet \"Vikings\" ");
Console.WriteLine("Muon xuong dong dung \n ");
Console.WriteLine("Muon tag ra mot cai dung \t abc");



