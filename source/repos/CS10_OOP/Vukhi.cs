
using System;
using System.Dynamic;
namespace Vukhi_OOP
{
    class VuKhi {
        private string name ;
        private string id ;
        // thuoc tinh -> giong setter getter
        public string Name{
            set {
                this.name = value ;
            }
            get {
                return name ;
            }
        }
        public string Id{
            set {
                this.id = value ;
            }
            get {
                return id ;
            }
        }
        // cach viet khac cua thuoc tinh : mot cach tu dong : sau dong nay thi cac thao tac su dung binh thuong
        // public string Name2{set;get;}

        // cac ham
        public VuKhi(string name , string id) {
            this.name = name;
            this.id = id;
        }
    }
}