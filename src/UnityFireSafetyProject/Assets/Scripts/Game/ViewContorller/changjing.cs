using UnityEngine;
using QFramework;

namespace QFramework.UnityFireSafetyProject
{
	public partial class changjing : ViewController
	{
        void Start()
        {
            // Code Here
        }
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                UIKit.OpenPanel<ConfiguationPanel>();
            }
        }
    }
}
