using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp.transformations
{
    class PutDecimalTransformation : Transformation
    {

        public string Transform(string operand)
        {

            if (operand.IndexOf(".") == -1)
            {
                operand += ".";

                if (operand[0] == '.')
                {
                    operand = "0" + operand;
                }
            }

            return operand;
        }
    }
}
