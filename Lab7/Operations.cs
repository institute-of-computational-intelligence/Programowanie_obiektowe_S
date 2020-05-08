using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    class Operations : IOperations
    {
        public double Add(double augend, double addend)
        {
            return augend + addend;
        }

        public double ChangeSign(double number)
        {
            return -1 * number;
        }

        public double Divide(double dividend, double divisor)
        {
            return dividend / divisor;
        }

        public double Multiply(double multiplier, double multiplicand)
        {
            return multiplier * multiplicand;
        }

        public double Substract(double minuend, double substrahend)
        {
            return minuend - substrahend;
        }
    }
}
