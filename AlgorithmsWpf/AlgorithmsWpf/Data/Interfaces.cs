using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Data
{
    interface IStructures
    {
        int GetSize { get; }

        double[] GetStruct { get; }
        
    }

    interface ITrees<T>
    {
        int GetSize { get; }

        T[] GetTree { get; }
    }
}
