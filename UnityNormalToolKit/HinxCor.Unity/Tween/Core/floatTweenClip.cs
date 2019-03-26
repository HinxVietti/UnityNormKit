using System;
using System.Collections.Generic;

namespace HinxCor.Unity.Animations
{

    /// <summary>
    /// tween single value
    /// </summary>
    public class floatTweenClip : ITweenClip<float>
    {
        /// <summary>
        /// from
        /// </summary>
        public float from { get; set; }
        /// <summary>
        /// to
        /// </summary>
        public float to { get; set; }
        /// <summary>
        /// speed curve
        /// </summary>
        public Func<float, float> eascingFunction { get; set; }
        /// <summary>
        /// how to handle with current float value
        /// </summary>
        public Action<float> handleT { get; set; }
        /// <summary>
        /// dutween value
        /// </summary>
        public float duration { get; set; }
        /// <summary>
        /// on finished callback
        /// </summary>
        public Action callBack { get; set; }

        /// <summary>
        /// construct
        /// </summary>
        public floatTweenClip(float from, float to, float duration,
            Func<float, float> easingFun, Action<float> handleT, Action callBack = null)
        {
            this.from = from;
            this.to = to;
            this.duration = duration;
            this.eascingFunction = easingFun;
            this.handleT = handleT;
            this.callBack = callBack;
        }
    }
}

