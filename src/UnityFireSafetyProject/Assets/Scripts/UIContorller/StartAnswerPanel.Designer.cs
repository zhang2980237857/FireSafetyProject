using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.UnityFireSafetyProject
{
	// Generate Id:c29f8c60-c307-4ace-b8ae-1adf3db0e49b
	public partial class StartAnswerPanel
	{
		public const string Name = "StartAnswerPanel";
		
		
		private StartAnswerPanelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			
			mData = null;
		}
		
		public StartAnswerPanelData Data
		{
			get
			{
				return mData;
			}
		}
		
		StartAnswerPanelData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new StartAnswerPanelData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
