using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp.operations
{
    class InitializeOperation : Operation
    {

        public double Calculate(double operand1, double operand2)
        {
            return operand2;
        }

        public override String ToString()
        {
            return "";
        }
    }
}
