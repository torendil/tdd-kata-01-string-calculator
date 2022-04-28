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

            var individualNumbers = numbers.Split(',');

            return individualNumbers.Select(int.Parse)
                                    .Sum();
        }
    }
}