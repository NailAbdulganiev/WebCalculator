using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCalculator.Models
{
    public class Division : IOperation
    {
        public double Execute(double left, double right)
        {
            if (right == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero.");
            }
            return left / right;
        }
        public int Precedence => 2;
        public char Symbol => '/';
    }
}
