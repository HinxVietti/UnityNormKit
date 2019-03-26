using System;
using System.Collections.Generic;

namespace HinxCor.Unity.Animations
{
    /// <summary>
    /// sum able
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ISumable<T>
    {
        /// <summary>
        /// reduce
        /// </summary>
        /// <param name="ori"></param>
        /// <param name="eas"></param>
        /// <returns></returns>
        T Reduce(T ori, T eas);
    }
}

