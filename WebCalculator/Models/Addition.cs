using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCalculator.Models
{
    public class Addition : IOperation
    {
        public double Execute(double left, double right) 
        {
           return left + right;
        }
        public int Precedence => 1;
        public char Symbol => '+';
    }
}
