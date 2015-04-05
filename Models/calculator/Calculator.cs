using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorApp.Operations;
using System.Media;
using CalculatorApp.view;
using CalculatorApp.transformations;
using CalculatorApp.operations;
using System.Windows.Forms;
using System.Globalization;

namespace CalculatorApp.model
{
    class Calculator : CalculatorInterface
    {
        private string history;
        private double currentValue;
        private string operand;        
        private Operation operation;

        private AnswerObserver answerObserver;
        private HistoryObserver historyObserver;
        private OperandObserver operandObserver;
        
        private const string DEFAULT_VALUE = "0";

        public Calculator()
        {
            answerObserver = null;
            historyObserver = null;
            operandObserver = null;

            Initialize();
        }

        /* Sets the operation to be applied.
         * 
         * If the operand is empty the operation is stored for later use and the history 
         * observer is updated to display the new operation.
         * 
         * If the operand is not empty the operation that was stored is applied and the
         * new operation is then stored in its place.
         */
        public Operation Operation
        {
            set
            {
                if ( ! operand.Equals(String.Empty))
                {
                    Execute();
                }
                if ( ! history.Equals(String.Empty))
                {
                    operation = value;
                    UpdateHistoryObserver();
                }
            }
        }

        public string CurrentValue
        {
            get { return String.Format("{0:0.#####}", currentValue); }
        }

        /* Returns the history of operations.
         * 
         * Also returns the current operation.
         */
        public string History
        {
            get
            {
                if (!history.Equals(String.Empty))
                {
                    return history + operation.ToString() + " ";
                }
                else
                {
                    return "";
                }
            }
        }

        /* Returns the operand.
         * 
         * If the operand is empty the DEFAULT_VALUE is returned instead.
         */
        public string Operand
        {
            get
            {
                if (operand.Length == 0)
                {
                    return DEFAULT_VALUE.ToString();
                }
                else
                {
                    return operand;
                }
            }
        }

        /* Applies the current operation and updates the calculation history.
         * 
         * The operand is reset but only the history and answer observers are updated.
         */
        public void Execute()
        {
            double operandValue;

            bool operandConverted = double.TryParse(operand, NumberStyles.Float, CultureInfo.InvariantCulture, out operandValue);

            if (operandConverted)
            {
                currentValue = operation.Calculate(currentValue, double.Parse(operand));
                history += operation.ToString() + " " +  operand + " ";
            }
            else
            {
                Console.WriteLine("Unable to convert {0}", operand);
            }

            InitializeOperand();

            UpdateHistoryObserver();
            UpdateAnswerObserver();
        }

        public void InitializeOperand()
        {
            operand = String.Empty;
        }

        /* Returns all fields to their original state.
         * 
         * The operation is set to an InitializeOperation which will store the first
         * operand the user enters.
         * 
         * All observers are updated.
         */
        public void Initialize()
        {
            operation = new InitializeOperation();

            history = String.Empty;
            currentValue = 0;
            InitializeOperand();

            UpdateAllObservers();
        }  

        /* Appends a digit to the end of the operand.
         * 
         * The operand observers are then updated.
         */
        public void PutDigit(char digit)
        {
            if (Char.IsDigit(digit))
            {
                operand += digit;
                UpdateOperandObserver();
            }
        }

        /* Applies the transformation called by the controller.
         * 
         * Transformations are applied with button presses. Transformations
         * modify the current operand. Examples include negation, adding a
         * decimal point and creating a percentage.
         * 
         * The operand observer directly after the transformation is applied.
         */
        public void ApplyTransformation(Transformation transformation)
        {
            operand = transformation.Transform(operand);
            UpdateOperandObserver();
        }

        /* Applies the current operation and adds currentValue to the history.
         * 
         * If the operand is empty this does nothing.
         */
        public void Equals()
        {
            if ( ! operand.Equals(String.Empty))
            {
                Execute();
                history += "= " + CurrentValue + " ";
                UpdateHistoryObserver();
            }
        }

        // Observeration
        public AnswerObserver AnswerObserver
        {
            set { answerObserver = value; }
        }

        public HistoryObserver HistoryObserver
        {
            set { historyObserver = value; }
        }

        public OperandObserver OperandObserver
        {
            set { operandObserver = value; }
        }

        public void UpdateAllObservers()
        {
            UpdateAnswerObserver();
            UpdateHistoryObserver();
            UpdateOperandObserver();
        }

        public void UpdateAnswerObserver()
        {
            if (answerObserver != null) answerObserver.UpdateAnswer();
        }

        public void UpdateHistoryObserver()
        {
            if (historyObserver != null) historyObserver.UpdateHistory();
        }

        public void UpdateOperandObserver()
        {
            if (operandObserver != null) operandObserver.UpdateOperand();
        }
    }
}
