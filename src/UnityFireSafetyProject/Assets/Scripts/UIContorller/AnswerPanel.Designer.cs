using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.UnityFireSafetyProject
{
	// Generate Id:5f262a5c-9360-40a6-af85-4fa8cadcc76a
	public partial class AnswerPanel
	{
		public const string Name = "AnswerPanel";
		
		
		private AnswerPanelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			
			mData = null;
		}
		
		public AnswerPanelData Data
		{
			get
			{
				return mData;
			}
		}
		
		AnswerPanelData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new AnswerPanelData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
