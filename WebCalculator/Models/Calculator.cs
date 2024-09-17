using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCalculator.Models
{
    public class Calculator
    {
        private readonly ExpressionParser _parser;
        private readonly RpnEvaluator _evaluator;

        public Calculator(OperationFactory operationFactory)
        {
            _parser = new ExpressionParser(operationFactory);
            _evaluator = new RpnEvaluator(operationFactory);
        }

        public double Evaluate(string expression)
        {
            List<string> rpnExpression = _parser.ConvertToRPN(expression);
            return _evaluator.EvaluateRPN(rpnExpression);
        }
    }
}
