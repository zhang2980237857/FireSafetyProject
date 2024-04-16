using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.UnityFireSafetyProject
{
	public class EnterPannelData : UIPanelData
	{
	}
	public partial class EnterPannel : UIPanel
	{
		ResLoader mLoader;

        protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as EnterPannelData ?? new EnterPannelData();
			 mLoader = ResLoader.Allocate();
        }
		
		protected override void OnOpen(IUIData uiData = null)
		{
        }
		
		protected override void OnShow()
		{
            this.EnterBtn.onClick.AddListener(() =>
            {
                mLoader.LoadSync<GameObject>("changjing").Instantiate();
				UIKit.ClosePanel<EnterPannel>();
            });
        }
		
		protected override void OnHide()
		{
        }
		
		protected override void OnClose()
		{
            //回收进度条
            mLoader.Recycle2Cache();
            mLoader = null;
        }
    }
}
