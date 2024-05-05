using System;

namespace ExtensionMethod
{
    static class MyExtension
    {
        public static int LuyThua(this int x ) => x * x ; // ~ return x * x
        public static double TinhCan(this int x ) => Math.Sqrt(x) ;

        
    }
}
