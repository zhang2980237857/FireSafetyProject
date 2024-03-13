using QFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lanch : MonoBehaviour
{
    void Awake()
    {
        //初始化检查游戏更新
        this.InitHotUpdate();


        //初始化游戏所需框架
        this.InitFramework();

        //初始化游戏主要逻辑
        this.InitGameLogic();
    }

    private void InitGameLogic()
    {
        //此处撰写初始化游戏主要逻辑
        LogKit.I("....游戏启动成功!!!");
    }

    private void InitFramework()
    {
       //此处撰写初始化游戏框架逻辑
    }

    private void InitHotUpdate()
    {
       //这里面实现游戏更新逻辑
    }
}
