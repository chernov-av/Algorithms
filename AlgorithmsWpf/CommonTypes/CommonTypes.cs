using System;

namespace CommonTypes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ExecuteAttribute : Attribute
    {
        public string Name { get; }
        public ExecuteAttribute(string name)
        {
            this.Name = name;
        }
    }

    public class CheckAttribute : Attribute
    {

    }
}
