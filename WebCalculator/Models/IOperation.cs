using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCalculator.Models
{
    public interface IOperation
    {
        double Execute(double left, double right);
        int Precedence { get; }
        char Symbol { get; }
    }
}

