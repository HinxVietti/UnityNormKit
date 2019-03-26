using UnityEngine;
using System.Collections;

namespace HinxCor.Unity
{
    /// <summary>
    /// 使用静态方法启动协助程序
    /// </summary>
    public class CoroutineHelper : MonoBehaviour
    {
        /// <summary>
        /// 使用静态方法启动协助程序
        /// </summary>
        /// <param name="corutine"></param>
        public static void StaticStartCoroutine(IEnumerator corutine)
        {
            var go = new GameObject();
            var com = go.AddComponent<CoroutineHelper>();
            com.StartCoroutine(ASyncCorountine(corutine, go));
        }


        static IEnumerator ASyncCorountine(IEnumerator enumerator, GameObject go)
        {
            yield return enumerator;
            yield return null;
            Destroy(go);
        }
    }
}