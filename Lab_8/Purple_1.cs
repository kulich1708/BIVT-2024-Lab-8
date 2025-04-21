using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Purple_1 : Purple
    {
        private string _output;

        public string Output => _output;

        public Purple_1(string input) : base(input) { }

        public override void Review()
        {
            if (String.IsNullOrEmpty(Input)) { _output = Input; return; }

            string currentStr = "";
            bool isDigit = false;
            for (int i = 0; i < Input.Length; i++)
            {
                char curChar = Input[i];
                if (punctuation.Contains(curChar) || spaces.Contains(curChar))
                {
                    _output += new string (currentStr.Reverse().ToArray()) + curChar;
                    currentStr = "";
                    isDigit = false;

                } else if (Char.IsDigit(curChar) || isDigit)
                {
                    isDigit = true;
                    _output += curChar;
                }
                else
                {
                    currentStr += curChar;
                }
            }
        }
        public override string ToString()
        {
            return _output;
        }
    }
}
