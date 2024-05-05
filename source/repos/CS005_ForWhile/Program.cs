// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
// While 

int i = 5 ;
while(i > 0){
    Console.WriteLine("The value of i is {0}", i);
    i--;
} 
Console.Clear();
// do while
do {
    ++i;
    Console.WriteLine(i);
}
while( i < 10);
Console.WriteLine("Value of i after the loop: {0}", i);
Console.Clear();

// for 

for ( int j = 1 ; j <= 10 ; j++ ){
    Console.WriteLine(j);
}
Console.Clear();
int a;
for( a = 1 ,Console.WriteLine("Khoi tao a") ; a <= 5 ; a++,Console.WriteLine("Doi voi a = ")){
    Console.WriteLine("Index a :" + a) ;
    for ( int b = 1 ; b <= 5 ; b++){
        Console.WriteLine(" \t Index b :" + b) ;
    }
}
// neu dung break thi thoat vong lap 
// neu gap continue thi no se chuyen qua vong lap tiep theo ma khong thuc hien cac cau lenh dang sau continue

// foreach
Console.Clear();
string[] s = { "a" , "b" , "c"};
foreach(string it in s){
    Console.WriteLine(it);
}