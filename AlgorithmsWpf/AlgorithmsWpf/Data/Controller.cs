using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsWpf
{
    class Controller
    {
        
    }

    class CmbItems
    {
        public string Name { get; set; }
        public Action Action { get; set; }

        public Func<double[], Tuple<double[],string>> FuncSort { get; set; }
        public Action<double[]> CheckSort { get; set; }

        public Func<double[], Tuple<double,string>> FuncSelect { get; set; }


        public override string ToString()
        {
            return Name;
        }
    }
}
