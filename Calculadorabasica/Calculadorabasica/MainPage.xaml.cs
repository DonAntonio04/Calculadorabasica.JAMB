using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Calculadorabasica
{
    public partial class MainPage : ContentPage
    {

        private string input = string.Empty;
        private string operador = string.Empty;
        private double num1, num2, resultado;
        public MainPage()
        {
            InitializeComponent();
        }



        private void OnNumberButtonClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string newText = button.Text;

            if (newText == "." && input.Contains("."))
            {
                return;
            }

            input += newText;
            ResultadoLabel.Text = input;
        }

        private void OnOperatorButtonClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            operador = button.Text;
            if (input != string.Empty)
            {
                num1 = double.Parse(input);
                input = string.Empty;
            }
        }

        private void OnCalculateButtonClicked(object sender, EventArgs e)
        {
            if (input != string.Empty)
            {
                num2 = double.Parse(input);
                input = string.Empty;
            }

            switch (operador)
            {
                case "+":
                    resultado = num1 + num2;
                    break;
                case "-":
                    resultado = num1 - num2;
                    break;
                case "x":
                    resultado = num1 * num2;
                    break;
                case "÷":
                    if (num2 != 0)
                    {
                        resultado = num1 / num2;
                    }
                    else
                    {
                        ResultadoLabel.Text = "Error";
                        return;
                    }
                    break;
            }

            ResultadoLabel.Text = resultado.ToString();
        }

        private void OnClearButtonClicked(object sender, EventArgs e)
        {
            input = string.Empty;
            operador = string.Empty;
            num1 = 0;
            num2 = 0;
            ResultadoLabel.Text = "0";
        }


    }
}


