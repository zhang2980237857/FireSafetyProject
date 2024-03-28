using UnityEngine;
using QFramework;
using UnityEngine.UIElements;

namespace QFramework.UnityFireSafetyProject
{
    public partial class MianPlayer : ViewController
    {
        public float moveSpeed = 5f;    //角色移动速度
        Vector3 moveAmount;             //移动距离
        Animator anim;		//角色动画控制器
        private CharacterController characterController;
        public static BindableProperty<int> timeSet = new BindableProperty<int>(1);
        public static BindableProperty<bool> contrll = new BindableProperty<bool>(false);
        public static BindableProperty<bool> showState = new BindableProperty<bool>(true);
        public GameObject image;
        private GameObject previousHitObject; // 之前被碰撞的物体
        private float rayDistance = 2.5f;   //玩家最大可获取物体范围
        Vector3 velocity;
        void Start()
        {
            
            //anim = GetComponent<Animator>();
            characterController = this.GetComponent<CharacterController>();
            timeSet.RegisterWithInitValue((timeSet) =>
            {
                Time.timeScale = timeSet;
            }).UnRegisterWhenGameObjectDestroyed(this);

        }

         void Update()
        {
            CheckForwordObject();
        }
        void FixedUpdate()
        {
            PlayerMoving();
            image.SetActive(showState.Value);
            
        }
        private void PlayerMoving()
        {
            float hor = Input.GetAxisRaw("Horizontal");
            float ver = Input.GetAxisRaw("Vertical");

            //获取移动方位
            moveAmount = (transform.right * hor + transform.forward * ver).normalized;
            //转换为移动距离
            characterController.Move(moveAmount*moveSpeed*Time.deltaTime);  //角色移动
                                                                            //来点重力
            velocity.y += -9.81f * Time.deltaTime;
            characterController.Move(velocity * Time.deltaTime);  //角色收到重力
        }
        private void CheckForwordObject()   //检测前方是否有物体
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width/2,Screen.height/2, 0));//从屏幕中键发射一条射线
            RaycastHit hit;
            if (Physics.Raycast(ray,out hit,rayDistance))    //判断是否碰撞物体
            {
                if (hit.collider.transform.CompareTag("InteractiveObj"))
                {
                    if (previousHitObject != null && previousHitObject != hit.collider.gameObject)
                    {
                        previousHitObject.GetComponent<Outline>().enabled = false;
                        previousHitObject.GetComponent<Outline>().OutlineMode = Outline.Mode.OutlineHidden;
                        previousHitObject = null; // 将之前被碰撞的物体设为null
                    }
                    previousHitObject = hit.collider.gameObject;//保存起来
                    //判断场景中是否已经存在展示界面，如果已经存在就不再生成
                    if (!GameObject.Find("showPrecorrect(Clone)") && Input.GetMouseButtonDown(0))
                    {
                        //实例化物体
                        GameApp.Instance.mResLoader.LoadSync<GameObject>("showPrecorrect").Instantiate().GetComponentInChildren<Insiantiateobj>().ints(previousHitObject.transform.gameObject);
                        MianPlayer.showState.Value = false;
                    }
                    previousHitObject.GetComponent<Outline>().enabled = true;
                    previousHitObject.GetComponent<Outline>().OutlineMode = Outline.Mode.OutlineVisible;
                }
            }
            else
            {
                // 如果射线没有击中任何物体，且之前被碰撞的物体不为空
                if (previousHitObject != null)
                {
                    previousHitObject.GetComponent<Outline>().enabled = false;
                    previousHitObject.GetComponent<Outline>().OutlineMode = Outline.Mode.OutlineHidden;
                    previousHitObject = null; // 将之前被碰撞的物体设为null
                }
            }
        }

    }
}
