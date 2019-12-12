using SampleDI.Interface.Simple;
using System;

namespace SampleDI.Interface
{
    /// <summary>
    /// Sets binding to instance.
    /// </summary>
    public interface IBinding<T>: IBinding
    {
        /// <summary>
        /// Sets binding to generic type.
        /// </summary>
        /// <typeparam name="TImplementation"></typeparam>
        void To<TImplementation>() where TImplementation: T;
    }
}
