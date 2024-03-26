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
                Debug.Log("鼠标点击...");
                try
                {
                    //判断场景中是否已经存在展示界面，如果已经存在就不再生成
                    if (!GameObject.Find("showPrecorrect(Clone)"))
                    {
                        obj = GameApp.Instance.mResLoader.LoadSync<GameObject>("showPrecorrect").Instantiate();
                        obj.GetComponentInChildren<Insiantiateobj>().ints(other1.transform.gameObject);
                        MianPlayer.showState.Value = false;
                    }
                }
                catch
                {
                    Debug.Log("未获取展示界面");
                }
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "InteractiveObj") //如何检测的是可交互物体就让它高光
            {
                 other1 = other;
                //改为脚本的显示跟取消
                other.GetComponent<Outline>().enabled = true;
                other.GetComponent<Outline>().OutlineMode = Outline.Mode.OutlineVisible;
                
            }
        }
        private void OnTriggerExit(Collider other)
        {
            other1 = null;
            if (other.tag == "InteractiveObj") //如何检测的是可交互物体就让它高光
            {
                other.GetComponent<Outline>().enabled = false;
                other.GetComponent<Outline>().OutlineMode = Outline.Mode.OutlineHidden;
            }
        }
    }
}
