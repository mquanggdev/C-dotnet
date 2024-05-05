using System;
using System.Drawing;
namespace MyConsoleApp
{
    class Program
    {
        static void DoSomething ( int second , string msg , ConsoleColor consoleColor){
            
             lock(Console.Out)
                {
                    Console.ForegroundColor = consoleColor ;
                    Console.WriteLine ($"{msg,10} .. Start");
                    Console.ResetColor() ;
                }

            // string a = "C# Html Css";
            // lock(a){ // no se khoa lai chi cho thread hien tai su dung va cac thread khac khong the truy cap den

            // }
        
            for (int i = 0; i <= second; i++)
            {
                lock(Console.Out) 
                {
                    Console.ForegroundColor = consoleColor ;
                    Console.WriteLine($"{msg , 10} {i , 2 }");
                    Console.ResetColor();
                }

                Thread.Sleep(1000) ; // chuong trinh se dung lai 1s
            }

            lock(Console.Out)
                {
                    Console.ForegroundColor = consoleColor ;
                    Console.WriteLine ($"{msg,10} .. End");
                    Console.ResetColor() ;
                }
        }
        // asynchronus (multithread) - synchronous;
        static void Example_synchronous(){
            DoSomething(5,"T1",ConsoleColor.Green);
            DoSomething(7,"ACD",ConsoleColor.Blue);
            DoSomething(8,"T3",ConsoleColor.Red);
        }  

        static Task Task2(){
            Task t2 = new Task(
                () => {
                    DoSomething(7,"T2",ConsoleColor.Blue);
                }
            );
            t2.Start();

            t2.Wait();
            Console.WriteLine("T2 da hoan thanh");

            return t2;
        }
        static Task Task3(){
            Task t3 = new Task(
                (object ob) => {
                    string tentacvu = (string)ob;
                    DoSomething(8,tentacvu,ConsoleColor.Red);
            },"T3"); // lay T3 gan vao ob roi chuyen cai ob do thanh chuoi ;

            t3.Wait(); // nếu thêm dòng này thì nó sẽ phá vỡ bất đồng bộ vì nó sẽ bắt cái task này phải chạy xong thì mới cho phép các task sau nó được chạy
            Console.WriteLine("T3 da hoan thanh");

            return t3;
        }
        // dùng async và await
        static async Task Task2D(){
            Task t2 = new Task(
                () => {
                    DoSomething(7,"T2",ConsoleColor.Blue);
                }
            );
            t2.Start();

            await t2; // những dòng code sau từ này chỉ được thực hiện khi t2 được hoàn thành
            Console.WriteLine("T2 da hoan thanh");
        }
        static async Task Task3D(){
            Task t3 = new Task(
                (object ob) => {
                    string tentacvu = (string)ob;
                    DoSomething(8,tentacvu,ConsoleColor.Red);
            },"T3"); 
            t3.Start();
            await t3;
            Console.WriteLine("T3 da hoan thanh");
        }
        static  Task<string> Task4(){
            Task<string> t4 = new Task<string>(()=>{
                DoSomething(4,"T4",ConsoleColor.Red);
                return "Return from t4";
            });
            t4.Start();
            return t4;
        }
        static  Task<string> Task5(){
            Task<string> t5 = new Task<string>((object ob)=>{
                string t = (string)ob;
                DoSomething(5,t,ConsoleColor.Blue);
                return $"Return from {t}";
            },"T5");
            t5.Start();
            return t5;
        }
        //____________________________________________________________________________//

        static void Main()
        {
            // Task t2 = Task2();
            // Task t3 = Task3();
            //// Task t2d = Task2D();
            //// Task t3d = Task3D();
            //// DoSomething(5,"T1",ConsoleColor.Green);
            //// Task.WaitAll(t2d,t3d);
            Task<string> t4 = Task4();
            Task<string> t5 = Task5();
            DoSomething(6,"T1",ConsoleColor.Green);
            Task.WaitAll(t4,t5);
            Console.WriteLine("Hello C#");
        }
    }
}
