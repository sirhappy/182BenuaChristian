using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using task3;

namespace task3Desktop
{
    public partial class Form1 : Form
    {
        private Dictionary<Button, Func<Fraction, Fraction, Fraction>> operationsDict;

        public Form1()
        {
            InitializeComponent();
            this.resultTextBox.Enabled = false;
            this.decimalResultTextBox.Enabled = false;
            this.plusButton.Click += OnBinaryOperationClick;
            this.minusButton.Click += OnBinaryOperationClick;
            this.multiplyButton.Click += OnBinaryOperationClick;
            this.divideButton.Click += OnBinaryOperationClick;
            this.decrementButton.Click += DecrementButton_Click;
            this.incrementButton.Click += IncrementButton_Click;
            operationsDict = new Dictionary<Button, Func<Fraction, Fraction, Fraction>>();
            operationsDict[plusButton] = new Func<Fraction, Fraction, Fraction>((lhs, rhs) => lhs + rhs);
            operationsDict[minusButton] = new Func<Fraction, Fraction, Fraction>((lhs, rhs) => lhs - rhs);
            operationsDict[multiplyButton] = new Func<Fraction, Fraction, Fraction>((lhs, rhs) => lhs * rhs);
            operationsDict[divideButton] = new Func<Fraction, Fraction, Fraction>((lhs, rhs) => lhs / rhs);
        }

        private void showResult(Fraction value)
        {
            this.resultTextBox.Text = value.ToString();
            this.decimalResultTextBox.Text = value.ToDecimal().ToString();
        }

        public (bool, Fraction) ParseInputField(TextBox box)
        {
            var components = box.Text.Split('/');
            if (components.Count() != 2 && components.Count() != 1)
            {
                return (false, null);
            }

            components.ToList().ForEach((el) => el.Trim());
            if (components.Count() == 2)
            {
                int denominator;
                int numerator;

                if (!int.TryParse(components[0], out numerator) || !int.TryParse(components[1], out denominator))
                {
                    return (false, null);
                }

                return (true, new Fraction(numerator, denominator));
            }
            else
            {
                double source;
                if (!double.TryParse(components[0], out source))
                {
                    return (false, null);
                }

                return (true, new Fraction(source));
            }
        }

        private void IncrementButton_Click(object sender, EventArgs e)
        {
            try
            {
                bool success;
                Fraction value;
                (success, value) = ParseInputField(lhsTextBox);
                if (!success)
                {
                    MessageBox.Show("Invalid Fraction, correct input");
                    return;
                }

                value++;
                this.showResult(value);
            }
            catch (OverflowException ex)
            {
                MessageBox.Show("Overflow happened");
            }
        }

        private void DecrementButton_Click(object sender, EventArgs e)
        {
            try
            {
                (bool success, Fraction value) = ParseInputField(lhsTextBox);
                if (!success)
                {
                    MessageBox.Show("Invalid Fraction, correct input");
                    return;
                }

                value--;
                this.showResult(value);
            }
            catch (DivideByZeroException ex)
            {
                MessageBox.Show("Divide by zero happened");
            }
            catch (OverflowException ex)
            {
                MessageBox.Show("Overflow happened");
            }
        }

        private void OnBinaryOperationClick(object sender, EventArgs e)
        {
            try
            {
                (bool successLhs, Fraction lhsValue) = ParseInputField(lhsTextBox);
                (bool successRhs, Fraction rhsValue) = ParseInputField(rhsTextBox);
                if (!successLhs || !successRhs)
                {
                    MessageBox.Show("Invalid fraction, correct input");
                    return;
                }

                var result = operationsDict[sender as Button]?.Invoke(lhsValue, rhsValue);
                this.showResult(result);
            }
            catch (DivideByZeroException ex)
            {
                MessageBox.Show("Divide by zero happened");
            }
            catch (OverflowException ex)
            {
                MessageBox.Show("Overflow happened");
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Incorrect Result, possibly, Divide by zero");
            }
        }
    }
}