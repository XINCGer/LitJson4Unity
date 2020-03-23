using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using LitJson;
using System.IO;

public class Converter 
{
    [MenuItem("ColaFramework/序列化为Json")]
    public static void Trans2Json()
    {
        var asset = AssetDatabase.LoadAssetAtPath<TestScriptableObj>("Assets/TestScriptableObj.asset");
        var jsonContent = JsonMapper.ToJson(asset);
        using(var stream = new StreamWriter("Assets/TestScriptableObj.json"))
        {
            stream.Write(jsonContent);
        }
        AssetDatabase.Refresh();
    }
}
