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
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "InteractiveObj") //��μ����ǿɽ�������������߹�
            {
                 other1 = other;
                //��Ϊ�ű�����ʾ��ȡ��
                other.GetComponent<Outline>().enabled = true;
                other.GetComponent<Outline>().OutlineMode = Outline.Mode.OutlineVisible;
                
            }
        }
        private void OnTriggerExit(Collider other)
        {
            other1 = null;
            if (other.tag == "InteractiveObj") //��μ����ǿɽ�������������߹�
            {
                other.GetComponent<Outline>().enabled = false;
                other.GetComponent<Outline>().OutlineMode = Outline.Mode.OutlineHidden;
            }
        }
    }
}
