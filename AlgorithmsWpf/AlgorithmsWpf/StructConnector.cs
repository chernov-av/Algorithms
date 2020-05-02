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
    class StructConnector : IModuleConnector, IStack
    {
        string path;
        Assembly asm;
        Type ExecutionAttribute;
        Type[] typesStruct;

        dynamic[] structure = new dynamic[4];

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
            typesStruct = asm.GetTypes().Where(m => m.GetCustomAttributes(ExecutionAttribute, false).Length > 0).ToArray();

            //get name list
            PropertyInfo pI = ExecutionAttribute.GetProperty("Name");
            string[] names = asm.GetTypes().SelectMany(m => m.GetCustomAttributes(ExecutionAttribute, false)).Select(k=>pI.GetValue(k,null).ToString()).ToArray();
            
            //Invoke static method from static class Select
            for (int i = 0; i < typesStruct.Length; i++)
            {
                Type type = typesStruct[i];
                this.cmb.Items.Add(new CmbItems { Name = names[i], FuncStruct = (input) => { this.structure[input] = Activator.CreateInstance(typesStruct[input]); } });
            }

            cmb.SelectedIndex = 0;
        }    

        void IStack.Push(double newElement)
        {
            this.structure[3].Push(newElement);
        }

        double IStack.Pop()
        {
            return this.structure[3].Pop();
        }

        double[] IStack.GetStruct()
        {            
            return this.structure[3].GetStruct;
        }
    }
}
