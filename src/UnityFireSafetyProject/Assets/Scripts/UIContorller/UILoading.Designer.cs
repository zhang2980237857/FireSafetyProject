using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.UnityFireSafetyProject
{
	// Generate Id:ffd0e989-1ec1-469b-aacd-b23fc08a08bc
	public partial class UILoading
	{
		public const string Name = "UILoading";
		
		[SerializeField]
		public UnityEngine.UI.Slider LoadingSlider;
		[SerializeField]
		public UnityEngine.UI.Text LoadingProgress;
		
		private UILoadingData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			LoadingSlider = null;
			LoadingProgress = null;
			
			mData = null;
		}
		
		public UILoadingData Data
		{
			get
			{
				return mData;
			}
		}
		
		UILoadingData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new UILoadingData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
