namespace Prime.Numbers.Domain.Entites
{
    public class PrimeNumbersResult
    {
        public List<int> PrimeNumbers { get; set; }
        public List<int> PrimeDivisorsNumbers { get; set; }

        public PrimeNumbersResult() { }
    }
}
