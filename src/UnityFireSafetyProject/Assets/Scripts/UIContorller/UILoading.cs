using UnityEngine;
using UnityEngine.UI;
using QFramework;
using System;
using static UnityEngine.GraphicsBuffer;
using UnityEditor;

namespace QFramework.UnityFireSafetyProject
{
	
	public class UILoadingData : UIPanelData
	{
		public int loadingNum;
        
    }
    public partial class UILoading : UIPanel
	{
        private float timer;
        public static BindableProperty<bool> isLoading = new BindableProperty<bool>(true);
        //bool isLoading = true;
        public ResLoader mResLoader2 = ResLoader.Allocate();
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
			if (isLoading.Value)
			{
				timer += Time.deltaTime;
				LoadingSlider.value = (timer / 100) * 20;
				LoadingProgress.text = "ÕýÔÚ¼ÓÔØ : " + Convert.ToInt32(timer * 20) + "%";
				if (timer > 5)
				{
					timer = 0;
					isLoading.Value = false;
					this.CloseSelf();
				}
			}

			if(Input.GetKeyDown(KeyCode.Escape))
			{
				mResLoader2.LoadSync<GameObject>("ConfiguationPanel").Instantiate();
			}
        }
    }
}
