using System;

namespace DelegateSample
{
    //自定义委托Reverse
    public delegate string Reverse(string s, int w);

    //使用泛型的自定义委托
    public delegate U Reverse<in T,in R,out U>(T s,R w);

    /// <summary>
    /// 定义stringProcessing类，包含静态方法ReverseString
    /// 和一个实例方法ReverseString2
    /// </summary>
    public class stringProcessing
    {
        public static string ReverseString(string s, int w)
        {
            return s + w.ToString()+1;
        }
        public string ReverseString2(string s, int w)
        {
            return s + w.ToString()+2;
        }
    }

    //使用自定为委托的测试
    class Program
    {
        static void Main(string[] args)
        {
            //使用静态方法完成委托
            //Reverse rev = stringProcessing.ReverseString;
            //使用泛型委托的实现代码
            Reverse<string ,int,string> rev = stringProcessing.ReverseString;
            Console.WriteLine(rev("a string", 10));

            //使用实例方法完成委托
            //stringProcessing sp = new stringProcessing();
            //rev += sp.ReverseString2;
            //Console.WriteLine(rev("a string", 10));
        }
    }

    //使用强类型委托
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        //定义Func委托
    //        Func<string, int, string> rev;

    //        //使用静态方法完成委托
    //        rev = stringProcessing.ReverseString;
    //        Console.WriteLine(rev("a string", 10));

    //        //使用实例方法完成委托
    //        stringProcessing sp = new stringProcessing();
    //        rev += sp.ReverseString2;
    //        Console.WriteLine(rev("a string", 10));
    //    }
    //}


}