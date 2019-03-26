using System;
using System.Collections.Generic;
using LitJson;
using UnityEngine;

/// <summary>
/// 注意,部分功能需要其他类库支持,例如LitJson.DLL;\n 
/// 相信请参照方法
/// </summary>
public class SerializeHelper
{

    /// <summary>
    /// serialize object to json
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public string ToJson(object obj)
    {

        if (obj is Component)
        {
            
        }

        return string.Empty;
    }

}

