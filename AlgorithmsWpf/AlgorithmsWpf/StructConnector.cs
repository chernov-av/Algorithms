using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Linq;
using CommonTypes;
using System.Collections;
using System.Reflection.Metadata;

namespace AlgorithmsWpf
{
    class StructConnector : IModuleConnector
    {
        string path;
        Assembly asm;
        Type ExecutionAttribute;
        Type[] typesStruct;

        protected dynamic[] structure = new dynamic[4];

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
            string[] names = asm.GetTypes().SelectMany(m => m.GetCustomAttributes(ExecutionAttribute, false)).Select(k => pI.GetValue(k, null).ToString()).ToArray();
            
            //Invoke static method from static class Select
            for (int i = 0; i < typesStruct.Length; i++)
            {
                Type type = typesStruct[i];
                this.cmb.Items.Add(new CmbItems
                {
                    Name = names[i],
                    FuncStruct = (parameters) =>
                    {
                        //if struct constructor has no size param
                        if (typesStruct[(int)parameters[0]].GetConstructor(new Type[] { typeof(int) }) == null)
                        {
                            this.structure[(int)parameters[0]] = Activator.CreateInstance(typesStruct[(int)parameters[0]]);
                        }
                        else
                        {
                            this.structure[(int)parameters[0]] = Activator.CreateInstance(typesStruct[(int)parameters[0]], (int)parameters[1]);
                        }
                    },
                    FuncStructPush = (inputIndex, inputElement) =>
                    {
                        this.structure[inputIndex].Push(inputElement);
                    },
                    FuncStructPop = (inputIndex) =>
                    {
                        return this.structure[inputIndex].Pop();
                    },
                    FuncStructGet = (inputIndex) =>
                    {
                        return this.structure[inputIndex].GetStruct;
                    }                    
                });
            }

            cmb.SelectedIndex = 0;
        }    
    }
}
