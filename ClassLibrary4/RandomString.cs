using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary4
{
    public class RandomString
    {

        public string RandomStr()
        {
            const string src = "abcdefghijklmnopqrstuvwxyz0123456789";
            var sr = new StringBuilder();
            Random random = new Random();
            for (var i = 0; i < 10; i++)
            {
                var c = src[random.Next(0, src.Length)];
                sr.Append(c);
            }
            return sr.ToString();
        }

    }
}
