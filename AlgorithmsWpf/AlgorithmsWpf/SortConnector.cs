using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Linq;

namespace AlgorithmsWpf
{
    public class SortConnector: IModuleConnector, IHeap
    {
        string path;
        Assembly asm;
        Type ExecutionAttribute;
        Type Sort;
        Type Heap;

        dynamic sort;
        dynamic heap;

        ComboBox cmb;
        TextBlock txb;

        public SortConnector(string path, ComboBox cmb, TextBlock txb)
        {
            this.path = path;
            this.cmb = cmb;
            this.txb = txb;
        }

        public void Connect()
        {
            LoadAssembly();
            GetTypes();
        }

        void LoadAssembly()
        {
            try
            {
                asm = Assembly.LoadFrom(this.path);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Error loading module: {ex.Message}");
            }
        }

        void GetTypes()
        {
            try
            {
                this.Sort = this.asm.GetType("LibSort.Sort");
                this.Heap = this.asm.GetType("LibSort.Heap");
                this.ExecutionAttribute = this.asm.GetType("LibSort.ExecuteAttribute");
                this.sort = Activator.CreateInstance(this.Sort);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Error creating types or instances: {ex.Message}");
            }           
        }

        public void InitTab()
        {
            //get method list
            MethodInfo[] methods = asm.GetTypes().SelectMany(t => t.GetMethods())
                      .Where(m => m.GetCustomAttributes(ExecutionAttribute, false).Length > 0)
                      .ToArray();

            //get name list
            PropertyInfo pI = ExecutionAttribute.GetProperty("Name");
            string[] names = asm.GetTypes().SelectMany(t => t.GetMethods()).SelectMany(m => m.GetCustomAttributes(ExecutionAttribute, false)).Select(k => pI.GetValue(k, null).ToString()).ToArray();

            for (int i = 0; i < methods.Length; i++)
            {
                MethodInfo method = methods[i];
                this.cmb.Items.Add(new CmbItems { Name = names[i], FuncSort = (input) => { object[] args = { input }; Tuple<double[], string> res = method.Invoke(sort, args); return res; }, CheckSort = (input, index) => { DisplayCheckSort(input, index); } });
            }

            cmb.SelectedIndex = 0;            
        }

        private void DisplayCheckSort(double[] input, int index)
        {
            if (index % 2 == 0)
            {
                this.DisplayCheckSortUp(input);
            }
            else this.DisplayCheckSortDown(input);
        }

        private void DisplayCheckSortUp(double[] input)
        {
            if (sort.CheckSortUp(input)) this.txb.Text = "Отсортировано"; else this.txb.Text = "Не отсортировано";
        }

        private void DisplayCheckSortDown(double[] input)
        {
            if (sort.CheckSortDown(input)) this.txb.Text = "Отсортировано"; else this.txb.Text = "Не отсортировано";
        }

        private void BuildHeapInstance(double[] input)
        {
            this.heap = Activator.CreateInstance(this.Heap, input);
        }

        private void BuildMaxHeap()
        {
            this.heap.BuildMaxHeap();
        }

        private void BuildMinHeap()
        {
            this.heap.BuildMinHeap();
        }

        private double[] GetHeap()
        {
            return this.heap.GetHeap();
        }

        public double[] SortMaxFunc(double[] input)
        {
            BuildHeapInstance(input);
            BuildMaxHeap();
            return GetHeap();
        }

        public double[] SortMinFunc(double[] input)
        {
            BuildHeapInstance(input);
            BuildMinHeap();
            return GetHeap();
        }

    }
}
