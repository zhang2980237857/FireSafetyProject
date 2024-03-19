
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
    /// ��Ӷ�Ӧ����Դ
    /// </summary>
    /// <typeparam name="T">��Ҫ��ӵ�����</typeparam>
    /// <param name="dict">�����Դ���ֵ�</param>
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
    /// ͳһ�����Դ
    /// </summary>
    public void AddRes()
    {
        //��������Զ���Ӧ��Ӧ������
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
    /// ��ȡ��Դ
    /// </summary>
    /// <typeparam name="T">��Դ����</typeparam>
    /// <param name="dic">�����Դ���ֵ�</param>
    /// <param name="name">��Դ����</param>
    /// <returns></returns>
    public T GetResource<T>(Dictionary<string, T> dic, string name) where T : UnityEngine.Object
    {
        if (dic.ContainsKey(name))
        {
            return dic[name];
        }
        else
        {
            Debug.LogError(name + "��Դ������");
            return null;
        }
    }
    //������һЩ��ȡ��Ӧ��Դ�Ľӿ�
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
        //����Ԥ�����ʵ����
        return Instantiate(GetObject(name)); 
    }
}