using System;
using System.Collections;
using UnityEngine;

namespace HinxCor.Unity.Animations
{
    /// <summary>
    /// tween animations
    /// <para> Condition </para>
    /// <para> 1. EasingFunction需要满足积分量为1 </para>
    /// </summary>
    public class Tweener
    {
        private void test()
        {

            //DoTween(5, 15, 1, Linner, handleValue, callback);

        }

        /// <summary>
        /// 按照float进行Tween动画
        /// </summary>
        /// <param name="tweenClip"></param>
        public static void DoTween(floatTweenClip tweenClip) => DoTweenFloat(tweenClip);
        /// <summary>
        /// 按照float进行Tween动画
        /// </summary>
        /// <param name="tweenClip"></param>
        public static void DoTweenFloat(floatTweenClip tweenClip)
        {
            CoroutineHelper.StaticStartCoroutine(DoClip(tweenClip));
        }

        private static IEnumerator DoClip(floatTweenClip tweenClip)
        {
            float timer = 0;
            float leve = tweenClip.to - tweenClip.from;
            while (timer < tweenClip.duration)
            {
                timer += Time.deltaTime;
                //这样是先行变化,关键在于速度为1,而且eas模型
                var p = (timer / tweenClip.duration);
                tweenClip.handleT(tweenClip.from + leve * tweenClip.eascingFunction(p));
                yield return new WaitForEndOfFrame();
            }
            tweenClip.handleT(tweenClip.to);
            tweenClip.callBack?.Invoke();
        }

        /// <summary>
        /// Not implemt
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tweenClip"></param>
        /// <param name="curr"></param>
        public static void DoTween<T>(ITweenClip<T> tweenClip, Func<float, T> curr)
        {

        }

        /// <summary>
        /// Not implemt
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tweenClip"></param>
        /// <param name="sumable"></param>
        public static void DoTween<T>(ITweenClip<T> tweenClip, ISumable<T> sumable)
        {
            CoroutineHelper.StaticStartCoroutine(DoClip(tweenClip, sumable));
        }

        private static IEnumerator DoClip<T>(ITweenClip<T> tweenClip, ISumable<T> sumable)
        {
            float timer = 0;
            var res = sumable.Reduce(tweenClip.to, tweenClip.from);
            while (timer < tweenClip.duration)
            {
                var progress = timer / tweenClip.duration;



            }


            yield return null;
        }

        /// <summary>
        /// Not implemt
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="direction"></param>
        /// <param name="easingFunc"></param>
        /// <param name="handleT"></param>
        /// <param name="callBack"></param>
        public static void DoTween<T>(T from, T to, float direction, Func<T, T> easingFunc, Action<T> handleT, Action callBack)
        {

        }

        /// <summary>
        /// testing func animate nothing
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="easingFunc"></param>
        /// <param name="callback"></param>
        public static void DoTween(object from, object to, object easingFunc, object callback)
        {


        }
    }

}
