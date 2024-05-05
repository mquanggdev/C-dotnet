using System;
namespace CS016_Inteface{
    interface IHinhHoc{
        public int DienTich();
        public int ChuVi();
    }

    class HinhChuNhat : IHinhHoc{
        public int a {set;get;} 
        public int b {set;get;}
        public HinhChuNhat(int a , int b){
            this.a = a ;
            this.b = b ;
        }

        public int ChuVi()
        {
            return (a + b) * 2 ;
        }

        public int DienTich()
        {
            return a * b ; 
        }
    }
}