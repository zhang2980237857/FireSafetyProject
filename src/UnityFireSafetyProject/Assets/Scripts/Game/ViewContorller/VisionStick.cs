using UnityEngine;
using QFramework;

namespace QFramework.UnityFireSafetyProject
{

    public partial class VisionStick : ViewController
	{
        Collider other1;
		void Start()
		{
			
		}

        private void Update()
        {
            if (other1 != null&& Input.GetMouseButtonDown(0))
            {
                Debug.Log("�����...");
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
