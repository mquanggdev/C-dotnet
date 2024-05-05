using System;

namespace MyConsoleApp
{
    class Program
    {
        static void Main()
        {
           // queue : Enqueue -> thêm phần tử vào cuối và lấy ra từ đầu bằng Dequeue;
           Queue<string> queueEx = new Queue<string>();
           queueEx.Enqueue("mathang1");
           queueEx.Enqueue("mathang2");
           queueEx.Dequeue();
           Stack<int> stackEx = new Stack<int>();
           stackEx.Push(1);
           stackEx.Push(2);
           stackEx.Push(3);
           stackEx.Pop(); 


           LinkedList<string> cacbaihoc = new LinkedList<string>();
           var bh1 = cacbaihoc.AddFirst("Bai hoc 1");    // cái mà linkedList trả về nó là LinkeListNode
           var bh3 = cacbaihoc.AddLast("Bai hoc 3");
           var bh2 = cacbaihoc.AddAfter(bh1 , "Bai Hoc 2"); // thêm vào sau bh1 
           var bh0 = cacbaihoc.AddBefore(bh1 , "Bai hoc 0"); // thêm vào trước
           cacbaihoc.AddLast("Bai Hoc cuoi cung");

           foreach (var item in cacbaihoc)
           {
            Console.WriteLine(item);
           }

           var node = bh2;
           node = node.Next; // lấy ra phần tử tiếp theo
           node = node.Previous ; // lấy về phần tử phía trước 
        }
    }
}
