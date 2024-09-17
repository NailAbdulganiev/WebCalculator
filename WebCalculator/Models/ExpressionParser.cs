using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCalculator.Models
{
    public class ExpressionParser
    {
        private readonly OperationFactory _operationFactory;

        public ExpressionParser(OperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }

        public List<string> ConvertToRPN(string expression)
        {
            Stack<char> operators = new Stack<char>();
            List<string> output = new List<string>();
            string numberBuffer = "";

            for (int i = 0; i < expression.Length; i++)
            {
                char token = expression[i];

                if (char.IsDigit(token) || token == '.')
                {
                    numberBuffer += token;
                }
                else
                {
                    if (numberBuffer != "")
                    {
                        output.Add(numberBuffer);
                        numberBuffer = "";
                    }

                    if (_operationFactory.IsOperator(token))
                    {
                        while (operators.Count > 0 && _operationFactory.IsOperator(operators.Peek()) &&
                               _operationFactory.GetOperation(operators.Peek()).Precedence >= _operationFactory.GetOperation(token).Precedence)
                        {
                            output.Add(operators.Pop().ToString());
                        }
                        operators.Push(token);
                    }
                    else if (token == '(')
                    {
                        operators.Push(token);
                    }
                    else if (token == ')')
                    {
                        while (operators.Count > 0 && operators.Peek() != '(')
                        {
                            output.Add(operators.Pop().ToString());
                        }
                        if (operators.Count > 0 && operators.Peek() == '(')
                        {
                            operators.Pop();
                        }
                    }
                }
            }

            if (numberBuffer != "")
            {
                output.Add(numberBuffer);
            }

            while (operators.Count > 0)
            {
                output.Add(operators.Pop().ToString());
            }

            return output;
        }
    }
}
