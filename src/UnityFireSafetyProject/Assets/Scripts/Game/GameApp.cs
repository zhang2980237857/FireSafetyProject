using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
using System;
using QFramework.UnityFireSafetyProject;

public class GameApp : MonoSingleton<GameApp>
{
 
    //游戏逻辑的入口代码 ,全局只有唯一一个,设立为单例对象
    public void InitGame()
    {
        this.EnterMainScene();
    }

    private void EnterMainScene()
    {
        //实例化主场景,实例化我们的有些UI界面
        UIKit.OpenPanel<UILoading>();
    }
}
