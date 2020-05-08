using System;

namespace Lab7
{
    class CalculatorModel : ICalculator
    {
        private double result = 0;
        
        private IOperations operations = new Operations();

        public void SetFirstNumber(double first)
        {
            result = first;
        }

        public double Result()
        {
            return result;
        }

        public bool Add(double number)
        {
            result = operations.Add(result, number);
            return true;
        }

        public bool Substract(double number)
        {
            result = operations.Substract(result, number);
            return true;
        }

        public bool Multiply(double number)
        {
            result = operations.Multiply(result, number);
            return true;
        }

        public bool Divide(double number) 
        {
            if (Math.Abs(number) < double.Epsilon)
                return false;
            result = operations.Divide(result, number);
            return true;
        }

        public bool ChangeSign()
        {
            result = operations.ChangeSign(result);
            return true;
        }
    }
}
