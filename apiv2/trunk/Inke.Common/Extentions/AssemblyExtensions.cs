using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace System.Reflection
{
    public static class AssemblyExtensions
    {
        public static IEnumerable<Type> GetInterfaces(this Assembly assembly)
        {
            return assembly.GetTypes().Where(t => t.IsInterface);
        }

        public static IList<Type> GetImplsOfInterface(this Assembly assembly, Type interfaceType)
        {
            var impls = new List<Type>();

            var concreteTypes = assembly.GetTypes().Where(
                t => !t.IsInterface && !t.IsAbstract && interfaceType.IsAssignableFrom(t));

            concreteTypes.ToList().ForEach(impls.Add);

            return impls;
        }
    }
}