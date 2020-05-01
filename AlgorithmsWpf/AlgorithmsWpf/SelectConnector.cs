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
    public class SelectConnector : IModuleConnector
    {
        string path;
        Assembly asm;
        Type ExecutionAttribute;
        Type Select;

        ComboBox cmb;

        public SelectConnector(string path, ComboBox cmb)
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
                this.Select = this.asm.GetType("LibSelect.Select");
                this.ExecutionAttribute = typeof(ExecuteAttribute);                
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
            //Invoke static method from static class Select
            for (int i = 0; i < methods.Length; i++)
            {
                MethodInfo method = methods[i];
                this.cmb.Items.Add(new CmbItems { Name = names[i], FuncSelect = (input) => { object[] args = { input }; Tuple<double, string> res = (Tuple<double, string>)method.Invoke(null, args); return res; } });
            }

            cmb.SelectedIndex = 0;
        }        
    }
}
