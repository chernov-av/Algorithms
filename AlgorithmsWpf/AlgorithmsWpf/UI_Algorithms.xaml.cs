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
        StructStack stackStruct;
        StructQueue queueStruct;
        StructDeque dequeStruct;
        StructLinkedList linkedListStruct;
        BinaryTree<double> binaryTree;

        GetHeap getMaxHeap;
        GetHeap getMinHeap;

        string defaultModulePath = "Modules/";       

        public UI_Algorithms()
        {
            InitializeComponent();

            loadExternalModule();            
        }

        private void loadExternalModule()
        {
            //Connect SortLib
            IModuleConnector sortConnection = new SortConnector(defaultModulePath + "LibSort", this.ComboBox_sort_algorithms, this.TextBlockLog);
            //IConnector
            sortConnection.Connect();
            sortConnection.InitTab();
            //IHeap
            this.getMaxHeap = ((IHeap)sortConnection).SortMaxFunc;
            this.getMinHeap = ((IHeap)sortConnection).SortMinFunc;

            //Connect SelectLib
            IModuleConnector selectConnection = new SelectConnector(defaultModulePath + "LibSelect", this.ComboBox_select_algorithms);
            //IConnector
            selectConnection.Connect();
            selectConnection.InitTab();

            InitStructTab();
            InitTreeTab();
        }  
                

        private void InitStructTab()
        {
            this.ComboBox_struct.Items.Add(new CmbItems { Name = "Стек", FuncStruct = () => { stackStruct = new StructStack(); } });
            this.ComboBox_struct.Items.Add(new CmbItems { Name = "Очередь", FuncStruct = () => { queueStruct = new StructQueue(Int32.Parse(this.TextBox_struct.Text)); } });
            this.ComboBox_struct.Items.Add(new CmbItems { Name = "Дек", FuncStruct = () => { dequeStruct = new StructDeque(); } });
            this.ComboBox_struct.Items.Add(new CmbItems { Name = "Связанный список", FuncStruct = () => { linkedListStruct = new StructLinkedList(); } });
            this.ComboBox_struct.SelectedIndex = 0;
        }

        private void InitTreeTab()
        {
            this.ComboBox_tree.Items.Add(new CmbItems { Name = "Бинарное", FuncTree = () => { binaryTree = new BinaryTree<double>(); } });

            this.ComboBox_tree.SelectedIndex = 0;
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

            ((CmbItems)this.ComboBox_sort_algorithms.SelectedItem).CheckSort(output_array, this.ComboBox_sort_algorithms.SelectedIndex);

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

                output_array = this.getMaxHeap(input_array);

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

                output_array = this.getMinHeap(input_array);

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

            this.DisplayAction(selectedTab.Header.ToString(), this.ComboBox_struct.SelectedValue.ToString(), "Структура создана");
        }

        private void Button_struct_add_Click(object sender, RoutedEventArgs e)
        {
            this.RichTextBox_output.Document.Blocks.Clear();
            try
            {
                double newElement;
                TabItem selectedTab = (this.TabControl_Algorithms.SelectedItem as TabItem);

                switch (this.ComboBox_struct.SelectedItem.ToString())
                {
                    case "Стек":
                        newElement = Double.Parse(this.TextBox_struct.Text);
                        stackStruct.Push(newElement);
                        this.DisplayAction(selectedTab.Header.ToString(), this.ComboBox_struct.SelectedValue.ToString(), this.TextBox_struct.Text.ToString() + " добавлен");
                        break;

                    case "Очередь":
                        newElement = Double.Parse(this.TextBox_struct.Text);
                        queueStruct.Enqueue(newElement);
                        this.DisplayAction(selectedTab.Header.ToString(), this.ComboBox_struct.SelectedValue.ToString(), this.TextBox_struct.Text.ToString() + " добавлен");
                        break;

                    case "Дек":
                        newElement = Double.Parse(this.TextBox_struct.Text);
                        if (this.SliderDeque.Value == 0)
                        {
                            dequeStruct.PushLeft(newElement);
                        }
                        else
                        {
                            dequeStruct.PushRight(newElement);
                        }
                        this.DisplayAction(selectedTab.Header.ToString(), this.ComboBox_struct.SelectedValue.ToString(), this.TextBox_struct.Text.ToString() + " добавлен");
                        break;

                    case "Связанный список":
                        newElement = Double.Parse(this.TextBox_struct.Text);
                        linkedListStruct.ListInsert(newElement);
                        this.DisplayAction(selectedTab.Header.ToString(), this.ComboBox_struct.SelectedValue.ToString(), this.TextBox_struct.Text.ToString() + " добавлен");
                        break;
                }
                DisplayStruct();
            }
            catch (SystemException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_struct_remove_Click(object sender, RoutedEventArgs e)
        {
            this.RichTextBox_output.Document.Blocks.Clear();
            try
            {
                double extractedElement = 0;
                TabItem selectedTab = (this.TabControl_Algorithms.SelectedItem as TabItem);

                switch (this.ComboBox_struct.SelectedItem.ToString())
                {
                    case "Стек":
                        extractedElement = stackStruct.Pop();
                        this.DisplayAction(selectedTab.Header.ToString(), this.ComboBox_struct.SelectedValue.ToString(), extractedElement.ToString() + " извлечен");
                        break;

                    case "Очередь":
                        extractedElement = queueStruct.Dequeue();
                        this.DisplayAction(selectedTab.Header.ToString(), this.ComboBox_struct.SelectedValue.ToString(), extractedElement.ToString() + " извлечен");
                        break;

                    case "Дек":
                        if (this.SliderDeque.Value == 0)
                        {
                            extractedElement = dequeStruct.PopLeft();
                        }
                        else
                        {
                            extractedElement = dequeStruct.PopRight();
                        }
                        this.DisplayAction(selectedTab.Header.ToString(), this.ComboBox_struct.SelectedValue.ToString(), extractedElement.ToString() + " извлечен");
                        break;

                    case "Связанный список":
                        extractedElement = Double.Parse(this.TextBox_struct.Text);
                        linkedListStruct.ListDelete(linkedListStruct.ListSearch(extractedElement));
                        this.DisplayAction(selectedTab.Header.ToString(), this.ComboBox_struct.SelectedValue.ToString(), extractedElement.ToString() + " извлечен");
                        break;
                }
                DisplayStruct();
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (SystemException ex)
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

        private void Button_tree_Click(object sender, RoutedEventArgs e)
        {
            this.RichTextBox_output.Document.Blocks.Clear();
            ((CmbItems)this.ComboBox_tree.SelectedItem).FuncTree();

            TabItem selectedTab = (this.TabControl_Algorithms.SelectedItem as TabItem);

            this.DisplayAction(selectedTab.Header.ToString(), this.ComboBox_struct.SelectedValue.ToString(), "Дерево создано");
        }

        private void Button_tree_add_Click(object sender, RoutedEventArgs e)
        {
            this.RichTextBox_output.Document.Blocks.Clear();
            try
            {
                double newElement;
                TabItem selectedTab = (this.TabControl_Algorithms.SelectedItem as TabItem);

                switch (this.ComboBox_tree.SelectedItem.ToString())
                {
                    case "Бинарное":
                        newElement = Double.Parse(this.TextBox_tree.Text);
                        this.binaryTree.TreeInsert(newElement);
                        this.DisplayAction(selectedTab.Header.ToString(), this.ComboBox_tree.SelectedValue.ToString(), this.TextBox_tree.Text.ToString() + " добавлен");
                        break;
                }
                DisplayTree();
            }
            catch (SystemException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_tree_remove_Click(object sender, RoutedEventArgs e)
        {
            this.RichTextBox_output.Document.Blocks.Clear();
            try
            {
                double deletedElement;
                TabItem selectedTab = (this.TabControl_Algorithms.SelectedItem as TabItem);

                switch (this.ComboBox_tree.SelectedItem.ToString())
                {
                    case "Бинарное":
                        deletedElement = Double.Parse(this.TextBox_tree.Text);
                        this.binaryTree.TreeDelete(deletedElement);
                        this.DisplayAction(selectedTab.Header.ToString(), this.ComboBox_tree.SelectedValue.ToString(), deletedElement.ToString() + " извлечен");
                        break;
                }
                DisplayTree();
            }
            catch (System.NullReferenceException ex)
            {
                MessageBox.Show(ex.Message);
                DisplayTree();
            }
            catch (SystemException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
