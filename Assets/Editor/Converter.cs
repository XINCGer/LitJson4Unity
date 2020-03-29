using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using LitJson;
using System.IO;

public class Converter 
{
    private static readonly string JsonPath = "Assets/TrasnferData/TestScriptableObj.json";
    private static readonly string ScriptableObjectPath = "Assets/TestScriptableObj.asset";
    private static readonly string TransScritptableObjectPath = "Assets/TrasnferData/TestScriptableObj.asset";

    [MenuItem("ColaFramework/序列化为Json")]
    public static void Trans2Json()
    {
        var asset = AssetDatabase.LoadAssetAtPath<TestScriptableObj>(ScriptableObjectPath);
        var jsonContent = JsonMapper.ToJson(asset);
        using(var stream = new StreamWriter(JsonPath))
        {
            stream.Write(jsonContent);
        }
        AssetDatabase.Refresh();
    }

    [MenuItem("ColaFramework/反序列化为ScriptableObject")]
    public static void Trans2ScriptableObject()
    {
        if (!File.Exists(JsonPath)) return;
        using(var stream = new StreamReader(JsonPath))
        {
            var jsonStr = stream.ReadToEnd();
            var striptableObj = JsonMapper.ToObject<TestScriptableObj>(jsonStr);
            AssetDatabase.CreateAsset(striptableObj, TransScritptableObjectPath);
            AssetDatabase.Refresh();
        }
    }
}
