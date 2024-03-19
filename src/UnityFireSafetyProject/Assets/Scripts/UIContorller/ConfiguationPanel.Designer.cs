using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.UnityFireSafetyProject
{
	// Generate Id:f71b1c95-0096-4c9c-a70b-1e95127e7382
	public partial class ConfiguationPanel
	{
		public const string Name = "ConfiguationPanel";
		
		[SerializeField]
		public UnityEngine.UI.Button BtnContinue;
		[SerializeField]
		public UnityEngine.UI.Button BtnExit;
		[SerializeField]
		public UnityEngine.UI.Toggle BkMusic;
		[SerializeField]
		public UnityEngine.UI.Toggle Sound;
		[SerializeField]
		public UnityEngine.UI.Slider BkVolume;
		[SerializeField]
		public UnityEngine.UI.Slider SdVolume;
		
		private ConfiguationPanelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			BtnContinue = null;
			BtnExit = null;
			BkMusic = null;
			Sound = null;
			BkVolume = null;
			SdVolume = null;
			
			mData = null;
		}
		
		public ConfiguationPanelData Data
		{
			get
			{
				return mData;
			}
		}
		
		ConfiguationPanelData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new ConfiguationPanelData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
