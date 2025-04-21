using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Purple_2 : Purple
    {
        private string[] _output;
        private static readonly int targetLength = 50;
        private string[] _words;

        public string[] Output => (string[])_output.Clone();

        public Purple_2(string input) : base(input) { }

        public override void Review()
        {

            string[] words = Input.Split(" ");
            _words = words;
            _output = new string[words.Length];

            int numberOfWordsInCurrentStr = 0;
            int numberOfSymbolsInCurrentStr = 0;
            int numberOfFirstWordInCurrentStr = 0;
            int linesIndex = 0;
            for (int i = 0; i < words.Length; i++)
            {
                if (numberOfSymbolsInCurrentStr + words[i].Length <= targetLength)
                {
                    numberOfSymbolsInCurrentStr += words[i].Length + 1;
                    numberOfWordsInCurrentStr++;
                }
                else
                {
                    _output[linesIndex] = GenerateLine(numberOfSymbolsInCurrentStr, numberOfWordsInCurrentStr, numberOfFirstWordInCurrentStr);
                    linesIndex++;
                    numberOfFirstWordInCurrentStr += numberOfWordsInCurrentStr;
                    numberOfSymbolsInCurrentStr = words[i].Length + 1;
                    numberOfWordsInCurrentStr = 1;
                }
            }
            _output[linesIndex] = GenerateLine(numberOfSymbolsInCurrentStr, numberOfWordsInCurrentStr, numberOfFirstWordInCurrentStr);
            Array.Resize(ref _output, linesIndex + 1);
        }
        private string GenerateLine(int numberOfSymbolsInCurrentStr, int numberOfWordsInCurrentStr, int numberOfFirstWordInCurrentStr)
        {
            if (numberOfWordsInCurrentStr == 1) return _words[numberOfFirstWordInCurrentStr];
            double newSpacesNumber = (double)(targetLength - numberOfSymbolsInCurrentStr + 1) / (numberOfWordsInCurrentStr - 1);
            int numberOfSymbolsInBigSpace = (int)Math.Ceiling(newSpacesNumber) + 1;
            int numberOfSymbolsInSmallSpace = newSpacesNumber + 1 == numberOfSymbolsInBigSpace ? numberOfSymbolsInBigSpace : numberOfSymbolsInBigSpace - 1;
            int numberOfLargeSpaces = (targetLength - numberOfSymbolsInCurrentStr + 1) % (numberOfWordsInCurrentStr - 1);

            string result = String.Join(new string(' ', numberOfSymbolsInBigSpace), _words
                .Skip(numberOfFirstWordInCurrentStr)
                .Take(numberOfLargeSpaces + 1))
                + new string(' ', numberOfSymbolsInSmallSpace)
                + String.Join(new string(' ', numberOfSymbolsInSmallSpace), _words
                .Skip(numberOfFirstWordInCurrentStr + numberOfLargeSpaces + 1)
                .Take(numberOfWordsInCurrentStr - numberOfLargeSpaces - 1));
            return result;
        }
        public override string ToString()
        {
            if (_output == null) return null;

            return String.Join('\n', _output);
        }
    }
}
