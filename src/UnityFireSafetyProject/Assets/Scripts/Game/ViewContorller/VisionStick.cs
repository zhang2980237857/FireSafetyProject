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
            if (other.tag == "InteractiveObj") //如何检测的是可交互物体就让它高光
            {
                //改为脚本的显示跟取消
                other.GetComponent<Outline>().enabled = true;
                other.GetComponent<Outline>().OutlineMode = Outline.Mode.OutlineVisible;
                Debug.Log("物体进入触发");
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.tag == "InteractiveObj") //如何检测的是可交互物体就让它高光
            {
                other.GetComponent<Outline>().enabled = false;
                other.GetComponent<Outline>().OutlineMode = Outline.Mode.OutlineHidden;
                Debug.Log("物体移开触发");
            }
        }
    }
}
