using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.UnityFireSafetyProject
{
	public class UIHomeData : UIPanelData
	{
	}
	public partial class UIHome : UIPanel
	{
		protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as UIHomeData ?? new UIHomeData();
			// please add init code here
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
