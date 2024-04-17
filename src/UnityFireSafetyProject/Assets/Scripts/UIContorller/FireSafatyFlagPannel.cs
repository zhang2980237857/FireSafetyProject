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
            MianPlayer.contrll.Value = false;
            MouseContoller.isLocked = false;
            MianPlayer.showState.Value = true;
        }
		
		protected override void OnShow()
		{
		}
		
		protected override void OnHide()
		{
            MianPlayer.contrll.Value = true;
            MouseContoller.isLocked = true;
            MianPlayer.showState.Value = false;
        }
		
		protected override void OnClose()
		{
            
        }
	}
}
