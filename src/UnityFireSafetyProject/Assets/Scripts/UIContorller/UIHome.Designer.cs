using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.UnityFireSafetyProject
{
	// Generate Id:9026242f-6ecc-4dc4-8558-27bff280637e
	public partial class UIHome
	{
		public const string Name = "UIHome";
		
		
		private UIHomeData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			
			mData = null;
		}
		
		public UIHomeData Data
		{
			get
			{
				return mData;
			}
		}
		
		UIHomeData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new UIHomeData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
