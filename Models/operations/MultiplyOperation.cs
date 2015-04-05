using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorApp.Operations
{
    class MultiplyOperation : Operation
    {
        public double Calculate(double operand1, double operand2)
        {
            return operand1 * operand2;
        }

        public override string ToString()
        {
            return "×";
        }
    }
}
