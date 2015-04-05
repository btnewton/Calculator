using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorApp.view;
using CalculatorApp.transformations;

namespace CalculatorApp.model
{
    interface CalculatorInterface
    {
        void Initialize();

        Operation Operation{ set; }
        string CurrentValue { get; }
        string History { get; }
        string Operand { get; }

        void PutDigit(char digit);
        void ApplyTransformation(Transformation transformation);
        void Equals();

        AnswerObserver AnswerObserver { set; }
        HistoryObserver HistoryObserver { set; }
        OperandObserver OperandObserver { set; }

        void UpdateAnswerObserver();
        void UpdateHistoryObserver();
        void UpdateOperandObserver();
        void UpdateAllObservers();
    }
}
