using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Purple_4 : Purple
    {
        private string _output;
        private (string, char)[] _codes;

        public string Output => _output;

        public Purple_4(string input, (string, char)[] codes) : base(input)
        {
            _codes = codes;
        }
        public override void Review()
        {
            if (_codes == null) return;
            _output = Input;
            foreach (var code in _codes)
                _output = Output.Replace(code.Item2.ToString(), code.Item1);
        }
        public override string ToString()
        {
            return _output;
        }
    }
}
