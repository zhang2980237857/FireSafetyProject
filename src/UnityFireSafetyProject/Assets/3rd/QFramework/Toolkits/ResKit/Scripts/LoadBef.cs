
using System.Collections.Generic;
using UnityEngine.U2D;
using UnityEngine;
using System;
using UnityEditor;
using JetBrains.Annotations;
using UnityEditor.Animations;
using QFramework;
public class ResMgrPre : MonoSingleton<ResMgrPre> { 
    private ResMgrPre() { }
    private Dictionary<string, GameObject> _Prefabs = new Dictionary<string, GameObject>();
    private Dictionary<string, Sprite> _SpriteFrames = new Dictionary<string, Sprite>();
    private Dictionary<string, SpriteAtlas> _SpriteAtlass = new Dictionary<string, SpriteAtlas>();
    private Dictionary<string, AudioClip> _AudioClips = new Dictionary<string, AudioClip>();
    private Dictionary<string, TextAsset> _JsonAssets = new Dictionary<string, TextAsset>();
    private Dictionary<string, AnimationClip> _AnimationClips = new Dictionary<string, AnimationClip>();
    private Dictionary<string, TextAsset> _TiledMapAssets = new Dictionary<string, TextAsset>();
    private Dictionary<string, AnimatorController> _AnimatorControllers = new Dictionary<string, AnimatorController>();
    /// <summary>
    /// 添加对应的资源
    /// </summary>
    /// <typeparam name="T">所要添加的类型</typeparam>
    /// <param name="dict">存放资源的字典</param>
    public void AddResource<T>(Dictionary<String, T> dict) where T : UnityEngine.Object
    {
        T[] resouces = Resources.LoadAll<T>("");
        foreach (T resource in resouces)
        {
            string name = resource.name;
            if (!dict.ContainsKey(name))
            {
                dict.Add(name, resource);
            }
            
        }
    }
    /// <summary>
    /// 统一添加资源
    /// </summary>
    public void AddRes()
    {
        //传入参数自动适应相应的类型
        AddResource(_Prefabs);
        AddResource(_SpriteFrames);
        AddResource(_SpriteAtlass);
        AddResource(_AudioClips);
        AddResource(_JsonAssets);
        AddResource(_AnimationClips);
        AddResource(_TiledMapAssets);
        AddResource(_AnimatorControllers);
    }
    /// <summary>
    /// 获取资源
    /// </summary>
    /// <typeparam name="T">资源类型</typeparam>
    /// <param name="dic">存放资源的字典</param>
    /// <param name="name">资源名称</param>
    /// <returns></returns>
    public T GetResource<T>(Dictionary<string, T> dic, string name) where T : UnityEngine.Object
    {
        if (dic.ContainsKey(name))
        {
            return dic[name];
        }
        else
        {
            Debug.LogError(name + "资源不存在");
            return null;
        }
    }
    //下面是一些获取对应资源的接口
    public GameObject GetObject(string name)
    {
        return GetResource(_Prefabs, name);
    }

    public Sprite GetSprite(string name)
    {
        return GetResource(_SpriteFrames, name);
    }

    public SpriteAtlas GetSpriteAtlas(string name)
    {
        return GetResource(_SpriteAtlass, name);
    }

    public AudioClip GetAudioClip(string name)
    {
        return GetResource(_AudioClips, name);
    }

    public TextAsset GetJsonAssets(string name)
    {
        return GetResource(_JsonAssets, name);
    }

    public AnimationClip GetAnimationClip(string name)
    {
        return GetResource(_AnimationClips, name);
    }

    public TextAsset GetMap(string name)
    {
        return GetResource(_TiledMapAssets, name);
    }
    public AnimatorController GetAnimatorCtl(string name)
    {
        return GetResource(_AnimatorControllers, name);
    }
    public GameObject InstantiateObj(string name)
    {
        //进行预制体的实例化
        return Instantiate(GetObject(name)); 
    }
}