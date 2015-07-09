using IoCContainer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoCContainer
{
    public class RegisteredObject
    {
        public RegisteredObject(Type from, Type to, LifestyleType lifestyleType)
        {
            TypeToResolve = from;
            TypeTo = to;
            LifestyleType = lifestyleType;
        }

        public Type TypeToResolve { get; private set; }

        public Type TypeTo { get; private set; }

        public object Instance { get; private set; }

        public LifestyleType LifestyleType { get; private set; }

        public void CreateInstance(params object[] args)
        {
            this.Instance = Activator.CreateInstance(this.TypeTo, args);
        }
    }
}
