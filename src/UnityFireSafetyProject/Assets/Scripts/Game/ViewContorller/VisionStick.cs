using UnityEngine;
using QFramework;
using System.Runtime.CompilerServices;
using TMPro;

namespace QFramework.UnityFireSafetyProject
{
    
    public partial class VisionStick : ViewController
	{
        Collider other1;
        GameObject obj;
		void Start()
		{

        }

        private void Update()
        {
            if (other1 != null&& Input.GetMouseButtonDown(0))
            {
                Debug.Log("�����...");
                try
                {
                    //�жϳ������Ƿ��Ѿ�����չʾ���棬����Ѿ����ھͲ�������
                    if (!GameObject.Find("showPrecorrect(Clone)"))
                    {
                        obj = GameApp.Instance.mResLoader.LoadSync<GameObject>("showPrecorrect").Instantiate();
                        obj.GetComponentInChildren<Insiantiateobj>().ints(other1.transform.gameObject);
                        MianPlayer.showState.Value = false;
                    }
                }
                catch
                {
                    Debug.Log("δ��ȡչʾ����");
                }
            }
        }
       
    }
}
