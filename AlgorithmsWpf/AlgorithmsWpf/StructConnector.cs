using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Linq;
using CommonTypes;

namespace AlgorithmsWpf
{
    class StructConnector : IModuleConnector
    {
        string path;
        Assembly asm;
        Type ExecutionAttribute;
        Type Select;

        ComboBox cmb;

        public StructConnector(string path, ComboBox cmb)
        {
            this.path = path;
            this.cmb = cmb;
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
               // this.Select = this.asm.GetType("LibStructures.Select");
                this.ExecutionAttribute = typeof(ExecuteClassAttribute);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Error creating types or instances: {ex.Message}");
            }
        }

        public void InitTab()
        {
            //get method list
            Type[] types = asm.GetTypes().Where(m => m.GetCustomAttributes(ExecutionAttribute, false).Length > 0)
                      .ToArray();

            //get name list
            PropertyInfo pI = ExecutionAttribute.GetProperty("Name");
            //string[] names = asm.GetTypes().SelectMany(t => t.GetMethods()).SelectMany(m => m.GetCustomAttributes(ExecutionAttribute, false)).Select(k => pI.GetValue(k, null).ToString()).ToArray();
            //Invoke static method from static class Select
            for (int i = 0; i < types.Length; i++)
            {
                Type type = types[i];
                this.cmb.Items.Add(new CmbItems { Name = type.ToString(), FuncSelect = (input) => { object[] args = { input }; Tuple<double, string> res = new Tuple<double, string>(1,""); return res; } });
            }

            cmb.SelectedIndex = 0;
        }
    }
}
