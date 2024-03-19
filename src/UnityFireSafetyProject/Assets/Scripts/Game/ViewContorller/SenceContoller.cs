using UnityEngine;
using QFramework;

namespace QFramework.UnityFireSafetyProject
{
	public partial class SenceContoller : ViewController
	{
		public ResLoader mResLoader;
		void Start()
		{
            mResLoader = ResLoader.Allocate();
            //场景控制脚本
            //生成主角色
            mResLoader.LoadSync<GameObject>("MianPlayer").Instantiate();
		}
	}
}
