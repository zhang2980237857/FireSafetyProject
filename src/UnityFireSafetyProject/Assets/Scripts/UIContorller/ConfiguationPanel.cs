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
            //    MouseContoller.isLocked = true; //锁定鼠标
            //    this.CloseSelf();
            //    print("游戏继续");
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
            //TODO角色暂停
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
            //两次esc进行关闭
            if (Input.GetKeyDown(KeyCode.Escape) && !UILoading.isLoading.Value)
            {
                MouseContoller.isLocked = true; //锁定鼠标
                MianPlayer.timeSet.Value = 1;
                this.CloseSelf();
            }
        }
        private void OnContiuneClicked()
        {
            MouseContoller.isLocked = true; //锁定鼠标
            MianPlayer.timeSet.Value = 1;
            this.CloseSelf();
            print("游戏继续");
        }
        private void OnExitClicked()
        {
            //退出游戏,切换到初始界面
            print("退出游戏");
        }
        private void OnBkMusicValueChanged(bool IsOpen)
        {
            if (IsOpen)
            {
                //开启音效
                print("开启背景音乐");
            }
        }
        private void OnSoundValueChanged(bool IsOpen)
        {
            if (IsOpen)
            {
                //开启音效
                print("开启音效");
            }
        }
        private void OnBkVolumeValueChanged(float volumeRate)
        {
            //控制音量
            print(volumeRate);
        }

        private void OnSdVolumeValueChanged(float volumeRate)
        {
            //控制音量
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
            //后续可用对象池实现，减少开销
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
            //移除监听器防止可能的内存泄露
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
