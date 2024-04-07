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
		}
		
		protected override void OnShow()
		{
		}
		
		protected override void OnHide()
		{
		}
		
		protected override void OnClose()
		{
		}
	}
}
