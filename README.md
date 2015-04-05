# Calculator
A simple C# project with a Windows Form interface.

Calculator App Read Me

General Overview
This calculator app was is capable of all basic mathematical operations and can also negate, 
delete, clear, and insert decimal places. It also displays some calculation history.  All 
features can be operated via keyboard or GUI.

Design
When the app is launched a calculator model object is created and passed into the form’s 
constructor. The form implements 3 observer interfaces and registers itself with the 
calculator instance. The form observers state changes in the calculators answer, operation 
history and operand fields. I chose this configuration of observers to accommodate different 
form displays. This version has only 2 fields that display information so answers will 
replace the operand when updated.
The controller manipulates the model by changing the value of the operand with the PutDigit 
and ApplyTransformation methods. ApplyTransformation accepts objects that implement the 
Transformation interface. Transformations include delete, clear, and put decimal functions. 
New transformations can be created without changing the calculator class.  The controller can 
also set the operation of the calculator. Operations implement the Operation interface and 
are used to perform operations between the current value and the operand fields. They are 
responsible for their own error handling as needed. The model will apply the current 
operation if the operand is not empty before setting the new operation.
I chose to use the Strategy Design pattern for controlling the operation of the calculator 
to make it easier to control the apps features. One example is the stock Windows Calculator 
which allows the user to switch between standard, scientific and other calculator types on the 
fly. Only one of my calculator models would be required for this behavior. There is no 
duplicate code and only the view and controller need to be changed. Other programmers could 
also easily implement their own transformation and operation classes. Again, the multiple 
observer design also accommodates additional view designs.
