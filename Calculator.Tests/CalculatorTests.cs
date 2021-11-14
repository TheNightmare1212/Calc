using System;
using Xunit;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Calculator.Tests
{
    public class CalculatorTests
    {
        //Calculator calculator = new();
        [Fact]
        public void ShouldSumm()
        {
            var actual = Calculator.DoOperation(2, 2, "a");
            Assert.Equal(4, actual);
        }
        [Fact]
        public void ShouldSubstract()
        {
            var actual = Calculator.DoOperation(2, 2, "s");
            Assert.Equal(0, actual);
        }
        [Fact]
        public void ShouldMultiply()
        {
            var actual = Calculator.DoOperation(2, 2, "m");
            Assert.Equal(4, actual);
        }
        [Fact]
        public void ShouldDivide()
        {
            var actual = Calculator.DoOperation(2, 2, "d");
            Assert.Equal(1, actual);
        }
        [Fact]
        public void ShouldDoNothing()
        {
            var actual = Calculator.DoOperation(2, 2, "o");
            Assert.Equal(double.NaN, actual);
        }
        [Fact]
        public void ShouldRun()
        {
            var output = new StringWriter();
            Console.SetOut(output);
            string[] userInput = new string[4]
                {
                    "2",
                    "2",
                    "d",
                    "n"
            };
            var input = new StringReader(string.Join(Environment.NewLine, userInput));
            Console.SetIn(input);

            Program.Main(new string[] { });
           
            string expectedOutput =
@"Console Calculator in C#
------------------------

Type a number, and then press Enter: 

Type another number, and then press Enter: 

Choose an operator from the following list:
     a - Add
     s - Subtract
     m - Multiply
     d - Divide
Your option? 
Your result: 1

------------------------

Press 'n' and Enter to close the app, or press any other key and Enter to continue: 

";
var actual = output.ToString();

            Assert.Equal(expectedOutput, actual);
        }
        [Fact]
        public void ShouldRunWithFirstEncorrectArg()
        {
            var output = new StringWriter();
            Console.SetOut(output);
            string[] userInput = new string[5]
                {
                    "w",
                    "2",
                    "2",
                    "d",
                    "n"
            };
            var input = new StringReader(string.Join(Environment.NewLine, userInput));
            Console.SetIn(input);

            Program.Main(new string[] { });

            string expectedOutput =
@"Console Calculator in C#
------------------------

Type a number, and then press Enter: 
This is not valid input. Please enter an integer value: 
Type another number, and then press Enter: 

Choose an operator from the following list:
     a - Add
     s - Subtract
     m - Multiply
     d - Divide
Your option? 
Your result: 1

------------------------

Press 'n' and Enter to close the app, or press any other key and Enter to continue: 

";
            var actual = output.ToString();

            Assert.Equal(expectedOutput, actual);
        }
        [Fact]
        public void ShouldRunWithSecondEncorrectArg()
        {
            var output = new StringWriter();
            Console.SetOut(output);
            string[] userInput = new string[5]
                {
                    "2",
                    "w",
                    "2",
                    "d",
                    "n"
            };
            var input = new StringReader(string.Join(Environment.NewLine, userInput));
            Console.SetIn(input);

            Program.Main(new string[] { });

            string expectedOutput =
@"Console Calculator in C#
------------------------

Type a number, and then press Enter: 

Type another number, and then press Enter: 
This is not valid input. Please enter an integer value: 
Choose an operator from the following list:
     a - Add
     s - Subtract
     m - Multiply
     d - Divide
Your option? 
Your result: 1

------------------------

Press 'n' and Enter to close the app, or press any other key and Enter to continue: 

";
            var actual = output.ToString();

            Assert.Equal(expectedOutput, actual);
        }
        [Fact]
        public void ShouldRunWithEncorrectOp()
        {
            var output = new StringWriter();
            Console.SetOut(output);
            string[] userInput = new string[4]
                {
                    "2",
                    "2",
                    "w",
                    "n"
            };
            var input = new StringReader(string.Join(Environment.NewLine, userInput));
            Console.SetIn(input);

            Program.Main(new string[] { });

            string expectedOutput =
@"Console Calculator in C#
------------------------

Type a number, and then press Enter: 

Type another number, and then press Enter: 

Choose an operator from the following list:
     a - Add
     s - Subtract
     m - Multiply
     d - Divide
Your option? 
This operation will result in a mathematical error.

------------------------

Press 'n' and Enter to close the app, or press any other key and Enter to continue: 

";
            var actual = output.ToString();

            Assert.Equal(expectedOutput, actual);
        }

    }
}
