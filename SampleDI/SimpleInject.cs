using SampleDI.Interface;
using SampleDI.Interface.Simple;
using System;
using System.Collections.Generic;

namespace SampleDI
{
    public class SimpleInject
    {
        public SimpleInject()
        {
            Instances = new Dictionary<Type, Type>();            
        }

        /// <summary>
        /// Instances container.
        /// </summary>
        public Dictionary<Type, Type> Instances { get; }

        /// <summary>
        /// Binded generic type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IBinding<T> Bind<T>()
        {
            return new Binding<T>(Instances);
        }

        /// <summary>
        /// Binded non generic type.
        /// </summary>
        /// <param name="tSource"></param>
        /// <returns></returns>
        public IBinding Bind(Type tSource)
        {
            return new Binding<object>(Instances, tSource);
        }

        /// <summary>
        /// Unbinded generic type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public void UnBind<T>()
        {
            Instances.Remove(typeof(T));
        }

        /// <summary>
        /// Unbinded non generic type.
        /// </summary>
        /// <param name="type"></param>
        public void UnBind(Type type)
        {
            Instances.Remove(type);
        }

        /// <summary>
        /// Resolving generic type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Resolve<T>()
        {
            var res = Instances.TryGetValue(typeof(T), out Type tImplem);
            if (!res)
            {
                throw new InvalidOperationException("Not resolve " + typeof(T).Name);
            }

            return (T)Activator.CreateInstance(tImplem);
        }
    }
}
