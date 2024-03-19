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

            //BtnContinue.onClick.AddListener(() =>
            //{
            //    MouseContoller.isLocked = true; //�������
            //    this.CloseSelf();
            //    print("��Ϸ����");
            //});
            BtnContinue.onClick.AddListener(OnContiuneClicked);
            BtnExit.onClick.AddListener(OnExitClicked);
            BkMusic.onValueChanged.AddListener(OnBkMusicValueChanged);
            BkVolume.onValueChanged.AddListener(OnBkVolumeValueChanged);
            Sound.onValueChanged.AddListener(OnSoundValueChanged);
            SdVolume.onValueChanged.AddListener(OnSdVolumeValueChanged);
            Setup1.onClick.AddListener(OpenSetUp1);
            Setup2.onClick.AddListener(OpenSetUp2);
            Map.onClick.AddListener(OpenMap);
        }

        protected override void OnOpen(IUIData uiData = null)
        {
            MouseContoller.isLocked = false;
            //TODO��ɫ��ͣ
            MianPlayer.timeSet.Value = 0;
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

        private void Update()
        {
            //����esc���йر�
            if (Input.GetKeyDown(KeyCode.Escape) && !UILoading.isLoading.Value)
            {
                MouseContoller.isLocked = true; //�������
                MianPlayer.timeSet.Value = 1;
                this.CloseSelf();
            }
        }
        private void OnContiuneClicked()
        {
            MouseContoller.isLocked = true; //�������
            MianPlayer.timeSet.Value = 1;
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
            ActivatePanel(true, true, true, true, true, true, false, false);
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
    }
}
