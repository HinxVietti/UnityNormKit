using System;
using System.Collections.Generic;
using UnityEngine;

namespace HinxCor.Unity
{
    /// <summary>
    /// 恩格尔曲线
    /// <para>[0,1]区间积分变量为1的曲线 </para>
    /// </summary>
    public class EaseCurve
    {
        /// <summary>
        /// 线性
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static float EaseLinear(float t) { return t; }
        /// <summary>
        /// IQ
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static float EaseInQuad(float t) { return t * t; }
        /// <summary>
        /// OQ
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static float EaseOutQuad(float t) { return t * (2 - t); }
        /// <summary>
        /// IOQ
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static float EaseInOutQuad(float t) { return t < .5 ? 2 * t * t : -1 + (4 - 2 * t) * t; }
        /// <summary>
        /// IC
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static float EaseInCubic(float t) { return t * t * t; }
        /// <summary>
        /// OC
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static float EaseOutCubic(float t) { return (--t) * t * t + 1; }
        /// <summary>
        /// IOC
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static float EaseInOutCubic(float t) { return t < .5 ? 4 * t * t * t : (t - 1) * (2 * t - 2) * (2 * t - 2) + 1; }
        /// <summary>
        /// IQ
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static float EaseInQuart(float t) { return t * t * t * t; }
        /// <summary>
        /// OQ
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static float EaseOutQuart(float t) { return 1 - (--t) * t * t * t; }
        /// <summary>
        /// IOQ
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static float EaseInOutQuart(float t) { return t < .5 ? 8 * t * t * t * t : 1 - 8 * (--t) * t * t * t; }
        /// <summary>
        /// EEI
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static float ElasticEaseIn(float t)
        {
            return Mathf.Sin(13 * Mathf.PI * 2 * t) * Mathf.Pow(2, 10 * (t - 1));
        }
        /// <summary>
        /// EEO
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static float ElasticEaseOut(float t)
        {
            return Mathf.Sin(-13 * Mathf.PI * 2 * (t + 1)) * Mathf.Pow(2, -10 * t) + 1;
        }
        /// <summary>
        /// EEIO
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static float ElasticEaseInOut(float t)
        {
            if (t < 0.5)
            {
                return 0.5f * Mathf.Sin(13 * Mathf.PI * 2 * (2 * t)) * Mathf.Pow(2, 10 * ((2 * t) - 1));
            }
            else
            {
                return 0.5f * (Mathf.Sin(-13 * Mathf.PI * 2 * ((2 * t - 1) + 1)) * Mathf.Pow(2, -10 * (2 * t - 1)) + 2);
            }
        }

    }
}

