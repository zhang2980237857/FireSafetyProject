using UnityEngine;
using QFramework;

namespace QFramework.UnityFireSafetyProject
{
	public partial class showPrecorrect : ViewController
	{
		void Start()
		{
            MianPlayer.contrll.Value = false;
            MouseContoller.isLocked = false;
            MianPlayer.showState.Value = true;
        }
		void OnDestroy()
		{
            MianPlayer.contrll.Value = true;
            MouseContoller.isLocked = true;
            MianPlayer.showState.Value = false;
        }
	}
}
