using UnityEngine;
using QFramework;

namespace QFramework.UnityFireSafetyProject
{
	public partial class VisionStick : ViewController
	{
		void Start()
		{
			
		}
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "InteractiveObj") //��μ����ǿɽ�������������߹�
            {
                //��Ϊ�ű�����ʾ��ȡ��
                other.GetComponent<Outline>().enabled = true;
                other.GetComponent<Outline>().OutlineMode = Outline.Mode.OutlineVisible;
                Debug.Log("������봥��");
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.tag == "InteractiveObj") //��μ����ǿɽ�������������߹�
            {
                other.GetComponent<Outline>().enabled = false;
                other.GetComponent<Outline>().OutlineMode = Outline.Mode.OutlineHidden;
                Debug.Log("�����ƿ�����");
            }
        }
    }
}
