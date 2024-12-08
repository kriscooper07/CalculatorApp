using System;
using System.Windows.Forms;

namespace CalculatorApp
{
    public partial class Form1 : Form
    {
        private string input = string.Empty;
        private string operand1 = string.Empty;
        private string operand2 = string.Empty;
        private char operation;
        private double result = 0.0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Scientific Calculator";
            this.Size = new System.Drawing.Size(400, 600);

            TextBox display = new TextBox
            {
                Name = "txtDisplay",
                ReadOnly = true,
                Font = new System.Drawing.Font("Arial", 18),
                Dock = DockStyle.Top,
                TextAlign = HorizontalAlignment.Right
            };

            this.Controls.Add(display);

            TableLayoutPanel buttonPanel = new TableLayoutPanel
            {
                RowCount = 6,
                ColumnCount = 4,
                Dock = DockStyle.Fill,
                AutoSize = true
            };

            string[] buttons =
            {
                "7", "8", "9", "/",
                "4", "5", "6", "*",
                "1", "2", "3", "-",
                "0", ".", "=", "+",
                "C", "sin", "cos", "sqrt"
            };

            foreach (var btn in buttons)
            {
                Button button = new Button
                {
                    Text = btn,
                    Dock = DockStyle.Fill,
                    Font = new System.Drawing.Font("Arial", 14)
                };
                button.Click += Button_Click;
                buttonPanel.Controls.Add(button);
            }

            this.Controls.Add(buttonPanel);
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            TextBox display = (TextBox)this.Controls["txtDisplay"];

            if (char.IsDigit(button.Text, 0) || button.Text == ".")
            {
                input += button.Text;
                display.Text = input;
            }
            else if (button.Text == "C")
            {
                input = operand1 = operand2 = string.Empty;
                display.Text = string.Empty;
                result = 0.0;
            }
            else if (button.Text == "=")
            {
                operand2 = input;
                double num1 = double.Parse(operand1);
                double num2 = double.Parse(operand2);

                switch (operation)
                {
                    case '+':
                        result = num1 + num2;
                        break;
                    case '-':
                        result = num1 - num2;
                        break;
                    case '*':
                        result = num1 * num2;
                        break;
                    case '/':
                        result = num1 / num2;
                        break;
                }

                display.Text = result.ToString();
                input = string.Empty;
            }
            else if (button.Text == "sin")
            {
                result = Math.Sin(double.Parse(input));
                display.Text = result.ToString();
                input = string.Empty;
            }
            else if (button.Text == "cos")
            {
                result = Math.Cos(double.Parse(input));
                display.Text = result.ToString();
                input = string.Empty;
            }
            else if (button.Text == "sqrt")
            {
                result = Math.Sqrt(double.Parse(input));
                display.Text = result.ToString();
                input = string.Empty;
            }
            else
            {
                operand1 = input;
                operation = button.Text[0];
                input = string.Empty;
            }
        }
    }
}
