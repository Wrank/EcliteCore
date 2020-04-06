using System;
using System.Collections.Generic;
using System.Linq;

namespace EcliteService
{
    public static class TypeExtension
    {
        public static Type GetImmediateInterface(this Type type)
        {
            var interfaces = type.GetInterfaces();
            var result = new HashSet<Type>(interfaces);
            foreach (Type i in interfaces)
                result.ExceptWith(i.GetInterfaces());

            return result.FirstOrDefault();
        }
    }
}
