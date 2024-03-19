using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.UnityFireSafetyProject
{
<<<<<<< HEAD
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
            BtnContinue.onClick.AddListener(() =>
            {
                MouseContoller.isLocked = true; //�������
                this.CloseSelf();
                print("��Ϸ����");
            });
            BtnExit.onClick.AddListener(() =>
            {
                //�˳���Ϸ,�л�����ʼ����
                print("�˳���Ϸ");
            });
            BkMusic.onValueChanged.AddListener((bool isOpen) =>
            {
                if (isOpen)
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
            SdVolume.onValueChanged.AddListener((float VolumeRate) =>
            {

                //��������
                print(VolumeRate);
            });
        }

        protected override void OnOpen(IUIData uiData = null)
        {
            MouseContoller.isLocked = false;
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
=======
	public class ConfiguationPanelData : UIPanelData
	{
	}
	public partial class ConfiguationPanel : UIPanel
	{
		protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as ConfiguationPanelData ?? new ConfiguationPanelData();
			// please add init code here
			//��Ӽ����¼�����ʹ�����������������ں��ڵ�ά��
			BtnContinue.onClick.AddListener(OnContiuneClicked);
			BtnExit.onClick.AddListener(OnExitClicked);
			BkMusic.onValueChanged.AddListener(OnBkMusicValueChanged);
			BkVolume.onValueChanged.AddListener(OnBkVolumeValueChanged);
			Sound.onValueChanged.AddListener(OnSoundValueChanged);
			SdVolume.onValueChanged.AddListener(OnSdVolumeValueChanged);
			Setup1.onClick.AddListener(OpenSetUp1);
			Setup2.onClick.AddListener(OpenSetUp2);
			Map.onClick.AddListener(OpenMap);
			//BtnContinue.onClick.AddListener(() =>
			//{
			//	this.CloseSelf();
			//	print("��Ϸ����");
			//});
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
		protected override void OnBeforeDestroy()
		{
			//�Ƴ���������ֹ���ܵ��ڴ�й¶
			BtnContinue?.onClick?.RemoveAllListeners();
			BtnExit?.onClick?.RemoveAllListeners();
			BkMusic?.onValueChanged?.RemoveAllListeners();
			Sound?.onValueChanged?.RemoveAllListeners();
			BkVolume?.onValueChanged?.RemoveAllListeners();
			SdVolume?.onValueChanged?.RemoveAllListeners();
            Setup1?.onClick.RemoveAllListeners();
            Setup2?.onClick.RemoveAllListeners();
            Map?.onClick.RemoveAllListeners();
            base.OnBeforeDestroy();
		}
		private void Update()
		{
			//����esc���йر�
			if (Input.GetKeyDown(KeyCode.Escape) && !UILoading.isLoading.Value)
			{
				this.CloseSelf();
			}
		}
		private void OnContiuneClicked()
		{
			this.CloseSelf();
			print("��Ϸ����");
		}
		private void OnExitClicked()
		{
			//�˳���Ϸ,�л�����ʼ����
			print("�˳���Ϸ");
		}
		private void OnBkMusicValueChanged(bool IsOpen)
		{
			if (IsOpen)
			{
				//������Ч
				print("������������");
			}
		}
		private void OnSoundValueChanged(bool IsOpen)
		{
			if (IsOpen)
			{
				//������Ч
				print("������Ч");
			}
		}
		private void OnBkVolumeValueChanged(float volumeRate)
		{
			//��������
			print(volumeRate);
		}

		private void OnSdVolumeValueChanged(float volumeRate)
		{
			//��������
			print(volumeRate);
		}

		private void OpenSetUp1()
		{
			ActivatePanel(true, true, true,true, true, true, false, false);
		}

		private void OpenSetUp2()
		{
			ActivatePanel(false, false, false, false, false, false, true, false);
		}

		private void OpenMap()
		{
			ActivatePanel(false, false, false, false, false, false, false, true);
		}

		private void ActivatePanel(bool btnContinue, bool btnExit, bool bkMusic, bool bkVolume, bool sound, bool sdVolume, bool identify, bool map)
		{
			//�������ö����ʵ�֣����ٿ���
			BtnContinue.gameObject.SetActive(btnContinue);
			BtnExit.gameObject.SetActive(btnExit);
			BkMusic.gameObject.SetActive(bkMusic);
			BkVolume.gameObject.SetActive(bkVolume);
			Sound.gameObject.SetActive(sound);
			SdVolume.gameObject.SetActive(sdVolume);
			Identify.gameObject.SetActive(identify);
			Map1.gameObject.SetActive(map);
		}
	}
>>>>>>> 4bebca40286857b8c136724915324224944ab380
}
