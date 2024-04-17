using UnityEngine;
using QFramework;
using UnityEditor.SceneManagement;

namespace QFramework.UnityFireSafetyProject
{
	public partial class changjing : ViewController
	{
        void Start()
        {
            MianPlayer.contrll.Value = true;
            // Code Here
        }
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.Escape) && MianPlayer.showState.Value == false)
            {
                UIKit.OpenPanel<ConfiguationPanel>();
            }
        }
    }
}
