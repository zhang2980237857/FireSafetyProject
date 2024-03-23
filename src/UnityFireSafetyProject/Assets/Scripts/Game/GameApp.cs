using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
using System;
using QFramework.UnityFireSafetyProject;
using System.Runtime.CompilerServices;

public class GameApp : MonoSingleton<GameApp>
{
    //申请加载器，不同场景使用的加载器不同
    public ResLoader mResLoader = ResLoader.Allocate();
    //游戏逻辑的入口代码 ,全局只有唯一一个,设立为单例对象
    public void InitGame()
    {
        this.EnterMainScene();
    }

    private void EnterMainScene()
    {
        //进行资源预加载
        ResMgrPre.Instance.AddRes();
        //实例化主场景,实例化我们的有些UI界面
        UIKit.OpenPanel<UILoading>();
        UILoading.isLoading.RegisterWithInitValue((a) => {
            if (!a)
            {
                //加载场景
                //进行场景的实例化
                mResLoader.LoadSync<GameObject>("Showroom").Instantiate();
            }
        }).UnRegisterWhenGameObjectDestroyed(this.gameObject);
    }
    protected override void OnDestroy()
    {
        //回收进度条
        mResLoader.Recycle2Cache();
        mResLoader = null;
    }
}
