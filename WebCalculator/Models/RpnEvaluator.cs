using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCalculator.Models
{
    public class RpnEvaluator
    {
        private readonly OperationFactory _operationFactory;

        public RpnEvaluator(OperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }

        public double EvaluateRPN(List<string> rpnExpression)
        {
            Stack<double> stack = new Stack<double>();

            foreach (string token in rpnExpression)
            {
                if (double.TryParse(token, NumberStyles.Any, CultureInfo.InvariantCulture, out double number))
                {
                    stack.Push(number);
                }
                else if (_operationFactory.IsOperator(token[0]))
                {
                    double rightOperand = stack.Pop();
                    double leftOperand = stack.Pop();
                    double result = _operationFactory.GetOperation(token[0]).Execute(leftOperand, rightOperand);
                    stack.Push(result);
                }
            }

            return stack.Pop();
        }
    }
}
