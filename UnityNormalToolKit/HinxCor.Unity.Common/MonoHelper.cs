using System;
using System.Text;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace HinxCor.Unity.Common
{
    /// <summary>
    /// 帮助类
    /// </summary>
    public static class MonoHelper
    {
        private static Camera _maincam;
        /// <summary>
        /// 查找标签为MainCamera的Camera,若当前场景不切换,则不需要每次都找一下
        /// </summary>
        public static Camera MainCamera { get { if (_maincam == null || _maincam.gameObject) _maincam = Camera.main; return _maincam; } }

        private static Transform _root;
        /// <summary>
        /// 查找并且返回第一个tag为root的对象的变换组建
        /// </summary>
        public static Transform root { get { if (_root == null) _root = GameObject.FindGameObjectWithTag("root").transform; return _root; } }

        /// <summary>
        /// 是否在范文之内（球形）
        /// </summary>
        /// <param name="ori"></param>
        /// <param name="position"></param>
        /// <param name="distance"></param>
        /// <returns></returns>
        public static bool IsClose(this Transform ori, Vector3 position, float distance)
        {
            var disaqr = ori.position - position;
            return disaqr.sqrMagnitude < distance * distance;
        }

        /// <summary>
        /// 是否在范文之内（球形）,单位 米
        /// </summary>
        /// <param name="ori"></param>
        /// <param name="position"></param>
        /// <param name="distance"></param>
        /// <returns></returns>
        public static bool IsClose(this Transform ori, Transform position, float distance)
        {
            var disaqr = ori.position - position.position;
            return disaqr.sqrMagnitude < distance * distance;
        }
        /// <summary>
        /// 是否在范文之内（球形）,单位 米
        /// </summary>
        /// <param name="ori"></param>
        /// <param name="position"></param>
        /// <param name="distance"></param>
        /// <returns></returns>
        public static bool IsClose(this Vector3 ori, Transform position, float distance)
        {
            var disaqr = ori - position.position;
            return disaqr.sqrMagnitude < distance * distance;
        }

        /// <summary>
        /// 按照步长匀速向目标移动
        /// </summary>
        /// <param name="ori"></param>
        /// <param name="end"></param>
        /// <param name="step"></param>
        public static void LerpMiter(this Transform ori, Vector3 end, float step)
        {
            ori.position = (end - ori.position).normalized * step + ori.transform.position;
        }

        /// <summary>
        /// 按照百分比形式缩进位置
        /// </summary>
        /// <param name="ori"></param>
        /// <param name="position"></param>
        /// <param name="tp"></param>
        public static void Lerp(this Transform ori, Vector3 position, float tp)
        {
            //ori.position = (position - ori.position) * tp + ori.position;
            ori.position = position * tp + (1 - tp) * ori.position;
        }
        /// <summary>
        /// 按照百分比形式缩进位置
        /// </summary>
        /// <param name="ori"></param>
        /// <param name="position"></param>
        /// <param name="tp"></param>
        public static void LerpLocal(this Transform ori, Vector3 position, float tp)
        {
            //ori.position = (position - ori.position) * tp + ori.position;
            ori.localPosition = position * tp + (1 - tp) * ori.localPosition;
        }

        /// <summary>
        /// 按照tp将transform的欧拉角旋转至 rulerangle
        /// </summary>
        /// <param name="ori"></param>
        /// <param name="euangles"></param>
        /// <param name="tp"></param>
        public static void LerpAngles(this Transform ori, Vector3 euangles, float tp)
        {
            ori.eulerAngles = Vector3.Lerp(ori.eulerAngles, euangles, tp);
            //ori.eulerAngles = euangles * tp + (1 - tp) * ori.eulerAngles;
        }

        /// <summary>
        /// 按照tp(百分比差值)
        /// </summary>
        /// <param name="ori"></param>
        /// <param name="destinate"></param>
        /// <param name="tp"></param>
        /// <returns></returns>
        public static Vector3 Lerp(this Vector3 ori, Vector3 destinate, float tp)
        {
            var d_v3 = destinate - ori;
            return ori + d_v3 * tp;
        }

        /// <summary>
        /// 百分比形式缩进旋转角度
        /// </summary>
        /// <param name="ori"></param>
        /// <param name="rotation"></param>
        /// <param name="tp"></param>
        public static void Lerp(this Transform ori, Quaternion rotation, float tp)
        {
            //ori.rotation = Quaternion.Lerp(ori.rotation, rotation, tp);
            ori.rotation = new Quaternion(
            (rotation.x - ori.rotation.x) * tp + ori.rotation.x,
            (rotation.y - ori.rotation.y) * tp + ori.rotation.y,
            (rotation.z - ori.rotation.z) * tp + ori.rotation.z,
            (rotation.w - ori.rotation.w) * tp + ori.rotation.w
            );
        }

        /// <summary>
        /// 若旧版Unity中vector2没有* 符号,定义Multiple方法
        /// </summary>
        /// <param name="ori"></param>
        /// <param name="operate"></param>
        /// <returns></returns>
        public static Vector2 Multiple(this Vector2 ori, Vector2 operate)
        {
            ori.x *= operate.x;
            ori.y *= operate.y;
            return ori;
        }
        /// <summary>
        /// 若旧版Unity中vector3没有/ 符号,定义Devide方法
        /// </summary>
        /// <param name="ori"></param>
        /// <param name="operate"></param>
        /// <returns></returns>
        public static Vector3 Devide(this Vector3 ori, Vector3 operate)
        {
            ori.x /= Mathf.Abs(operate.x);
            ori.y /= Mathf.Abs(operate.y);
            ori.z /= Mathf.Abs(operate.z);
            return ori;
        }

        /// <summary>
        /// 若旧版Unity中vector3没有* 符号,定义Multiple方法
        /// </summary>
        /// <param name="ori"></param>
        /// <param name="operate"></param>
        /// <returns></returns>
        public static Vector3 Multiple(this Vector3 ori, Vector3 operate)
        {
            ori.x = ori.x * Mathf.Abs(operate.x);
            ori.y = ori.y * Mathf.Abs(operate.y);
            ori.z = ori.z * Mathf.Abs(operate.z);
            return ori;
        }

        /// <summary>
        /// 查找子类中第一个符合条件的组件
        /// </summary>
        /// <typeparam name="T">组件类型</typeparam>
        /// <param name="mice">物体本身</param>
        /// <param name="name">子组件名称</param>
        /// <returns></returns>
        public static T GetChild<T>(this Transform mice, string name) where T : UnityEngine.Component
        {
            T result = null;
            var res = mice.GetComponentsInChildren<T>();
            foreach (var item in res)
            {
                if (item.name == name)
                {
                    result = item;
                }
            }
            return result;
        }

        /// <summary>
        /// 检测此对象是否挂载了该脚本，若无则添加并返回，若有则获取返回
        /// </summary>
        /// <typeparam name="T">对象组件</typeparam>
        /// <param name="gameobj">游戏物体自身</param>
        /// <returns></returns>
        public static T RawComponent<T>(this GameObject gameobj) where T : UnityEngine.Component
        {
            var result = gameobj.GetComponent<T>();
            if (!result) result = gameobj.AddComponent<T>();
            return result;
        }

        /// <summary>
        /// 转换为sprite
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static Sprite ToSprite(this Texture2D t)
        {
            return Sprite.Create(t, new Rect(Vector2.zero, new Vector2(t.width, t.height)), Vector2.one * 0.5f);
        }
        /// <summary>
        /// 贴图创建Sprite
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static Sprite ToSprite(this Texture t)
        {
            return Sprite.Create(t as Texture2D, new Rect(Vector2.zero, new Vector2(t.width, t.height)), Vector2.one * 0.5f);
        }
        /// <summary>
        /// 颜色方向
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static Color ToRevColor(this Color color)
        {
            color.r = 1 - color.r;
            color.g = 1 - color.g;
            color.b = 1 - color.b;
            return color;
        }

        /// <summary>
        /// HSV中H ToColor
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Color ToColor(this float p)
        {
            p = p % 1;
            Color c = Color.white;
            c.r = p > 0.5f ? p2Color(1 - p) : p2Color(p);
            c.g = p2Color(p - 1 / 3f);
            c.b = p2Color(p - 2 / 3f);
            c.Clamp();
            if (c.r == c.g && c.r == c.b) return Color.red;
            return c;
        }

        /// <summary>
        /// ab by ToColor
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private static float p2Color(float p)
        {
            p = Mathf.Abs(p);
            return p > 1 / 6 ? Mathf.Clamp01(2 - 6 * p) : 1;
        }

        /// <summary>
        /// 获取并且返回第一个打钩的Toggle,否则返回Null
        /// </summary>
        /// <param name="group"></param>
        /// <returns>否则返回Null,有则返回Toggle</returns>
        public static Toggle GetSetOnToggle(this ToggleGroup group)
        {
            foreach (var toggle in group.ActiveToggles())
            {
                if (toggle.isOn) return toggle;
            }
            return null;
        }

        /// <summary>
        /// Warm: input string must be an full path.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string ToUrl(this string path)
        {
            return "file://" + path.Trim(':').Replace('\\', '/');
        }

        /// <summary>
        /// Unity控制台输出
        /// </summary>
        /// <param name="ori"></param>
        public static void print(this string ori)
        {
            Debug.Log(ori);
        }
        /// <summary>
        /// Unity控制台输出
        /// </summary>
        /// <param name="ori"></param>
        public static void print(this object ori)
        {
            Debug.Log(ori);
        }


        /// <summary>
        /// return rectTransform of transform if transform is rectTransform
        /// </summary>
        /// <param name="ori"></param>
        /// <returns></returns>
        public static RectTransform GetRect(this Transform ori)
        {
            return ori as RectTransform;
        }

        /// <summary>
        /// UGUI 屏幕坐标到画布坐标，- 1/2 分辨率
        /// </summary>
        /// <param name="ori"></param>
        /// <returns></returns>
        public static Vector3 ScreenSpaceToCanvasSpace(this Vector3 ori)
        {
            return ori - new Vector3(Screen.width / 2, Screen.height / 2);
        }

        /// <summary>
        /// UGUI 画布坐标到 屏幕坐标，+ 1/2 sc
        /// </summary>
        /// <param name="ori"></param>
        /// <returns></returns>
        public static Vector3 CanvasSpaceToScreenSpace(this Vector3 ori)
        {
            return ori + new Vector3(Screen.width / 2, Screen.height / 2);
        }

        /// <summary>
        /// ToVe2
        /// </summary>
        /// <param name="ori"></param>
        /// <returns></returns>
        public static Vector2 ToVector2(this Vector3 ori)
        {
            return ori;
        }

        /// <summary>
        /// 颜色规范到0-1区间
        /// </summary>
        /// <param name="ori"></param>
        /// <returns></returns>
        public static Color Clamp(this Color ori)
        {
            ori.a = Mathf.Clamp01(ori.a);
            //ori.g = Mathf.Clamp01(ori.g);
            //ori.b = Mathf.Clamp01(ori.b);
            //ori.r = Mathf.Clamp01(ori.r);
            //ori.a = ori.a == float.NaN ? 0 : Mathf.Clamp01(ori.a);
            ori.r = ori.r == float.NaN ? 0 : Mathf.Clamp01(ori.r);
            ori.g = ori.g == float.NaN ? 0 : Mathf.Clamp01(ori.g);
            ori.b = ori.b == float.NaN ? 0 : Mathf.Clamp01(ori.b);
            return ori;
        }

        /// <summary>
        /// 颜色取补
        /// </summary>
        /// <param name="ori"></param>
        /// <returns></returns>
        public static Color D_COLOR(this Color ori)
        {
            return new Color(1 - ori.r, 1 - ori.g, 1 - ori.b, 1 - ori.a);
        }


        /// <summary>
        /// RGBA颜色转为16进制显示
        /// </summary>
        /// <param name="ori"></param>
        /// <returns></returns>
        public static string ToHexString(this Color ori)
        {
            return string.Format("#{0}{1}{2}{3}", to0xFFfx(ori.r), to0xFFfx(ori.g), to0xFFfx(ori.b), to0xFFfx(ori.a));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static Color HexStringToColor(string str)
        {
            StringBuilder sb = new StringBuilder(2);
            sb.Append(new[] { str[0], str[1] });
            int r = Convert.ToInt32(sb.ToString(), 16);
            sb[0] = str[0 + 2];
            sb[1] = str[1 + 2];
            int g = Convert.ToInt32(sb.ToString(), 16);
            sb[0] = str[0 + 4];
            sb[1] = str[1 + 4];
            int b = Convert.ToInt32(sb.ToString(), 16);
            sb[0] = str[0 + 6];
            sb[1] = str[1 + 6];
            int a = Convert.ToInt32(sb.ToString(), 16);
            var c = new Color(r / 255f, g / 255f, b / 255f, a / 255f);
            return c;
        }

        /// <summary>
        /// rgba 转 #FFFFFFFF显示帮助方法
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static string to0xFFfx(float value)
        {
            string str = Convert.ToString((int)(value * 255), 16);
            if (str.Length == 1) str = "0" + str;
            return str.ToUpper();
        }


        /// <summary>
        /// 压缩x，z平面到x轴，生成新的2维向量
        /// </summary>
        /// <param name="ori"></param>
        /// <returns></returns>
        public static Vector2 MaptoVe2(this Vector3 ori)
        {
            return new Vector2((Mathf.Sqrt(ori.x * ori.x + ori.z * ori.z)), ori.y);
        }

        /// <summary>
        /// 移除目标组建
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ori"></param>
        /// <returns></returns>
        public static bool RemoveComponent<T>(this GameObject ori) where T : Component
        {
            var com = ori.GetComponent<T>();
            if (com == null) return false;
            UnityEngine.Object.Destroy(com);
            return true;
        }
        /// <summary>
        /// 移除目标组建
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ori"></param>
        /// <returns></returns>
        public static bool RemoveComponent<T>(this Component ori) where T : Component
        {
            return ori.gameObject.RemoveComponent<T>();
        }


        /// <summary>
        /// ve4 to color
        /// </summary>
        /// <param name="ori"></param>
        /// <returns></returns>
        public static Color ToColor(this Vector4 ori)
        {
            return new Color(ori.x, ori.y, ori.z, ori.w);
        }
        /// <summary>
        /// color to ve4
        /// </summary>
        /// <param name="ori"></param>
        /// <returns></returns>
        public static Vector4 colorToVector4(this Color ori)
        {
            return new Vector4(ori.r, ori.g, ori.b, ori.a);
        }

        /// <summary>
        /// remove this component
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ori"></param>
        public static void Remove<T>(this T ori) where T : Component
        {
            UnityEngine.Object.Destroy(ori);
        }

        /// <summary>
        /// 屏幕坐标中的一点是否在改图形上
        /// </summary>
        /// <param name="ori"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        public static bool IsPositionOn(this MaskableGraphic ori, Vector3 position)
        {
            //相对于画布的位置；
            var d_position = ori.rectTransform.position - ori.canvas.transform.position;
            if (position.x < d_position.x - ori.rectTransform.sizeDelta.x / 2) return false;
            if (position.x > d_position.x + ori.rectTransform.sizeDelta.x / 2) return false;
            if (position.y < d_position.y - ori.rectTransform.sizeDelta.y / 2) return false;
            if (position.y > d_position.y + ori.rectTransform.sizeDelta.y / 2) return false;
            return true;
        }

        /// <summary>
        /// 从目标组件，复制到当前组件；
        /// 世界坐标
        /// </summary>
        /// <param name="ori"></param>
        /// <param name="target"></param>
        public static void CopyFrom(this Transform ori, Transform target)
        {
            ori.transform.position = target.transform.position;
            ori.transform.rotation = target.transform.rotation;
            ori.transform.localScale = target.transform.localScale;
        }

        /// <summary>
        /// to ve3
        /// </summary>
        /// <param name="ori"></param>
        /// <returns></returns>
        public static Vector3 toVector3(this Vector2 ori)
        {
            return ori;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ori"></param>
        /// <param name="targetCanvas"></param>
        /// <returns></returns>
        public static Vector3 mapToCanvas(this Vector3 ori, Canvas targetCanvas)
        {
            var ratiox = targetCanvas.pixelRect.width / Screen.width;
            var ratioy = targetCanvas.pixelRect.height / Screen.height;
            ori.x *= ratiox;
            ori.y *= ratioy;
            return ori;
        }

        /// <summary>
        /// 把一个屏幕的坐标映射到林外一个屏幕对应的屏幕位置~。
        /// </summary>
        /// <param name="canvas"></param>
        /// <returns></returns>
        public static Vector3 mapToCanvas(this Vector3 ori, Canvas canvas, Canvas tcanvas)
        {
            var recta = canvas.pixelRect;
            var rectb = tcanvas.pixelRect;

            var ratiox = rectb.width / recta.width;
            var ratioy = rectb.height / recta.height;

            ori.x = ori.x * ratiox;
            ori.y = ori.y * ratioy;

            return ori;
        }


        /// <summary>
        /// 在子集中查找名为name的T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ori"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static T Get<T>(this Component ori, string name) where T : Component
        {
            return ori.transform.Find(name).GetComponent<T>();
        }

        /// <summary>
        /// 查找类型为T，名字为name 的Unity对象，如果有多个，返回第一个符合条件的结果，否则返回null
        /// </summary>
        /// <typeparam name="T">组件类型</typeparam>
        /// <param name="ori"></param>
        /// <param name="name">组件名称</param>
        /// <returns></returns>
        public static T GetInScene<T>(this Component ori, string name) where T : Component
        {
            var tCollect = UnityEngine.Object.FindObjectsOfType<T>();
            foreach (var item in tCollect)
            {
                if (item.name == name) return item;
            }
            return null;
        }

        /// <summary>
        /// 向量分解，满足 ori = ref.x * nor1 + ref.y * nor2;
        /// </summary>
        /// <param name="ori">需要分解的向量</param>
        /// <param name="nor1">组成A</param>
        /// <param name="nor2">组成B</param>
        /// <returns></returns>
        public static Vector2 VectorResolved(this Vector2 ori, Vector2 nor1, Vector2 nor2)
        {
            float k1, k2, nor;
            nor = nor2.y == 0 ? 99999999 : nor2.x / nor2.y;
            k1 = (ori.y * nor - ori.x) / (nor1.y * nor - nor1.x);
            nor = nor1.y == 0 ? 99999999 : nor1.x / nor1.y;
            k2 = (ori.y * nor - ori.x) / (nor2.y * nor - nor2.x);
            return new Vector2(k1, k2);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ori"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector2 Devide(this Vector2 ori, Vector2 b)
        {
            ori.x /= b.x;
            ori.y /= b.y;
            return ori;
        }
        /// <summary>
        /// magnitude devide
        /// </summary>
        /// <param name="ori"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static float Devide_Float(this Vector2 ori, Vector2 b)
        {
            return ori.magnitude / b.magnitude;
        }

        /// <summary>
        /// 若事件不为空，则触发
        /// </summary>
        /// <param name="action"></param>
        public static void TryInvoke(this UnityAction action)
        {
            if (action != null) action.Invoke();
        }
        /// <summary>
        ///  若事件不为空，则触发
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="action"></param>
        /// <param name="obj"></param>
        public static void TryInvoke<T>(this UnityAction<T> action, T obj)
        {
            if (action != null) action.Invoke(obj);
        }
        /// <summary>
        /// 安全触发，如果报空则不执行
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="uevent"></param>
        /// <param name="objs"></param>
        public static bool TryInvoke<T>(this UnityEvent<T> uevent, T objs)
        {
            if (uevent != null)
            {
                uevent.Invoke(objs);
                return true;
            }
            return false;
        }

        /// <summary>
        /// abs to ve2
        /// </summary>
        /// <param name="ori"></param>
        public static void Abs(this Vector2 ori)
        {
            ori.x = Mathf.Abs(ori.x);
            ori.y = Mathf.Abs(ori.y);
        }
        /// <summary>
        /// abs
        /// </summary>
        /// <param name="ori"></param>
        /// <returns></returns>
        public static Vector2 abs(this Vector2 ori)
        {
            var x = Mathf.Abs(ori.x);
            var y = Mathf.Abs(ori.y);
            return new Vector2(x, y);
        }
        /// <summary>
        /// abs
        /// </summary>
        /// <param name="ori"></param>
        public static void Abs(this Vector3 ori)
        {
            ori.x = Mathf.Abs(ori.x);
            ori.y = Mathf.Abs(ori.y);
            ori.z = Mathf.Abs(ori.z);
        }
        /// <summary>
        /// abs
        /// </summary>
        /// <param name="ori"></param>
        /// <returns></returns>
        public static Vector3 abs(this Vector3 ori)
        {
            var x = Mathf.Abs(ori.x);
            var y = Mathf.Abs(ori.y);
            var z = Mathf.Abs(ori.z);
            return new Vector3(x, y, z);
        }

        /// <summary>
        /// UnityEngine.Color to System.Drawing.Color
        /// </summary>
        /// <param name="ori"></param>
        /// <returns></returns>
        public static System.Drawing.Color ToColor(this Color ori)
        {
            ori = ori.Clamp();

            try
            {
                return System.Drawing.Color.FromArgb((int)(ori.a * 255), (int)(ori.r * 255), (int)(ori.g * 255), (int)(ori.b * 255));
            }
            catch (Exception e)
            {
                Debug.LogWarning(ori + "#" + e.ToString());
                return System.Drawing.Color.Black;
            }
        }

        /// <summary>
        /// 将桌面平台的颜色转换为Unity的颜色
        /// </summary>
        /// <param name="ori"></param>
        /// <returns></returns>
        public static Color ToColor(this System.Drawing.Color ori)
        {
            float a = 1;
            try
            {
                a = ori.A / 255f;
            }
            catch (Exception e)
            {
                Debug.LogWarning(e);
            }
            return new Color(ori.R / 255f, ori.G / 255f, ori.B / 255f, a);
        }

        /// <summary>
        /// the split vector of orgin to direction
        /// </summary>
        /// <param name="ori"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        public static Vector2 ShadowTo(this Vector3 ori, Vector2 direction)
        {
            direction.Normalize();
            return Vector3.Dot(ori, direction) * direction;
        }
        /// <summary>
        /// 原向量所在二维平面的投影
        /// </summary>
        /// <param name="ori">空间向量</param>
        /// <param name="x">平面X正方向</param>
        /// <param name="y">平面Y正方向</param>
        /// <returns></returns>
        public static Vector2 ShadowTo(this Vector3 ori, Vector3 x, Vector3 y)
        {
            return new Vector2(ori.GetLength(x), ori.GetLength(y));
        }

        /// <summary>
        /// ori's length in dir (direction)
        /// </summary>
        /// <param name="ori"></param>
        /// <param name="dir"></param>
        /// <returns></returns>
        public static float GetLength(this Vector3 ori, Vector3 dir)
        {
            return Vector3.Dot(ori, dir.normalized);
        }

        /// <summary>
        /// screen size
        /// </summary>
        public static Vector2 ScreenSize
        {
            get
            {
                return new Vector2(Screen.width, Screen.height);
            }
        }

        /// <summary>
        /// 获取当前相机到鼠标位置的射线
        /// </summary>
        /// <param name="camera"></param>
        /// <returns></returns>
        public static Ray GetMousePointRay(this Camera camera)
        {
            return camera.ScreenPointToRay(Input.mousePosition);
        }

        /// <summary>
        /// string to ve3
        /// </summary>
        /// <param name="sVector"></param>
        /// <returns></returns>

        public static Vector3 ParseToVector3(string sVector)
        {

            // Remove the parentheses
            if (sVector.StartsWith("(") && sVector.EndsWith(")"))
            {
                sVector = sVector.Substring(1, sVector.Length - 2);
            }

            // split the items
            string[] sArray = sVector.Split(',');

            // store as a Vector3
            Vector3 result = new Vector3(
                float.Parse(sArray[0]),
                float.Parse(sArray[1]),
                float.Parse(sArray[2]));

            return result;
        }

        /// <summary>
        /// Unity打印数据到控制台，并且退出测试
        /// </summary>
        /// <param name="massage">打印的数据</param>
        /// <param name="logType">报告信息类型</param>
        /// <param name="exitOnFinished">是否结束模拟器（仅仅再编辑器模式下运行）</param>
        public static void LogRExit(object massage, /*[DefaultValue(LogType.Log)]*/UnityEngine.LogType logType = LogType.Log, bool exitOnFinished = true)
        {
            switch (logType)
            {
                case LogType.Error:
                    Debug.LogError(massage);
                    break;
                case LogType.Assert:
                    Debug.LogAssertion(massage);
                    break;
                case LogType.Warning:
                    Debug.LogWarning(massage);
                    break;
                case LogType.Log:
                    Debug.Log(massage);
                    break;
                case LogType.Exception:
                    Debug.LogException(massage as Exception);
                    break;
                default:
                    break;
            }
#if UNITY_EDITOR
        if (exitOnFinished)
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }

        /// <summary>
        /// string to ve2
        /// </summary>
        /// <param name="sVector"></param>
        /// <returns></returns>
        public static Vector2 ParseToVector2(string sVector)
        {

            // Remove the parentheses
            if (sVector.StartsWith("(") && sVector.EndsWith(")"))
            {
                sVector = sVector.Substring(1, sVector.Length - 2);
            }

            // split the items
            string[] sArray = sVector.Split(',');

            // store as a Vector3
            Vector2 result = new Vector2(
                float.Parse(sArray[0]),
                float.Parse(sArray[1]));

            return result;
        }


        /// <summary>
        /// 判断向量A是否在向量B左边
        /// </summary>
        /// <param name="vectora"></param>
        /// <param name="vectorb"></param>
        /// <returns></returns>
        public static bool isLeftBy(this Vector2 vectora, Vector2 vectorb)
        {
            return Vector3.Cross(vectorb, vectora).normalized.Equals(Vector3.forward);
        }
    }
}