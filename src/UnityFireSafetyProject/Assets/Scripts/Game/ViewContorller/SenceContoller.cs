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
            //�������ƽű�
            //��������ɫ
            mResLoader.LoadSync<GameObject>("MianPlayer").Instantiate();
		}
	}
}
