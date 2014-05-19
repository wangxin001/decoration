using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Web;
namespace test
{
    class Program
    {
        public enum Process
        {
            a=1,
            b,c,d
        }
        public void show()
        {

        }
        static void Main(string[] args)
        {

           // System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"(1[3,5,7,8,9][0-9]{8})");

            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("^1\\d{10}$");

            Console.Write("请输入手机号码");
            string count = Console.ReadLine();
            Console.Write("格式是否正确" + regex.IsMatch(count));
            Console.Read();
        }
    }
}
