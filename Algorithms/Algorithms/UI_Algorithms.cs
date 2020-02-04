using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using Algorithms.Data;

namespace Algorithms
{
    public partial class UI_Algorithms : Form
    {
        public UI_Algorithms()
        {
            InitializeComponent();
            this.Init();
        }

        private void Init()
        {
            this.comboBox_sort_algorithm.SelectedIndex = 0;
            this.label_sort_check.Text = "";
            this.richTextBox__sort_output.ReadOnly = true;
            this.richTextBox__sort_output.BackColor = System.Drawing.SystemColors.Window;
        }

        #region Sort
        private void button_generate_input_Click(object sender, EventArgs e)
        {
            //get input array length
            this.richTextBox_sort_input.Clear();

            try
            {
                int n = Int32.Parse(this.textBox__sort_input_length.Text);
                int max = Int32.Parse(this.textBox_sort_max_value.Text);

                double[] input_array = new double[n];

                Random rand = new Random();

                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < n; i++)
                {
                    input_array[i] = rand.Next(max) + Math.Round(rand.NextDouble(), 2);
                    sb.Append(input_array[i]);
                    sb.Append(' ');
                }
                this.richTextBox_sort_input.AppendText(sb.ToString().Trim());
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void button_sort_Click(object sender, EventArgs e)
        {
            this.richTextBox__sort_output.Clear();            

            try
            {
                string[] input_line = this.richTextBox_sort_input.Text.Split(' ');
                double[] input_array = new double[input_line.Length];

                for (int i = 0; i < input_array.Length; i++)
                {
                    input_array[i] = double.Parse(input_line[i]);
                }

                double[] output_array= new double[input_array.Length];

                Sort srt = new Sort();

                Stopwatch sWatch = new Stopwatch();

                
                switch (this.comboBox_sort_algorithm.SelectedItem)
                {
                    case "Вставкой(В)":
                        sWatch.Start();
                        output_array = srt.InsertionSortUp(input_array);
                        sWatch.Stop();
                        if (srt.CheckSortUp(output_array)) this.label_check_sorted(); else this.label_check_unsorted();
                        break;

                    case "Вставкой(У)":
                        sWatch.Start();
                        output_array = srt.InsertionSortDown(input_array);
                        sWatch.Stop();
                        if (srt.CheckSortDown(output_array)) this.label_check_sorted(); else this.label_check_unsorted();
                        break;
                }

                this.textBox_sort_time.Text = sWatch.Elapsed.ToString();
                
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < output_array.Length; i++)
                {
                    sb.Append(output_array[i]);
                    sb.Append(' ');
                }
                this.richTextBox__sort_output.AppendText(sb.ToString().Trim());
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label_check_sorted()
        {
            this.label_sort_check.Text = "Отсортировано";
        }

        private void label_check_unsorted()
        {
            this.label_sort_check.Text = "Не отсортировано";
        }

        #endregion

    }
}
