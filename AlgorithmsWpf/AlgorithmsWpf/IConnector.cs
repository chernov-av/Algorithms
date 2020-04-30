using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace AlgorithmsWpf
{
    public interface IModuleConnector
    {
        //dynamic getModuleInstance();
        // void InitTab(ComboBox cmb);
        void Connect();
        void InitTab();
    }
}
