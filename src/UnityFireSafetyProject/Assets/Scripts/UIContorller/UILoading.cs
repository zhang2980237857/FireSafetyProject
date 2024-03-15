using UnityEngine;
using UnityEngine.UI;
using QFramework;
using System;
using static UnityEngine.GraphicsBuffer;

namespace QFramework.UnityFireSafetyProject
{
	
	public class UILoadingData : UIPanelData
	{
		public int loadingNum;
	}
	public partial class UILoading : UIPanel
	{
		private float timer;
		public bool isLoading = true;
        protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as UILoadingData ?? new UILoadingData();
            mData.loadingNum = 0;
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
        void Update()
        {
			if (isLoading)
			{
				timer += Time.deltaTime;
				LoadingSlider.value = (timer / 100) * 20;
				LoadingProgress.text = "正在加载 : " + Convert.ToInt32(timer * 20) + "%";
				if (timer > 5)
				{
					timer = 0;
					isLoading = false;
					Debug.Log("加载页面完成,正在进入主界面...");
				}
			}
        }
    }
}
