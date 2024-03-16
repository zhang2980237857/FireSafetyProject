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
			//BtnContinue.GetComponent<Text>().text = "��Ϸ����";
			//BtnExit.GetComponent<Text>().text = "��Ϸ�˳�";
            BtnContinue.onClick.AddListener(() => { 
				this.CloseSelf();
				print("��Ϸ����");
			});
			BtnExit.onClick.AddListener(() =>
			{
				//�˳���Ϸ,�л�����ʼ����
				print("�˳���Ϸ");
			});
			BkMusic.onValueChanged.AddListener((bool isOpen) =>{
				if(isOpen)
				{
					//��������
					print("��������");
				}
			});
			Sound.onValueChanged.AddListener((bool isOpen) =>
			{
				if (isOpen)
				{
					//������Ч
					print("������Ч");
				}
			});
			BkVolume.onValueChanged.AddListener((float VolumeRate) =>
			{
				//��������
				print(VolumeRate);
			});
			SdVolume.onValueChanged.AddListener((float VolumeRate) =>{

                //��������
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
