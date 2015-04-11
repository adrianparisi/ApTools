using System;
using System.Reflection;

namespace SomeTools.Reflection
{
    public class ReflectionHelper
    {
        /// <summary>Runs the constructor.</summary>
        /// <param name="type">The class type.</param>
        /// <param name="parameters">The constructor parameters.</param>
        /// <returns>An object instance.</returns>
        public static object RunConstructor(Type type, params object[] parameters)
        {
            BindingFlags flags = BindingFlags.CreateInstance | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;


            ConstructorInfo constructor = type.GetConstructor(flags, null, ReflectionHelper.GetTypes(parameters), null);

            if (constructor == null)
                throw new ArgumentException("There is no constructor for those arguments types");
            
            return constructor.Invoke(parameters);
        }


        /// <summary>Runs the static method.</summary>
        /// <param name="name">The method name.</param>
        /// <param name="type">The class type.</param>
        /// <param name="parameters">The method parameters.</param>
        public static object RunMethod(string name, Type type, params object[] parameters)
        {
            return ReflectionHelper.RunMethod(name, BindingFlags.Static, type, null, parameters);
        }


        /// <summary>Runs the instance method.</summary>
        /// <param name="name">The method name.</param>
        /// <param name="instance">The object instance.</param>
        /// <param name="parameters">The method parameters.</param>
        public static object RunMethod(string name, object instance, params object[] parameters)
        {
            return ReflectionHelper.RunMethod(name, BindingFlags.Instance, instance.GetType(), instance, parameters);
        }


        private static object RunMethod(string name, BindingFlags flags, Type type, object instance, object[] parameters)
        {
            flags = flags | BindingFlags.Public | BindingFlags.NonPublic;
            
            
            MethodInfo method = type.GetMethod(name, flags, null, ReflectionHelper.GetTypes(parameters), null);
                        
            if (method == null)
                throw new ArgumentException("There is no method " + name + " for type " + type.ToString() + ".");

            return method.Invoke(instance, parameters);
        }

        
        private static Type[] GetTypes(object[] parameters)
        {
            Type[] types = new Type[parameters.Length];

            for (int i = 0; i < parameters.Length; i++)
                types[i] = parameters[i].GetType();

            return types;
        }
    }
}
