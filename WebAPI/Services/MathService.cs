namespace WebAPI.Services
{
    public class Class
    {
        public decimal Sum(decimal fristNumber, decimal secondNumber) => fristNumber + secondNumber;
        public decimal Subtration(decimal fristNumber, decimal secondNumber) => fristNumber - secondNumber;
        public decimal Multilication(decimal fristNumber, decimal secondNumber) => fristNumber * secondNumber;
        public decimal Division(decimal fristNumber, decimal secondNumber)
        {
            if (secondNumber == 0) throw new DivideByZeroException("Divisaion by zero is not allowed");
           return fristNumber / secondNumber;
        }
        public double SquareRoot(decimal number)
        {
            if (number < 0) throw new ArgumentOutOfRangeException("Cannot calculate square root of a negative number");
            return Math.Sqrt((double)number);
        }
    }
}
