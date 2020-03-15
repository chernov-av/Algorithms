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
using Microsoft.Win32;

namespace AlgorithmsWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class UI_Algorithms : Window
    {
        StructStack st;

        public UI_Algorithms()
        {
            InitializeComponent();
            InitSortTab();
            InitSelectTab();
            InitStructTab();
        }

        private void InitSortTab()
        {
            this.ComboBox_sort_algorithms.Items.Add(new CmbItems { Name = "Вставкой(В)", FuncSort = (input) => { Tuple<double[], string> res = Sort.InsertionSortUp(input); return res; }, CheckSort = (input) => { this.DisplayCheckSortUp(input); } });
            this.ComboBox_sort_algorithms.Items.Add(new CmbItems { Name = "Вставкой(У)", FuncSort = (input) => { Tuple<double[], string> res = Sort.InsertionSortDown(input); return res; }, CheckSort = (input) => { this.DisplayCheckSortDown(input); } });
            this.ComboBox_sort_algorithms.Items.Add(new CmbItems { Name = "Слиянием(В)", FuncSort = (input) => { Tuple<double[], string> res = Sort.MergeSortUp(input); return res; }, CheckSort = (input) => { this.DisplayCheckSortUp(input); } });
            this.ComboBox_sort_algorithms.Items.Add(new CmbItems { Name = "Слиянием(У)", FuncSort = (input) => { Tuple<double[], string> res = Sort.MergeSortDown(input); return res; }, CheckSort = (input) => { this.DisplayCheckSortDown(input); } });
            this.ComboBox_sort_algorithms.Items.Add(new CmbItems { Name = "Пузырьковая(В)", FuncSort = (input) => { Tuple<double[], string> res = Sort.BubbleSortUp(input); return res; }, CheckSort = (input) => { this.DisplayCheckSortUp(input); } });
            this.ComboBox_sort_algorithms.Items.Add(new CmbItems { Name = "Пузырьковая(У)", FuncSort = (input) => { Tuple<double[], string> res = Sort.BubbleSortDown(input); return res; }, CheckSort = (input) => { this.DisplayCheckSortDown(input); } });
            this.ComboBox_sort_algorithms.Items.Add(new CmbItems { Name = "Пирамидальная(В)", FuncSort = (input) => { Tuple<double[], string> res = Sort.HeapSortUp(input); return res; }, CheckSort = (input) => { this.DisplayCheckSortUp(input); } });
            this.ComboBox_sort_algorithms.Items.Add(new CmbItems { Name = "Пирамидальная(У)", FuncSort = (input) => { Tuple<double[], string> res = Sort.HeapSortDown(input); return res; }, CheckSort = (input) => { this.DisplayCheckSortDown(input); } });
            this.ComboBox_sort_algorithms.Items.Add(new CmbItems { Name = "Быстрая(В)", FuncSort = (input) => { Tuple<double[], string> res = Sort.QuickSortUp(input); return res; }, CheckSort = (input) => { this.DisplayCheckSortUp(input); } });
            this.ComboBox_sort_algorithms.Items.Add(new CmbItems { Name = "Быстрая(У)", FuncSort = (input) => { Tuple<double[], string> res = Sort.QuickSortDown(input); return res; }, CheckSort = (input) => { this.DisplayCheckSortDown(input); } });
            this.ComboBox_sort_algorithms.Items.Add(new CmbItems { Name = "Быстрая(Сл,В)", FuncSort = (input) => { Tuple<double[], string> res = Sort.QuickSortRandomizedUp(input); return res; }, CheckSort = (input) => { this.DisplayCheckSortUp(input); } });
            this.ComboBox_sort_algorithms.Items.Add(new CmbItems { Name = "Быстрая(Сл,У)", FuncSort = (input) => { Tuple<double[], string> res = Sort.QuickSortRandomizedDown(input); return res; }, CheckSort = (input) => { this.DisplayCheckSortDown(input); } });
            this.ComboBox_sort_algorithms.Items.Add(new CmbItems { Name = "Подсчетом(В)", FuncSort = (input) => { Tuple<double[], string> res = Sort.CountingSortUp(input); return res; }, CheckSort = (input) => { this.DisplayCheckSortUp(input); } });
            this.ComboBox_sort_algorithms.Items.Add(new CmbItems { Name = "Подсчетом(У)", FuncSort = (input) => { Tuple<double[], string> res = Sort.CountingSortDown(input); return res; }, CheckSort = (input) => { this.DisplayCheckSortDown(input); } });

            this.ComboBox_sort_algorithms.SelectedIndex = 0;
        }

        private void InitSelectTab()
        {
            this.ComboBox_select_algorithms.Items.Add(new CmbItems { Name = "Минимум", FuncSelect = (input) => { Tuple<double, string> res = Select.Minimum(input); return res; } });
            this.ComboBox_select_algorithms.Items.Add(new CmbItems { Name = "Максимум", FuncSelect = (input) => { Tuple<double, string> res = Select.Maximum(input); return res; } });
            this.ComboBox_select_algorithms.Items.Add(new CmbItems { Name = "Сл. выбор макс.", FuncSelect = (input) => { Tuple<double, string> res = Select.SelectRandomizedMax(input); return res; } });
            this.ComboBox_select_algorithms.Items.Add(new CmbItems { Name = "Сл. выбор мин.", FuncSelect = (input) => { Tuple<double, string> res = Select.SelectRandomizedMin(input); return res; } });
            this.ComboBox_select_algorithms.Items.Add(new CmbItems { Name = "Медиана О(nlogn)", FuncSelect = (input) => { Tuple<double, string> res = Select.Median_nlogn(input); return res; } });
            this.ComboBox_select_algorithms.Items.Add(new CmbItems { Name = "Медиана О(n)", FuncSelect = (input) => { Tuple<double, string> res = Select.Median_n(input); return res; } });

            this.ComboBox_select_algorithms.SelectedIndex = 0;
        }

        private void InitStructTab()
        {
            this.ComboBox_struct.Items.Add(new CmbItems { Name = "Стек", FuncStruct = ()=> { st = new StructStack(); } });
            this.ComboBox_struct.Items.Add(new CmbItems { Name = "Очередь" });
            this.ComboBox_struct.SelectedIndex = 0;
        }

        private void Button_sort_gen_rand_Click(object sender, RoutedEventArgs e)
        {
            this.RichTextBox_input.Document.Blocks.Clear();

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
                        input_array[i] = Math.Round(rand.NextDouble() * max, 2);
                    }

                    sb.Append(input_array[i]);
                    sb.Append(' ');
                }
                this.RichTextBox_input.AppendText(sb.ToString().Trim());
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region Sort

        private void Button_sort_Click(object sender, RoutedEventArgs e)
        {
            this.RichTextBox_output.Document.Blocks.Clear();

            double[] input_array = this.readInput(this.RichTextBox_input);
            double[] output_array = new double[input_array.Length];

            Tuple<double[], string> res = ((CmbItems)this.ComboBox_sort_algorithms.SelectedItem).FuncSort(input_array);
            output_array = res.Item1;
            this.TextBox_time.Text = res.Item2;

            ((CmbItems)this.ComboBox_sort_algorithms.SelectedItem).CheckSort(output_array);

            TabItem selectedTab = (this.TabControl_Algorithms.SelectedItem as TabItem);
            this.DisplayAction(selectedTab.Header.ToString(), this.ComboBox_sort_algorithms.SelectedValue.ToString(), res.Item2);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < output_array.Length; i++)
            {
                sb.Append(output_array[i]);
                sb.Append(' ');
            }
            this.RichTextBox_output.AppendText(sb.ToString().Trim());
        }

        #region Heap
        private void Button_sort_build_max_heap_Click(object sender, RoutedEventArgs e)
        {
            this.RichTextBox_output.Document.Blocks.Clear();            

            try
            {
                string[] input_line = this.readRichtextbox(this.RichTextBox_input).Split(' ');
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
                this.RichTextBox_output.AppendText(sb.ToString().Trim());
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_sort_build_min_heap_Click(object sender, RoutedEventArgs e)
        {
            this.RichTextBox_output.Document.Blocks.Clear();            

            try
            {
                string[] input_line = this.readRichtextbox(this.RichTextBox_input).Split(' ');
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
                this.RichTextBox_output.AppendText(sb.ToString().Trim());
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #endregion

        #region Choosing

        private void Button_select_Click(object sender, RoutedEventArgs e)
        {
            this.RichTextBox_output.Document.Blocks.Clear();

            double[] input_array = this.readInput(this.RichTextBox_input);

            Tuple<double, string> res = ((CmbItems)this.ComboBox_select_algorithms.SelectedItem).FuncSelect(input_array);
            double output = res.Item1;
            this.TextBox_time.Text = res.Item2;

            TabItem selectedTab = (this.TabControl_Algorithms.SelectedItem as TabItem);
            this.DisplayAction(selectedTab.Header.ToString(), this.ComboBox_select_algorithms.SelectedValue.ToString(), res.Item2);

            StringBuilder sb = new StringBuilder();

            sb.Append(output);
            sb.Append(' ');

            this.RichTextBox_output.AppendText(sb.ToString().Trim());
        }

        #endregion

        #region Struct


        private void Button_struct_Click(object sender, RoutedEventArgs e)
        {
            this.RichTextBox_output.Document.Blocks.Clear();
            ((CmbItems)this.ComboBox_struct.SelectedItem).FuncStruct();

            TabItem selectedTab = (this.TabControl_Algorithms.SelectedItem as TabItem);

            this.DisplayAction(selectedTab.Header.ToString(), this.ComboBox_struct.SelectedValue.ToString(), "Cоздан");

           /* StringBuilder sb = new StringBuilder();
            for (int i = 0; i < res.GetStruct(); i++)
            {
                sb.Append(output_array[i]);
                sb.Append(' ');
            }
            this.RichTextBox_output.AppendText(sb.ToString().Trim());*/
        }

        private void Button_struct_add_Click(object sender, RoutedEventArgs e)
        {
            this.RichTextBox_output.Document.Blocks.Clear();
            try
            {
                switch (this.ComboBox_struct.SelectedItem.ToString())
                {
                    case "Стек":
                        double newElement = Double.Parse(this.TextBox_struct.Text);
                        st.Push(newElement);
                        break;

                    case "Очередь":
                        break;
                }
                TabItem selectedTab = (this.TabControl_Algorithms.SelectedItem as TabItem);
                this.DisplayAction(selectedTab.Header.ToString(), this.ComboBox_struct.SelectedValue.ToString(), "Добавлен");
                DisplayStruct();

            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_struct_remove_Click(object sender, RoutedEventArgs e)
        {
            this.RichTextBox_output.Document.Blocks.Clear();
            try
            {
                switch (this.ComboBox_struct.SelectedItem.ToString())
                {
                    case "Стек":                        
                        st.Pop();
                        break;

                    case "Очередь":
                        break;
                }
                TabItem selectedTab = (this.TabControl_Algorithms.SelectedItem as TabItem);
                this.DisplayAction(selectedTab.Header.ToString(), this.ComboBox_struct.SelectedValue.ToString(), "Добавлен");
                DisplayStruct();

            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
#endregion

        #region  Menu
        private void MenuItemOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openDlg = new OpenFileDialog();
            openDlg.ShowDialog();
        }

        private void MenuItemSave_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.ShowDialog();
        }

        private void MenuItemExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MenuItemTest_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            int[] array = new int[20];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(5);
            }
            string toDisplay = string.Join(Environment.NewLine, array);
            MessageBox.Show(toDisplay);
        }


        #endregion

        
    }
}
