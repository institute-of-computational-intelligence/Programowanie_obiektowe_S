using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    interface IOperations
    {
        double Add(double augend, double addend);
        double Substract(double minuend, double substrahend);
        double Multiply(double multiplier, double multiplicand);
        double Divide(double dividend, double divisor);
        double ChangeSign(double number);
    }
}
