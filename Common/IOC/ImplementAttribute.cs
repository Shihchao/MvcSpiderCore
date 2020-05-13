using System;

namespace Common.IOC
{
    [AttributeUsage(AttributeTargets.Interface)]
    public class ImplementAttribute : Attribute
    {
        public ImplementAttribute(Type implementClass)
        {
            this.ImplementClass = implementClass;
        }

        public Type ImplementClass { get; }
    }
}
