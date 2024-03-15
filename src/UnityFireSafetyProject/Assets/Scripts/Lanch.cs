using QFramework;
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

        //先将游戏逻辑脚本挂载到启动节点上
        this.gameObject.AddComponent<GameApp>();
        //调用其中的启动代码
        GameApp.Instance.InitGame();
    }

    private void InitFramework()
    {
        //此处撰写初始化游戏框架逻辑
        ResKit.Init();  //初始化资源管理
        
    }

    private void InitHotUpdate()
    {
        //这里面实现游戏更新逻辑
    }
}
