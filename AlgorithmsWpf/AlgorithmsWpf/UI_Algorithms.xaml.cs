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
using Algorithms.Data;

namespace AlgorithmsWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class UI_Algorithms : Window
    {
        public UI_Algorithms()
        {
            InitializeComponent();
            InitSortTab();
        }

        private void InitSortTab()
        {
            this.Label_sort_check.Content = "";
            this.RichTextBox_sort_output.IsReadOnly = true;
            this.RichTextBox_sort_output.Background = Brushes.White;
            this.Richtextbox_log.SetValue(Paragraph.LineHeightProperty, 1.5);

            this.Richtextbox_log.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;

            this.ComboBox_sort_algorithms.Items.Add(new CmbItems { Name = "Вставкой(В)", Func = (input) => { Tuple<double[], string> res = Sort.InsertionSortUp(input); return res; }, Check = (input) => { this.DisplayCheckSortUp(input); } });
            this.ComboBox_sort_algorithms.Items.Add(new CmbItems { Name = "Вставкой(У)", Func = (input) => { Tuple<double[], string> res = Sort.InsertionSortDown(input); return res; }, Check = (input) => { this.DisplayCheckSortDown(input); } });
            this.ComboBox_sort_algorithms.Items.Add(new CmbItems { Name = "Слиянием(В)", Func = (input) => { Tuple<double[], string> res = Sort.MergeSortUp(input); return res; }, Check = (input) => { this.DisplayCheckSortUp(input); } });
            this.ComboBox_sort_algorithms.Items.Add(new CmbItems { Name = "Слиянием(У)", Func = (input) => { Tuple<double[], string> res = Sort.MergeSortDown(input); return res; }, Check = (input) => { this.DisplayCheckSortDown(input); } });
            this.ComboBox_sort_algorithms.Items.Add(new CmbItems { Name = "Пузырьковая(В)", Func = (input) => { Tuple<double[], string> res = Sort.BubbleSortUp(input); return res; }, Check = (input) => { this.DisplayCheckSortUp(input); } });
            this.ComboBox_sort_algorithms.Items.Add(new CmbItems { Name = "Пузырьковая(У)", Func = (input) => { Tuple<double[], string> res = Sort.BubbleSortDown(input); return res; }, Check = (input) => { this.DisplayCheckSortDown(input); } });
            this.ComboBox_sort_algorithms.Items.Add(new CmbItems { Name = "Пирамидальная(В)", Func = (input) => { Tuple<double[], string> res = Sort.HeapSortUp(input); return res; }, Check = (input) => { this.DisplayCheckSortUp(input); } });
            this.ComboBox_sort_algorithms.Items.Add(new CmbItems { Name = "Пирамидальная(У)", Func = (input) => { Tuple<double[], string> res = Sort.HeapSortDown(input); return res; }, Check = (input) => { this.DisplayCheckSortDown(input); } });
            this.ComboBox_sort_algorithms.Items.Add(new CmbItems { Name = "Быстрая(В)", Func = (input) => { Tuple<double[], string> res = Sort.QuickSortUp(input); return res; }, Check = (input) => { this.DisplayCheckSortUp(input); } });
            this.ComboBox_sort_algorithms.Items.Add(new CmbItems { Name = "Быстрая(У)", Func = (input) => { Tuple<double[], string> res = Sort.QuickSortDown(input); return res; }, Check = (input) => { this.DisplayCheckSortDown(input); } });
            this.ComboBox_sort_algorithms.Items.Add(new CmbItems { Name = "Быстрая(Сл,В)", Func = (input) => { Tuple<double[], string> res = Sort.QuickSortRandomizedUp(input); return res; }, Check = (input) => { this.DisplayCheckSortUp(input); } });
            this.ComboBox_sort_algorithms.Items.Add(new CmbItems { Name = "Быстрая(Сл,У)", Func = (input) => { Tuple<double[], string> res = Sort.QuickSortRandomizedDown(input); return res; }, Check = (input) => { this.DisplayCheckSortDown(input); } });
            this.ComboBox_sort_algorithms.Items.Add(new CmbItems { Name = "Подсчетом(В)", Func = (input) => { Tuple<double[], string> res = Sort.CountingSortUp(input); return res; }, Check = (input) => { this.DisplayCheckSortUp(input); } });
            this.ComboBox_sort_algorithms.Items.Add(new CmbItems { Name = "Подсчетом(У)", Func = (input) => { Tuple<double[], string> res = Sort.CountingSortDown(input); return res; }, Check = (input) => { this.DisplayCheckSortDown(input); } });

            this.ComboBox_sort_algorithms.SelectedIndex = 0;
        }
  
        #region Display
        private void DisplayCheckSortUp(double[] input)
        {
            if (Sort.CheckSortUp(input)) this.Label_sort_check.Content = "Отсортировано"; else this.Label_sort_check.Content = "Не отсортировано";
        }

        private void DisplayCheckSortDown(double[] input)
        {
            if (Sort.CheckSortDown(input)) this.Label_sort_check.Content = "Отсортировано"; else this.Label_sort_check.Content = "Не отсортировано";
        }

        private void DisplayAction(string algorithm, string method, string time)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(algorithm + '\n');
            sb.Append(method + '\n');
            sb.Append(time + '\n');
            sb.Append(this.Label_sort_check.Content.ToString() + '\n');
            sb.Append("----------------------");
            this.Richtextbox_log.AppendText(sb.ToString().Trim() + '\n');
            this.Richtextbox_log.ScrollToEnd();
        }
        #endregion

        #region Sort
        private void Button_sort_gen_rand_Click(object sender, RoutedEventArgs e)
        {
            this.RichTextBox_sort_input.Document.Blocks.Clear();

            try
            {
                int n = Int32.Parse(this.TextBox_sort_length.Text);
                int max = Int32.Parse(this.TextBox_sort_max_value.Text);

                double[] input_array = new double[n];

                Random rand = new Random();

                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < n; i++)
                {
                    if (this.CheckBox_sort_gen_only_int.IsChecked.Value)
                    {
                        input_array[i] = rand.Next(max);
                    }
                    else
                    {                        
                        input_array[i] = Math.Round(rand.NextDouble()*max,2);
                    }

                    sb.Append(input_array[i]);
                    sb.Append(' ');
                }
                this.RichTextBox_sort_input.AppendText(sb.ToString().Trim());
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_sort_Click(object sender, RoutedEventArgs e)
        {
            this.RichTextBox_sort_output.Document.Blocks.Clear();
            this.Label_sort_check.Content = "";

            try
            {
                string[] input_line = this.readRichtextbox(this.RichTextBox_sort_input).Split(' ');
                double[] input_array = new double[input_line.Length];

                for (int i = 0; i < input_array.Length; i++)
                {
                    input_array[i] = double.Parse(input_line[i]);
                }

                double[] output_array = new double[input_array.Length];

                Tuple<double[], string> res = ((CmbItems)this.ComboBox_sort_algorithms.SelectedItem).Func(input_array);
                output_array = res.Item1;
                this.TextBox_sort_time.Text = res.Item2;

                ((CmbItems)this.ComboBox_sort_algorithms.SelectedItem).Check(output_array);

                TabItem selectedTab = (this.TabControl_Algorithms.SelectedItem as TabItem);
                this.DisplayAction(selectedTab.Header.ToString(), this.ComboBox_sort_algorithms.SelectedValue.ToString(), res.Item2);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < output_array.Length; i++)
                {
                    sb.Append(output_array[i]);
                    sb.Append(' ');
                }
                this.RichTextBox_sort_output.AppendText(sb.ToString().Trim());
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        #region Heap
        private void Button_sort_build_max_heap_Click(object sender, RoutedEventArgs e)
        {
            this.RichTextBox_sort_output.Document.Blocks.Clear();
            this.Label_sort_check.Content = "";

            try
            {
                string[] input_line = this.readRichtextbox(this.RichTextBox_sort_input).Split(' ');
                double[] input_array = new double[input_line.Length];


                for (int i = 0; i < input_array.Length; i++)
                {
                    input_array[i] = double.Parse(input_line[i]);
                }

                double[] output_array = new double[input_array.Length];

                Heap heap = new Heap(input_array);

                heap.BuildMaxHeap();
                output_array = heap.GetHeap();

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < output_array.Length; i++)
                {
                    sb.Append(output_array[i]);
                    sb.Append(' ');
                }
                this.RichTextBox_sort_output.AppendText(sb.ToString().Trim());
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_sort_build_min_heap_Click(object sender, RoutedEventArgs e)
        {
            this.RichTextBox_sort_output.Document.Blocks.Clear();
            this.Label_sort_check.Content = "";

            try
            {
                string[] input_line = this.readRichtextbox(this.RichTextBox_sort_input).Split(' ');
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
                this.RichTextBox_sort_output.AppendText(sb.ToString().Trim());
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #endregion

        #region helpFunctions
        private string readRichtextbox(RichTextBox RTB)
        {             
            return new TextRange(RTB.Document.ContentStart,RTB.Document.ContentEnd).Text;
        }
        #endregion

        

    }
}
