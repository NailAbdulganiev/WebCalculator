using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCalculator.Models
{
    public class OperationFactory
    {
        private readonly Dictionary<char, IOperation> _operations;

        public OperationFactory()
        {
            _operations = new Dictionary<char, IOperation>
        {
            { '+', new Addition() },
            { '-', new Subtraction() },
            { '*', new Multiplication() },
            { '/', new Division() }
        };
        }

        public IOperation GetOperation(char symbol)
        {
            if (_operations.ContainsKey(symbol))
            {
                return _operations[symbol];
            }
            throw new InvalidOperationException($"Operator '{symbol}' is not supported.");
        }

        public bool IsOperator(char symbol) 
        {
            return _operations.ContainsKey(symbol);
        }
    }
}
