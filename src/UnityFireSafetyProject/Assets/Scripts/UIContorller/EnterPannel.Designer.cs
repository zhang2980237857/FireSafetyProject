using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.UnityFireSafetyProject
{
	// Generate Id:4c7aa872-0ec3-49be-b7a1-e154af73bf25
	public partial class EnterPannel
	{
		public const string Name = "EnterPannel";
		
		[SerializeField]
		public UnityEngine.UI.Button EnterBtn;
		
		private EnterPannelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			EnterBtn = null;
			
			mData = null;
		}
		
		public EnterPannelData Data
		{
			get
			{
				return mData;
			}
		}
		
		EnterPannelData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new EnterPannelData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
