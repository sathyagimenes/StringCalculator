namespace StringCalculator.Domain
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
                return 0;

            var listNumbers = numbers.Split(',');

            var exceedsCount = listNumbers.Length > 2;
            //var consecutiveCommas = listNumbers.Any(string.IsNullOrWhiteSpace);
            var consecutiveCommas = listNumbers.Any(x => x == "");
            var nonNumbers = listNumbers.Any(x => !int.TryParse(x, out _));
            if (exceedsCount || consecutiveCommas || nonNumbers)
            {
                throw new ArgumentException(nameof(numbers));
            }

            //var sum = listNumbers.Sum(Convert.ToInt32);
            var sum = listNumbers.Sum(x => Convert.ToInt32(x));

            return sum;
        }
    }
}