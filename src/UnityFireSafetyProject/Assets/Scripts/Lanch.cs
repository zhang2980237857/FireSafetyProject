using QFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lanch : MonoBehaviour
{
    void Awake()
    {
        //��ʼ�������Ϸ����
        this.InitHotUpdate();


        //��ʼ����Ϸ������
        this.InitFramework();

        //��ʼ����Ϸ��Ҫ�߼�
        this.InitGameLogic();
    }

    private void InitGameLogic()
    {
        //�˴�׫д��ʼ����Ϸ��Ҫ�߼�
        LogKit.I("....��Ϸ�����ɹ�!!!");
    }

    private void InitFramework()
    {
       //�˴�׫д��ʼ����Ϸ����߼�
    }

    private void InitHotUpdate()
    {
       //������ʵ����Ϸ�����߼�
    }
}
