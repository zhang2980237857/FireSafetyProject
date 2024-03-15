using QFramework;
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

        //�Ƚ���Ϸ�߼��ű����ص������ڵ���
        this.gameObject.AddComponent<GameApp>();
        //�������е���������
        GameApp.Instance.InitGame();
    }

    private void InitFramework()
    {
        //�˴�׫д��ʼ����Ϸ����߼�
        ResKit.Init();  //��ʼ����Դ����
        
    }

    private void InitHotUpdate()
    {
        //������ʵ����Ϸ�����߼�
    }
}
