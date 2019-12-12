using System;

namespace SampleDI.Interface.Simple
{
    /// <summary>
    /// Sets binding to instance.
    /// </summary>
    public interface IBinding
    {
        /// <summary>
        /// Sets binding to non generic type.
        /// </summary>
        /// <param name="tImplementation"></param>
        void To(Type tImplementation);

        /// <summary>
        /// Sets binding to self.
        /// </summary>
        void ToSelf();
    }
}