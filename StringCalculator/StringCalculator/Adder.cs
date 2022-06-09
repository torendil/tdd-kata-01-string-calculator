namespace StringCalculator
{
    public class Adder
    {
        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }

            var parser = new Parser(numbers);
            var individualNumbers = parser.GetIndividualNumbers();

            return individualNumbers.Sum();
        }
    }
}