using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.UnityFireSafetyProject
{
	public class ConfiguationPanelData : UIPanelData
	{
	}
	public partial class ConfiguationPanel : UIPanel
	{
		protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as ConfiguationPanelData ?? new ConfiguationPanelData();
			// please add init code here
			//BtnContinue.GetComponent<Text>().text = "游戏继续";
			//BtnExit.GetComponent<Text>().text = "游戏退出";
            BtnContinue.onClick.AddListener(() => { 
				this.CloseSelf();
				print("游戏继续");
			});
			BtnExit.onClick.AddListener(() =>
			{
				//退出游戏,切换到初始界面
				print("退出游戏");
			});
			BkMusic.onValueChanged.AddListener((bool isOpen) =>{
				if(isOpen)
				{
					//开启音乐
					print("开启音乐");
				}
			});
			Sound.onValueChanged.AddListener((bool isOpen) =>
			{
				if (isOpen)
				{
					//开启音效
					print("开启音效");
				}
			});
			BkVolume.onValueChanged.AddListener((float VolumeRate) =>
			{
				//控制音量
				print(VolumeRate);
			});
			SdVolume.onValueChanged.AddListener((float VolumeRate) =>{

                //控制音量
                print(VolumeRate);
            });
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
	}
}
