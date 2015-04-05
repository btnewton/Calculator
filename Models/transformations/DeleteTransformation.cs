using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp.transformations
{
    class DeleteTransformation : Transformation
    {

        public string Transform(string operand)
        {
            if (operand.Length > 0)
            {
                operand = operand.Substring(0, operand.Length - 1);
            }

            if (operand.Equals("-"))
            {
                operand = String.Empty;
            }

            return operand;
        }
    }
}
