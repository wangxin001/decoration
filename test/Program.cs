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

            //System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("^1\\d{10}$");

            //Console.Write("请输入手机号码");
            //string count = Console.ReadLine();
            //Console.Write("格式是否正确" + regex.IsMatch(count));
            //Console.Read();
            //string m = "小营路17号附近医院撒旦法萨达飞的撒飞";
            //string location = m.Substring(0,m.IndexOf("附近"));
            //Console.WriteLine("location" + location + m.IndexOf("附近"));
            //string param = m.Substring(m.IndexOf("附近")+2);
            //Console.WriteLine(param);
            //Console.Read();
            string content = "sdfsdf附近";
            Console.WriteLine(content.Substring(content.Length -2));
            Console.Write(content.Substring(content.Length - 2).Equals("附近"));
            Console.Read();
        }
    }
}
