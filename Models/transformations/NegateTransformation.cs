using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp.transformations
{
    class NegateTransformation : Transformation
    {
        public string Transform(string operand)
        {
            if (operand.Equals(String.Empty))
            {
                return operand;
            }
            else if (operand[0] == '-')
            {
                return operand.Substring(1);
            }
            else
            {
                return "-" + operand;
            }
        }
    }
}
