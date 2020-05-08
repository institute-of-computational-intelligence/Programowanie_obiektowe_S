
namespace Lab7
{
    interface ICalculator
    {
        double Result();
        void SetFirstNumber(double first);
        bool Add(double number);
        bool Substract(double number);
        bool Multiply(double number);
        bool Divide(double number);
        bool ChangeSign();
    }
}
