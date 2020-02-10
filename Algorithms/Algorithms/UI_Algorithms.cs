using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            this.InitSortTab();
        }
        
        private void Init()
        {
            
        }

        private void InitSortTab()
        {
            
            this.label_sort_check.Text = "";
            this.richTextBox__sort_output.ReadOnly = true;
            this.richTextBox__sort_output.BackColor = System.Drawing.SystemColors.Window;

            this.comboBox_sort_algorithm.Items.Add(new CmbItems { Name = "Вставкой(В)", Func = (input) => { Tuple<double[],string> res = Sort.InsertionSortUp(input);  return res; }, Check=(input) => { this.DisplayCheckSortUp(input); } });
            this.comboBox_sort_algorithm.Items.Add(new CmbItems { Name = "Вставкой(У)", Func = (input) => { Tuple<double[], string> res = Sort.InsertionSortDown(input); return res; }, Check = (input) => { this.DisplayCheckSortDown(input); } });
            this.comboBox_sort_algorithm.Items.Add(new CmbItems { Name="Слиянием(В)",Func=(input)=> { Tuple<double[], string> res = Sort.MergeSortUpCaller(input);return res; }, Check=(input) => { this.DisplayCheckSortUp(input); } });
            this.comboBox_sort_algorithm.Items.Add(new CmbItems { Name = "Слиянием(У)", Func = (input) => { Tuple<double[], string> res = Sort.MergeSortDownCaller(input); return res; }, Check = (input) => { this.DisplayCheckSortDown(input); } });
            this.comboBox_sort_algorithm.Items.Add(new CmbItems { Name = "Пузырьковая(В)", Func = (input) => { Tuple<double[], string> res = Sort.BubbleSortUp(input); return res; }, Check = (input) => { this.DisplayCheckSortUp(input); } });
            this.comboBox_sort_algorithm.Items.Add(new CmbItems { Name = "Пузырьковая(У)", Func = (input) => { Tuple<double[], string> res = Sort.BubbleSortDown(input); return res; }, Check = (input) => { this.DisplayCheckSortDown(input); } });
            this.comboBox_sort_algorithm.Items.Add(new CmbItems { Name = "Пирамидальная(В)", Func = (input) => { Tuple<double[], string> res = Sort.HeapSortUp(input); return res; }, Check = (input) => { this.DisplayCheckSortUp(input); } });
            this.comboBox_sort_algorithm.Items.Add(new CmbItems { Name = "Пирамидальная(У)", Func = (input) => { Tuple<double[], string> res = Sort.HeapSortDown(input); return res; }, Check = (input) => { this.DisplayCheckSortDown(input); } });
            this.comboBox_sort_algorithm.Items.Add(new CmbItems { Name = "Быстрая(В)", Func = (input) => { Tuple<double[], string> res = Sort.QuickSortUpCaller(input); return res; }, Check = (input) => { this.DisplayCheckSortUp(input); } });
            this.comboBox_sort_algorithm.Items.Add(new CmbItems { Name = "Быстрая(У)", Func = (input) => { Tuple<double[], string> res = Sort.QuickSortDownCaller(input); return res; }, Check = (input) => { this.DisplayCheckSortDown(input); } });
            this.comboBox_sort_algorithm.SelectedIndex = 0;
        }               

        #region Sort
        private void button_generate_input_Click(object sender, EventArgs e)
        {
            //get input array length
            this.richTextBox_sort_input.Clear();

            try
            {
                int n = Int32.Parse(this.textBox_sort_input_length.Text);
                int max = Int32.Parse(this.textBox_sort_max_value.Text);

                double[] input_array = new double[n];

                Random rand = new Random();

                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < n; i++)
                {
                    if (this.checkBox_generate_int.Checked)
                    {
                        input_array[i] = rand.Next(max);
                    }
                    else
                    {
                        input_array[i] = rand.Next(max) + Math.Round(rand.NextDouble(), 2);
                    }
                    
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
            this.label_sort_check.Text = "";

            try
            {
                string[] input_line = this.richTextBox_sort_input.Text.Split(' ');
                double[] input_array = new double[input_line.Length];

                for (int i = 0; i < input_array.Length; i++)
                {
                    input_array[i] = double.Parse(input_line[i]);
                }

                double[] output_array= new double[input_array.Length];

                Tuple<double[], string> res = ((CmbItems)this.comboBox_sort_algorithm.SelectedItem).Func(input_array);
                output_array =res.Item1;
                this.textBox_sort_time.Text = res.Item2;

                ((CmbItems)this.comboBox_sort_algorithm.SelectedItem).Check(output_array);
                
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
        #endregion

        #region Display
        private void DisplayCheckSortUp(double[] input)
        {
            if (Sort.CheckSortUp(input)) this.label_sort_check.Text = "Отсортировано"; else this.label_sort_check.Text = "Не отсортировано";
        }
        private void DisplayCheckSortDown(double[] input)
        {
            if (Sort.CheckSortDown(input)) this.label_sort_check.Text = "Отсортировано"; else this.label_sort_check.Text = "Не отсортировано";
        }
        #endregion

        private void button_max_heap_Click(object sender, EventArgs e)
        {
            this.richTextBox__sort_output.Clear();
            this.label_sort_check.Text = "";

            try
            {
                string[] input_line = this.richTextBox_sort_input.Text.Split(' ');
                double[] input_array = new double[input_line.Length];


                for (int i = 0; i < input_array.Length; i++)
                {
                    input_array[i] = double.Parse(input_line[i]);
                }

                double[] output_array = new double[input_array.Length];

                Heap heap = new Heap(input_array);

                heap.BuildMaxHeap();
                //heap.BuildMinHeap();
                output_array = heap.GetHeap();

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

        private void button_min_heap_Click(object sender, EventArgs e)
        {
            this.richTextBox__sort_output.Clear();
            this.label_sort_check.Text = "";

            try
            {
                string[] input_line = this.richTextBox_sort_input.Text.Split(' ');
                double[] input_array = new double[input_line.Length];


                for (int i = 0; i < input_array.Length; i++)
                {
                    input_array[i] = double.Parse(input_line[i]);
                }

                double[] output_array = new double[input_array.Length];

                Heap heap = new Heap(input_array);

                heap.BuildMinHeap();
                output_array = heap.GetHeap();

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

        private void button_test_Click(object sender, EventArgs e)
        {
            this.richTextBox__sort_output.Clear();
            this.label_sort_check.Text = "";

            try
            {
                string[] input_line = this.richTextBox_sort_input.Text.Split(' ');
                double[] input_array = new double[input_line.Length];


                for (int i = 0; i < input_array.Length; i++)
                {
                    input_array[i] = double.Parse(input_line[i]);
                }

                double[] output_array = new double[input_array.Length];

                Heap heap = new Heap(input_array);

                heap.BuildMaxHeap();
                //heap.BuildMinHeap();
                heap.MaxHeapInsert(15);
                output_array = heap.GetHeap();

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
    }
}
