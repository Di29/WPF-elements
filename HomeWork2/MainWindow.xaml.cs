using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using NCalc;

namespace HomeWork2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        List<string> historyList = new List<string>();
        string hisoryItem;

        private void GridClick(object sender, RoutedEventArgs e)
        {
            Button btn = e.Source as Button;
            if (btn == null)
                return;
            string value = btn.Content.ToString();
            if (string.IsNullOrEmpty(value))
                return;
            switch (value)
            {
                case "C":
                    display.Text = "0";
                    break;
                case "=":
                    try
                    {
                        NCalc.Expression exp = new NCalc.Expression(display.Text);
                        hisoryItem = display.Text + value + exp.Evaluate().ToString();
                        historyList.Add(hisoryItem);
                        history.Text = "";
                        for (int i = 0; i<historyList.Count; i++)
                        {
                            history.Text += historyList[i].ToString() + Environment.NewLine;
                        }

                        display.Text = exp.Evaluate().ToString();
                    }
                    catch
                    {
                        display.Text = "Error";
                    }
                    break;
                default:
                    display.Text = display.Text.TrimStart('0') + value;
                    break;
            }
        }
    }
}
