using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace AlgorithmsWpf
{
    public interface IModuleConnector
    { 
        void Connect();
        void InitTab();
    }

    public interface IHeap
    {
        double[] SortMaxFunc(double[] input);
        double[] SortMinFunc(double[] input);
    }   
    
}
