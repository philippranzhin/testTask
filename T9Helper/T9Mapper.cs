using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T9Helper
{
    public class T9Mapper
    {
        private const int AlphabetSize = 27;

        private Dictionary<char, string> map;

        private void GenerateMap()
        {
            var map = new Dictionary<char, string>(AlphabetSize);

            map.Add('a', "2");
            map.Add('b', "22");
            map.Add('c', "222");

            map.Add('d', "3");
            map.Add('e', "33");
            map.Add('f', "333");

            map.Add('g', "4");
            map.Add('h', "44");
            map.Add('i', "444");

            map.Add('j', "5");
            map.Add('k', "55");
            map.Add('l', "555");

            map.Add('m', "6");
            map.Add('n', "66");
            map.Add('o', "666");

            map.Add('p', "7");
            map.Add('q', "77");
            map.Add('r', "777");
            map.Add('s', "7777");

            map.Add('t', "8");
            map.Add('u', "88");
            map.Add('v', "888");

            map.Add('w', "9");
            map.Add('x', "99");
            map.Add('y', "999");
            map.Add('z', "9999");

            map.Add(' ', "0");

            this.map = map;
        }

        public T9Mapper()
        {
            this.GenerateMap(); 
        }

        public bool Contains(string data)
        {
            foreach(char symbol in data)
            {
                if(!this.map.ContainsKey(symbol))
                {
                    return false;
                }
            }

            return true ;
        }

        public string Map(string data)
        {
            var result = new StringBuilder();
            char? lastSymbol = null;

            foreach (char symbol in data)
            {
                if (this.map.TryGetValue(symbol, out string value))
                {
                    if (lastSymbol != null && lastSymbol == value.First())
                    {
                        result.Append($" {value}");
                    }
                    else
                    {
                        result.Append(value);
                    }
                    lastSymbol = value.Last();
                }
                else
                {
                    throw new KeyNotFoundException();
                }
            }

            return result.ToString();
        }
    }
}
