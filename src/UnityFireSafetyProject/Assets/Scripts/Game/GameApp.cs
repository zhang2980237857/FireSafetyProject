using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
using System;
using QFramework.UnityFireSafetyProject;
using System.Runtime.CompilerServices;

public class GameApp : MonoSingleton<GameApp>
{
    //�������������ͬ����ʹ�õļ�������ͬ
    public ResLoader mResLoader = ResLoader.Allocate();
    //��Ϸ�߼�����ڴ��� ,ȫ��ֻ��Ψһһ��,����Ϊ��������
    public void InitGame()
    {
        this.EnterMainScene();
    }

    private void EnterMainScene()
    {
        //������ԴԤ����
        ResMgrPre.Instance.AddRes();
        //ʵ����������,ʵ�������ǵ���ЩUI����
        UIKit.OpenPanel<UILoading>();
        UILoading.isLoading.RegisterWithInitValue((a) => {
            if (!a)
            {
                //���س���
                //���г�����ʵ����
                mResLoader.LoadSync<GameObject>("Showroom").Instantiate();
            }
        }).UnRegisterWhenGameObjectDestroyed(this.gameObject);
    }
    protected override void OnDestroy()
    {
        //���ս�����
        mResLoader.Recycle2Cache();
        mResLoader = null;
    }
}
