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
        internal Parser(string input)
        {
            if (input.StartsWith("//"))
            {
                var additionalSeparator = input[LocationOfCustomSeparator];
                separators.Add(additionalSeparator);
                input = input.Substring(LengthOfCustomSeparatorSequence);
            }

            this.input = input;
        }

        /// <summary>
        /// Separates numbers from the string based on separators that have been found. Any negative number will throw an <see cref="ArgumentException"/>
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        internal IEnumerable<int> GetIndividualNumbers()
        {
            var parsables = input.Split(separators.ToArray())
                                 .ToLookup(parsable => !parsable.Contains('-'));
            var positives = parsables[true];
            var negatives = parsables[false];

            if (negatives.Any())
            {
                throw new ArgumentException(Constants.NoNegativeNumbers + string.Join(", ", negatives));
            }
            
            return positives.Select(int.Parse);
        }
    }
}
