namespace SanPham{
    public partial class Product { // thêm từ khóa partial để biết là nó là một phần nhỏ của namespace.
        public string Name{set;get;}
        public decimal Price{set;get;}
        public void GetInfo(){
            Console.WriteLine($"Name {Name} Price {Price} Discription {discription}");
        }
    }
}