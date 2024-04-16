using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.UnityFireSafetyProject
{
	public class AnswerPanelData : UIPanelData
	{
	}
	public partial class AnswerPanel : UIPanel
	{
		protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as AnswerPanelData ?? new AnswerPanelData();
			// please add init code here
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
