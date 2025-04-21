using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public abstract class Purple
    {
        private string _input;
        protected static char[] punctuation = ['.', '!', '?', ',', ':', '\"', ';', '–', '(', ')', '[', ']', '{', '}', '/'];
        protected static char[] stringEnd = ['.', '!', '?'];
        protected static char[] spaces = [' '];
        protected static int[] numbers = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9];

        public string Input => _input;

        public Purple(string input) { _input = input; }

        public abstract void Review();
    }
}
