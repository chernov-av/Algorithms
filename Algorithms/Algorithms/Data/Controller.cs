using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Data
{
    class Controller
    {
        
    }

    class CmbItems
    {
        public string Name { get; set; }
        public Action Action { get; set; }

        public Func<double[], Tuple<double[],string>> Func { get; set; }
        public Action<double[]> Check { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
