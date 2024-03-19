using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.UnityFireSafetyProject
{
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
		[SerializeField]
		public UnityEngine.UI.Button Setup1;
		[SerializeField]
		public UnityEngine.UI.Button Setup2;
		[SerializeField]
		public UnityEngine.UI.Button Map;
		[SerializeField]
		public UnityEngine.UI.Text Identify;
		[SerializeField]
		public UnityEngine.UI.Image Map1;
		
		private ConfiguationPanelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			BtnContinue = null;
			BtnExit = null;
			BkMusic = null;
			Sound = null;
			BkVolume = null;
			SdVolume = null;
			Setup1 = null;
			Setup2 = null;
			Map = null;
			Identify = null;
			Map1 = null;
			
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
