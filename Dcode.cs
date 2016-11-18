using System;
using System.IO;
using System.Net;
using System.Text;

namespace codedecode
{
    public class Dcode
    {
        public Dcode()
        {
            string temp = Convert.ToBase64String(Encoding.UTF8.GetBytes(dateTostring()));
            Console.WriteLine("程序内的动态密码："+temp);
        }
        public bool check(string code)
        {
            string temp=Convert.ToBase64String(Encoding.UTF8.GetBytes(dateTostring()));
            if (!code.Equals(temp))
                return false;
            return true;
        }
        private string dateTostring()
        {
            NistTime n = new NistTime();
            string str = n.GetNowTime().ToString();
            string num = null;
            foreach (char item in str)
            {
                if (item >= 48 && item <= 58)
                {
                    num += item;
                }
            }
            char[] s = num.ToCharArray();
            s[s.Length - 1] = '0';
            s[s.Length - 2] = '0';
            string end = new string(s).Replace(":", "").Trim();
            return end;
        }
    }
}