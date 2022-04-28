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
            if (numbers.Contains(","))
            {
                var indexOfComma = numbers.IndexOf(',');
                return int.Parse(numbers.Substring(0, indexOfComma)) +
                       int.Parse(numbers.Substring(indexOfComma + 1));
            }
            return int.Parse(numbers);
        }
    }
}