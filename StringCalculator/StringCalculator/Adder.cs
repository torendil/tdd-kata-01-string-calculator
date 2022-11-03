namespace StringCalculator
{
    public static class Adder
    {
        public static int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }

            var parser = new Parser(numbers);
            var individualNumbers = parser.GetIndividualNumbers();

            return individualNumbers
                .Where(x => x <= 1000)
                .Sum();
        }
    }
}