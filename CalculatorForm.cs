using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CalculatorApp.view;
using CalculatorApp.model;
using CalculatorApp.Operations;
using CalculatorApp.transformations;

namespace CalculatorApp
{
    partial class CalculatorForm : Form, AnswerObserver, HistoryObserver, OperandObserver
    {
        CalculatorInterface model;
        
        public CalculatorForm(CalculatorInterface model)
        {
            InitializeComponent();

            // Enables KeyPress detection
            this.KeyPreview = true;

            this.KeyPress +=
                new KeyPressEventHandler(CalculatorForm_KeyPress);

            this.model = model;

            model.AnswerObserver = (AnswerObserver) this;
            model.HistoryObserver = (HistoryObserver) this;
            model.OperandObserver = (OperandObserver) this;
            model.Initialize();           
        }

        public CalculatorForm()
        {
            InitializeComponent();
        }

        public void UpdateOperand()
        {
            operandTextBox.Text = model.Operand;
        }

        public void UpdateHistory()
        {
            string history = model.History;
            if (history.Length > 34)
            {
                history = "..." + history.Substring(history.Length - 28);
            }
            historyTextBox.Text = history;
        }

        public void UpdateAnswer()
        {
            operandTextBox.Text = model.CurrentValue;
        }

        // Listeners
        private void equalButton_Click(object sender, EventArgs e)
        {
            model.Equals();
        }

        private void num0Button_Click(object sender, EventArgs e)
        {
            model.PutDigit('0');
        }

        private void num1Button_Click(object sender, EventArgs e)
        {
            model.PutDigit('1');
        }

        private void num2Button_Click(object sender, EventArgs e)
        {
            model.PutDigit('2');
        }

        private void num3Button_Click(object sender, EventArgs e)
        {
            model.PutDigit('3');
        }

        private void num4Button_Click(object sender, EventArgs e)
        {
            model.PutDigit('4');
        }

        private void num5Button_Click(object sender, EventArgs e)
        {
            model.PutDigit('5');
        }

        private void num6Button_Click(object sender, EventArgs e)
        {
            model.PutDigit('6');
        }

        private void num7Button_Click(object sender, EventArgs e)
        {
            model.PutDigit('7');
        }

        private void num8Button_Click(object sender, EventArgs e)
        {
            model.PutDigit('8');
        }

        private void num9Button_Click(object sender, EventArgs e)
        {
            model.PutDigit('9');
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            model.ApplyTransformation(new DeleteTransformation());
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            model.Initialize();
        }

        private void NegateButton_Click(object sender, EventArgs e)
        {
            model.ApplyTransformation(new NegateTransformation());
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            model.Operation = new AddOperation();
        }

        private void DivideButton_Click(object sender, EventArgs e)
        {
            model.Operation = new DivideOperation();
        }

        private void MultiplyButton_Click(object sender, EventArgs e)
        {
            model.Operation = new MultiplyOperation();
        }

        private void SubtractButton_Click(object sender, EventArgs e)
        {
            model.Operation = new SubtractOperation();
        }

        private void decimalButton_Click(object sender, EventArgs e)
        {
            model.ApplyTransformation(new transformations.PutDecimalTransformation());
        }

        void CalculatorForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57)
            {
                model.PutDigit((char) e.KeyChar);
                e.Handled = true;
            }
            else
            {
                switch (e.KeyChar)
                {
                    case (char)42:
                        model.Operation = new MultiplyOperation();
                        break;
                    case (char)43:
                        model.Operation = new AddOperation();
                        break;
                    case (char)45:
                        model.Operation = new SubtractOperation();
                        break;
                    case (char)47:
                        model.Operation = new DivideOperation();
                        break;
                    case (char)8:
                        model.ApplyTransformation(new DeleteTransformation());
                        break;
                    case (char)13:
                        model.Equals();
                        break;
                    case (char)46:
                        model.ApplyTransformation(new PutDecimalTransformation());
                        break;
                }
                e.Handled = true;
            }
        }
        
        private void CalculatorController_Load(object sender, EventArgs e)
        {

        }

        private void historyTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
