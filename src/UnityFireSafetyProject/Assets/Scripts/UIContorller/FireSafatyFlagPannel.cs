using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.UnityFireSafetyProject
{
	public class FireSafatyFlagPannelData : UIPanelData
	{
		public string info = "";	//ҳ����������
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
        }
		
		protected override void OnShow()
		{
		}
		
		protected override void OnHide()
		{
            MianPlayer.contrll.Value = true;
            MouseContoller.isLocked = true;
        }
		
		protected override void OnClose()
		{
            
        }
	}
}
