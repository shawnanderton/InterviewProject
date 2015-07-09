using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IoCContainer.Enums;

namespace IoCContainer
{
    public class Container
    {
        private IList<RegisteredObject> registeredObjects = new List<RegisteredObject>();

        public T Resolve<T>()
        {
            return (T)Resolve(typeof(T));
        }

        private object Resolve(Type typeToResolve)
        {
            var registeredObject =registeredObjects.FirstOrDefault(o => o.TypeToResolve == typeToResolve);
            if (registeredObject == null)
            {
                throw new Exception(string.Format("Could not resolve type {0}", typeToResolve.FullName));
            }
            return GetInstance(registeredObject);
        }
         private object GetInstance(RegisteredObject registeredObject)
        {
            if (registeredObject.Instance == null || 
                registeredObject.LifestyleType == LifestyleType.Transient)
            {
               var parameters = ResolveConstructorParameters(registeredObject);
                registeredObject.CreateInstance(parameters.ToArray());
               
            }
            return registeredObject.Instance;
        }


         private IEnumerable<object> ResolveConstructorParameters(RegisteredObject registeredObject)
        {
            var firstConstructor = registeredObject.TypeTo.GetConstructors().First();
            var constructorParameters = firstConstructor.GetParameters();
          
            foreach (var parameterToResolve in constructorParameters)
            {
                yield return Resolve(parameterToResolve.ParameterType);
            }

         
        }

        public void Register<TFrom, TTo>(LifestyleType lifeStyleType = LifestyleType.Transient)
        {
            registeredObjects.Add(new RegisteredObject(typeof(TFrom), typeof(TTo), lifeStyleType));
        }
    }
}
