using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.UnityFireSafetyProject
{
	public class FireSafatyFlagPannelData : UIPanelData
	{
		public string info = "";	//页面所需数据
	}
	public partial class FireSafatyFlagPannel : UIPanel
	{
		protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as FireSafatyFlagPannelData ?? new FireSafatyFlagPannelData();
			Debug.Log(mData.info);
		}
		
		protected override void OnOpen(IUIData uiData = null)
		{
            //先解除鼠标锁定
            MouseContoller.isLocked = false;
        }
		
		protected override void OnShow()
		{
		}
		
		protected override void OnHide()
		{
            //当当前面板被关闭的时候
            //锁定鼠标
            MouseContoller.isLocked = true;
        }
		
		protected override void OnClose()
		{
            
        }
	}
}
