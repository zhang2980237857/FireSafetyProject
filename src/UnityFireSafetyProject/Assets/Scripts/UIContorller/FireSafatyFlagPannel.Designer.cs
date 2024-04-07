using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.UnityFireSafetyProject
{
	// Generate Id:1024c223-bd4e-4a9f-a2eb-4d22097ca06f
	public partial class FireSafatyFlagPannel
	{
		public const string Name = "FireSafatyFlagPannel";
		
		
		private FireSafatyFlagPannelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			
			mData = null;
		}
		
		public FireSafatyFlagPannelData Data
		{
			get
			{
				return mData;
			}
		}
		
		FireSafatyFlagPannelData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new FireSafatyFlagPannelData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
