using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
using System;
using QFramework.UnityFireSafetyProject;

public class GameApp : MonoSingleton<GameApp>
{
 
    //��Ϸ�߼�����ڴ��� ,ȫ��ֻ��Ψһһ��,����Ϊ��������
    public void InitGame()
    {
        this.EnterMainScene();
    }

    private void EnterMainScene()
    {
        //ʵ����������,ʵ�������ǵ���ЩUI����
        UIKit.OpenPanel<UILoading>();
    }
}
