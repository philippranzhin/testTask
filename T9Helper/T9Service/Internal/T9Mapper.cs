// --------------------------------------------------------------------------------------------------------------------
// <copyright file="T9Mapper.cs" company="Philipp Ranzhin">
//   Philipp Ranzhin (c)
// </copyright>
// <summary>
//   Defines the T9Mapper type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace T9Helper.T9Service.Internal
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <inheritdoc />
    internal class T9Mapper : IT9Mapper
    {
        /// <summary>
        /// The alphabet size.
        /// </summary>
        private const int AlphabetSize = 27;

        /// <summary>
        /// The map.
        /// </summary>
        private Dictionary<char, string> alphabetMap;

        /// <summary>
        /// Initializes a new instance of the <see cref="T9Mapper"/> class.
        /// </summary>
        public T9Mapper()
        {
            this.GenerateMap();
        }

        /// <inheritdoc />
        public bool Contains(string data)
        {
            foreach (char symbol in data)
            {
                if (!this.alphabetMap.ContainsKey(symbol))
                {
                    return false;
                }
            }

            return true;
        }

        /// <inheritdoc />
        public string Map(string data)
        {
            var result = new StringBuilder();
            char? lastSymbol = null;

            foreach (char symbol in data)
            {
                if (this.alphabetMap.TryGetValue(symbol, out string value))
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


        /// <summary>
        /// The generate map.
        /// </summary>
        private void GenerateMap()
        {
            var map = new Dictionary<char, string>(AlphabetSize)
                          {
                              { 'a', "2" },
                              { 'b', "22" },
                              { 'c', "222" },
                              { 'd', "3" },
                              { 'e', "33" },
                              { 'f', "333" },
                              { 'g', "4" },
                              { 'h', "44" },
                              { 'i', "444" },
                              { 'j', "5" },
                              { 'k', "55" },
                              { 'l', "555" },
                              { 'm', "6" },
                              { 'n', "66" },
                              { 'o', "666" },
                              { 'p', "7" },
                              { 'q', "77" },
                              { 'r', "777" },
                              { 's', "7777" },
                              { 't', "8" },
                              { 'u', "88" },
                              { 'v', "888" },
                              { 'w', "9" },
                              { 'x', "99" },
                              { 'y', "999" },
                              { 'z', "9999" },
                              { ' ', "0" }
                          };
            this.alphabetMap = map;
        }
    }
}
