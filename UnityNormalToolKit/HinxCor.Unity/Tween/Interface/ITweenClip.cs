using System;
using System.Collections.Generic;


namespace HinxCor.Unity.Animations
{

    /// <summary>
    /// tween clip
    /// </summary>
    public interface ITweenClip
    {
        /// <summary>
        /// duration of animations
        /// </summary>
        float duration { get; set; }
        /// <summary>
        /// call on finished once
        /// </summary>
        Action callBack { get; set; }
    }


    /// <summary>
    /// T TweenClip
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ITweenClip<T> : ITweenClip
    {
        /// <summary>
        /// from
        /// </summary>
        T from { get; set; }
        /// <summary>
        /// to
        /// </summary>
        T to { get; set; }

        /// <summary>
        /// speed curve eqs
        /// </summary>
        Func<float, T> eascingFunction { get; set; }
        /// <summary>
        /// how to animate width t
        /// </summary>
        Action<T> handleT { get; set; }
    }
}