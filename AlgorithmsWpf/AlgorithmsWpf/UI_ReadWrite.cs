using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Algorithms.Data;


namespace AlgorithmsWpf
{
    public partial class UI_Algorithms : Window
    {

        #region Read
        private double[] readInput(RichTextBox RTB)
        {
            double[] input_array = new double[1];
            try
            {
                string[] input_line = this.readRichtextbox(RTB).Split(' ');
                input_array = new double[input_line.Length];

                for (int i = 0; i < input_array.Length; i++)
                {
                    input_array[i] = double.Parse(input_line[i]);
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return input_array;
        }

        private string readRichtextbox(RichTextBox RTB)
        {
            return new TextRange(RTB.Document.ContentStart, RTB.Document.ContentEnd).Text;
        }
        #endregion

        #region Write

        private void printToFile(string algorithm, string method, string time, double[] array)
        {

        }

        private void readFromFile(string fileName)
        {

        }

        private void DisplayAction(string algorithm, string method, string time)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(algorithm + '\n');
            sb.Append(method + '\n');
            sb.Append(time + '\n');
            sb.Append(this.TextBlockLog.Text + '\n');
            sb.Append("----------------------");
            this.Richtextbox_log.AppendText(sb.ToString().Trim() + '\n');
            this.Richtextbox_log.ScrollToEnd();
        }

        private void DisplayCheckSortUp(double[] input)
        {            
            if (Sort.CheckSortUp(input)) this.TextBlockLog.Text = "Отсортировано"; else this.TextBlockLog.Text = "Не отсортировано";
        }

        private void DisplayCheckSortDown(double[] input)
        {
            if (Sort.CheckSortDown(input)) this.TextBlockLog.Text = "Отсортировано"; else this.TextBlockLog.Text = "Не отсортировано";
        }

        private void DisplayStruct()
        {
            double[] output_array= new double[0];
            switch (this.ComboBox_struct.SelectedItem.ToString())
            {
                case "Стек":
                    output_array = stackStruct.GetStruct;
                    break;

                case "Очередь":
                    output_array = queueStruct.GetStruct;
                    break;

                case "Дек":
                    output_array = dequeStruct.GetStruct;
                    break;

                case "Связанный список":
                    linkedListStruct.MakeArray();
                    output_array = linkedListStruct.GetStruct;
                    break;
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < output_array.Length; i++)
            {
                sb.Append(output_array[i]);
                sb.Append(' ');
            }
            this.RichTextBox_output.AppendText(sb.ToString().Trim());
        }

        private void DisplayTree()
        {
            double[] output_array = new double[0];
            switch (this.ComboBox_tree.SelectedItem.ToString())
            {
                case "Бинарное":
                    output_array = binaryTree.GetTree;
                    break;               
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < output_array.Length; i++)
            {
                sb.Append(output_array[i]);
                sb.Append(' ');
            }
            this.RichTextBox_output.AppendText(sb.ToString().Trim());
        }

        #endregion
    }
}
