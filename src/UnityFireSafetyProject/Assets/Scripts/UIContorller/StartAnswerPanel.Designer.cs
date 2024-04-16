using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.UnityFireSafetyProject
{
	// Generate Id:21de28fb-ec44-4277-80e4-4bebc1ac7742
	public partial class StartAnswerPanel
	{
		public const string Name = "StartAnswerPanel";
		
		[SerializeField]
		public UnityEngine.UI.Button BtnStart;
		
		private StartAnswerPanelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			BtnStart = null;
			
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
