using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsWpf
{

    public delegate double[] GetHeap(double[] input);

    public delegate void AddElement(double newElement);
    public delegate double GetElement();
    public delegate double[] GetStruct();

    class Controller
    {
        
    }

    class CmbItems : Controller
    {
        public string Name { get; set; }
        public Action Action { get; set; }

        public Func<double[], Tuple<double[],string>> FuncSort { get; set; }
        public Action<double[], int> CheckSort { get; set; }

        public Func<double[], Tuple<double,string>> FuncSelect { get; set; }

        public Action<int> FuncStruct { get; set; }

        public Action FuncTree { get; set; }


        public override string ToString()
        {
            return Name;
        }
    }

    

}
