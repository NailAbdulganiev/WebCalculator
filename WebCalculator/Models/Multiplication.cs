using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCalculator.Models
{
    public class Multiplication : IOperation
    {
        public double Execute(double left, double right)
        {
            return left * right;
        }
        public int Precedence => 2;
        public char Symbol => '*';
    }
}
