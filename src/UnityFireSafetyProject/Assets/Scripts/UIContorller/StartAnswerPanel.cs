using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.UnityFireSafetyProject
{
	public class StartAnswerPanelData : UIPanelData
	{
	}
	public partial class StartAnswerPanel : UIPanel
	{
        protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as StartAnswerPanelData ?? new StartAnswerPanelData();
            // please add init code here
        }
		
		protected override void OnOpen(IUIData uiData = null)
		{
            MianPlayer.contrll.Value = false;
            MouseContoller.isLocked = false;
        }
		
		protected override void OnShow()
		{
            this.BtnStart.onClick.AddListener(() =>
            {
                UIKit.ClosePanel<StartAnswerPanel>();
                UIKit.OpenPanel<AnswerPanel>();
            });
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
