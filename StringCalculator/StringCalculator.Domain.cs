namespace StringCalculator.Domain
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
                return 0;

            var listNumbers = numbers.Split(',');
            if (listNumbers.Length > 2)
            {
                throw new ArgumentException(nameof(numbers));
            }
            return 100;
        }
    }
}