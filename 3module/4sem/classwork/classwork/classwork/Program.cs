using System;

namespace classwork
{

    public class ExpressionContainer
    {
        private event Action ExpressionChanged;
        private Func<double, double> _expression;
        public Func<double, double> Expression
        {
            get => _expression;
            set
            {
                _expression = value;
                ExpressionChanged?.Invoke();
            }
        }

        public ExpressionContainer(Func<double, double> expr)
        {
            this.Expression = expr;
        }

        public double EvaluateExpression(double argument)
        {
            return Expression(argument);
        }

        public void SubscribeToExpressionChanged(Action action)
        {
            ExpressionChanged += action;
        }
    }

    public class ValueStorage
    {
        private ExpressionContainer expression;
        public double Argument { get; set; }

        double expressionCurrentValue;

        public double ExpressionValue => expressionCurrentValue;

        public ValueStorage(ExpressionContainer expression, double arg)
        {
            this.expression = expression;
            this.Argument = arg;
            expressionCurrentValue = expression.EvaluateExpression(arg);
        }
        public void OnExpressionChangedHandler()
        {
            expressionCurrentValue = expression.EvaluateExpression(Argument);
            Console.WriteLine("LOGS");
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            ExpressionContainer expression = new ExpressionContainer((arg) => arg * arg + 1);
            ValueStorage vs = new ValueStorage(expression, 0);
            Console.WriteLine(vs.ExpressionValue);
            expression.SubscribeToExpressionChanged(vs.OnExpressionChangedHandler);
            expression.Expression = (x) => x * x + 2;
            Console.WriteLine(vs.ExpressionValue);
        }
    }
}
