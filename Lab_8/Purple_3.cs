using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Purple_3 : Purple
    {
        private string _output;

        public string Output => _output;
        public (string, char)[] Codes { get; private set; } = new (string, char)[5];

        public Purple_3(string input) : base(input) { }

        public override void Review()
        {
            _output = Input;
            if (String.IsNullOrEmpty(Input)) return;
            string[] pairs = new string[Input.Length];
            int[] counts = new int[Input.Length];
            int lastIndex = 0;
            bool[] ASCII = new bool[95];

            for (int i = 0; i < Input.Length - 1; i++)
            {
                char a = Input[i];
                char b = Input[i + 1];
                if (Char.IsLetter(a) && Char.IsLetter(b))
                {
                    int targetIndex = Array.IndexOf(pairs, a.ToString() + b.ToString());
                    if (targetIndex == -1)
                    {
                        pairs[lastIndex] = a.ToString() + b.ToString();
                        counts[lastIndex] = 1;
                        lastIndex++;
                    }
                    else
                        counts[targetIndex]++;
                }

                if (a >= 32 && a <= 126) ASCII[a - 32] = true;
            }

            int symbolIndex = 0;
            for (int i = 0; i < 5; i++)
            {
                symbolIndex = Array.IndexOf(ASCII, false, symbolIndex);
                if (symbolIndex == -1 || symbolIndex > 126) return;

                char symbol = (char)(32 + symbolIndex);
                int max = counts[0];
                int maxIndex = 0;

                for (int j = 0; j < lastIndex; j++)
                {
                    if (counts[j] > max)
                    {
                        max = counts[j];
                        maxIndex = j;            
                    }
                }

                Codes[i] = (pairs[maxIndex], symbol);
                _output = Output.Replace(Codes[i].Item1, Codes[i].Item2.ToString());
                counts[maxIndex] = 0;
                symbolIndex++;
            }
        }
        public override string ToString()
        {
            return _output;
        }
    }
}
