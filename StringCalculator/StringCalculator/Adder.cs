namespace StringCalculator
{
    public class Adder
    {
        private readonly char[] separators = new char[] { ',', '\n' };

        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }

            var individualNumbers = GetIndividualNumbers(numbers);

            return individualNumbers.Select(int.Parse)
                                    .Sum();
        }

        private string[] GetIndividualNumbers(string numbers)
        {
            return numbers.Split(separators);
        }
    }
}