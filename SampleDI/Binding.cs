using SampleDI.Interface;
using SampleDI.Interface.Simple;
using System;
using System.Collections.Generic;

namespace SampleDI
{
    public class Binding<T> : IBinding<T>
    {
        private readonly Dictionary<Type, Type> _instances;
        private readonly Type _tSource;
        private readonly object _obj = new object();

        public Binding(Dictionary<Type, Type> kernel)
        {
            _instances = kernel;
        }

        public Binding(Dictionary<Type, Type> kernel, Type tSource)
        {
            _instances = kernel;
            _tSource = tSource;
        }

        /// <summary>
        /// Binding to generic type.
        /// </summary>
        /// <typeparam name="TImplementation"></typeparam>
        public void To<TImplementation>() where TImplementation : T
        {
            Add(typeof(T), typeof(TImplementation));
        }

        /// <summary>
        /// Binding to non generic type.
        /// </summary>
        /// <param name="tImplementation"></param>
        public void To(Type tImplementation)
        {
            if (_tSource == null)
            {
                AddIsAssignable(typeof(T), tImplementation);
            }
            else
            {
                AddIsAssignable(_tSource, tImplementation);
            }
        }

        /// <summary>
        /// Adds type to the container.
        /// </summary>
        public void ToSelf()
        {
            if (_tSource == null)
            {
                AddIsAssignable(typeof(T), typeof(T));
            }
            else
            {
                AddIsAssignable(_tSource, _tSource);
            }
        }
        
        /// <summary>
        /// Adds non generic types to the container.
        /// </summary>
        /// <param name="tSource"></param>
        /// <param name="tImplementation"></param>
        private void AddIsAssignable(Type tSource, Type tImplementation)
        {
            if (tSource.IsAssignableFrom(tImplementation) && !tImplementation.IsAbstract && !tImplementation.IsInterface)
            {
                Add(tSource, tImplementation);
            }
            else
            {
                throw new InvalidOperationException(tSource.Name + " not bind to " + tImplementation.Name);
            }
        }

        /// <summary>
        /// Adds types to the container.
        /// </summary>
        /// <param name="tSource"></param>
        /// <param name="tImplementation"></param>
        private void Add(Type tSource, Type tImplementation)
        {
            lock (_obj)
            {
                if (_instances.ContainsKey(tSource))
                {
                    _instances.Remove(tSource);
                }
                _instances.Add(tSource, tImplementation);
            }
        }
    }
}
