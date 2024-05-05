// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
// Cac phep toan trong c#
int a = 10 ;
int b = 5 ;
Console.WriteLine("a + b = {0}", a + b);
Console.WriteLine("a - b = {0}", a - b);
Console.WriteLine("a * b = {0}", a * b);
Console.WriteLine("a / b = {0}", a / b);
Console.WriteLine("a % b = {0}" ,a % b);
Console.WriteLine("a % b = {0}" ,a % b);
// cac phep toan so sanh
Console.Clear();
bool ketqua = a == b;
Console.WriteLine("a == b ==> {0}",ketqua);
Console.WriteLine($"a > b ==> {a > b}"); // cach viet khac la them $ o dau day vaf viet thang ket qua vao dau {} ;
Console.WriteLine($"a < b ==> {a < b}");
Console.WriteLine($"a >= b ==> {a >= b}");
Console.WriteLine($"a <= b ==> {a <= b}");
Console.WriteLine($"a != b ==> {a != b}");
// cac toan hang " && || !"
Console.Clear();

bool ab = true ;
bool cd = false;

Console.WriteLine($"ab && cd {ab && cd}"); // ca 2 cai true -> true
Console.WriteLine($"ab || cd {ab || cd}"); // 1 trong 2 cai true -> true
Console.WriteLine($"ab , cd {!ab} , {!cd}"); // phu dinh lai!

// cac phep tim max min , tri tuyet doi , lam tron so !

Console.Clear();

Console.WriteLine($"gia tri lon nhat giua a va b la {Math.Max(a,b)}");
Console.WriteLine($"gia tri nho nhat giua a va b la {Math.Min(a,b)}");
Console.WriteLine($"gia tri tuyet doi cua a - b la {Math.Abs(a - b)}");
double c = 9.99;
Console.WriteLine($"gia tri sau khi lam tron c la {Math.Round(c)}");

