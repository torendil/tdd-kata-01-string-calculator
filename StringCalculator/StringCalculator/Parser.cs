using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    internal class Parser
    {
        private const int LocationOfCustomSeparator = 2;
        private const int LengthOfCustomSeparatorSequence = 4;
        private readonly IList<char> separators = new List<char> { ',', '\n' };
        private readonly string input;

        /// <summary>
        /// Creates a parser from the input string containing numbers.
        /// If the input string starts with "//x\n", considering x to be any char, the parser will consider x as a custom separator
        /// and skip "//x\n" from the input string
        /// </summary>
        /// <param name="input">The input string, with or without a custom separator</param>
        public Parser(string input)
        {
            if (input.StartsWith("//"))
            {
                var additionalSeparator = input[LocationOfCustomSeparator];
                separators.Add(additionalSeparator);
                input = input.Substring(LengthOfCustomSeparatorSequence);
            }

            this.input = input;
        }

        public IEnumerable<int> GetIndividualNumbers()
        {
            return input.Split(separators.ToArray())
                        .Select(int.Parse);
        }
    }
}
