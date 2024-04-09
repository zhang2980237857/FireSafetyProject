using UnityEngine;
using DG.Tweening;

namespace QFramework.UnityFireSafetyProject
{
    public enum PlayerState //玩家状态
    {
        None,
        Walk,
        Run,
        Jump
    }
    public partial class MianPlayer : ViewController
    {
        public float moveSpeed = 5f;    //角色移动速度
        public PlayerState playerState = PlayerState.None;
        Vector3 moveAmount;             //移动距离
        Animator anim;		//角色动画控制器
        private CharacterController characterController;
        public static BindableProperty<int> timeSet = new BindableProperty<int>(1);
        public static BindableProperty<bool> contrll = new BindableProperty<bool>(false);
        public static BindableProperty<bool> showState = new BindableProperty<bool>(true);
        public GameObject image;
        private GameObject previousHitObject; // 之前被碰撞的物体
        private float rayDistance = 4f;   //玩家最大可获取物体范围
        Vector3 velocity;
        
        void Start()
        {
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
            RunSpeed();
            PlayerMoving();
            image.SetActive(showState.Value);

        }
        private void PlayerMoving()
        {
            float hor = Input.GetAxisRaw("Horizontal");
            float ver = Input.GetAxisRaw("Vertical");

            
            //获取移动方位
            moveAmount = (transform.right * hor + transform.forward * ver).normalized;
            if (moveAmount!= Vector3.zero)
            {
                //转换为移动距离
                characterController.Move(moveAmount * moveSpeed * Time.deltaTime);  //角色移动
                                                                                    //来点重力
                if (playerState != PlayerState.Run && moveSpeed <=10)
                {
                    playerState = PlayerState.Walk;
                }else if (moveSpeed >= 10)
                {
                    playerState = PlayerState.Run;
                }
                velocity.y += -9.81f * Time.deltaTime;
                characterController.Move(velocity * Time.deltaTime);  //角色收到重力
            }
            
        }
        private void CheckForwordObject()   //检测前方是否有物体
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width/2,Screen.height/2, 0));//从屏幕中键发射一条射线
            RaycastHit hit;
            if (Physics.Raycast(ray,out hit,rayDistance))    //判断是否碰撞物体
            {
                
                if (hit.collider.transform.CompareTag("InteractiveObj"))
                {
                    bool isRunDotween = false;
                    if (previousHitObject != null && previousHitObject != hit.collider.gameObject)
                    {
                        //设置高光关闭
                        previousHitObject.GetComponent<HighlightableObject>().ConstantOff();
                        
                        previousHitObject = null; // 将之前被碰撞的物体设为null
                    }
                    if (previousHitObject == null)
                    {
                        
                        if (hit.collider.transform.name.Contains("消防标识")&&!isRunDotween)
                        {
                            isRunDotween = true;
                            Vector3 initScale = hit.collider.transform.localScale; //消防物体标识的初始缩放
                            hit.collider.transform.DOScale(hit.collider.transform.localScale * 1.2f, 0.8f).OnComplete(() => { hit.collider.transform.DOScale(initScale, 0.4f); isRunDotween = false; });
                        }
                        //打开高光一次
                        hit.collider.gameObject.GetComponent<HighlightableObject>().ConstantOn(Color.red);
                    }
                    previousHitObject = hit.collider.gameObject;//把当前物体保存起来
                    //判断场景中是否已经存在展示界面，如果已经存在就不再生成
                    if (!GameObject.Find("showPrecorrect(Clone)") && Input.GetMouseButtonDown(0))
                    {
                        //实例化物体
                        if (!previousHitObject.name.Contains("消防标识"))
                        {
                            GameApp.Instance.mResLoader.LoadSync<GameObject>("showPrecorrect").Instantiate().GetComponentInChildren<Insiantiateobj>().ints(previousHitObject.transform.gameObject);
                            MianPlayer.showState.Value = false;
                        }
                        else if (previousHitObject.name.Contains("消防标识"))
                        {
                            //对于消防标识类逻辑
                            previousHitObject.GetComponent<HighlightableObject>().ToFireFlagPannel("这是main面板传递的信息" + transform.name);
                        }
                    }
                }
                else if(!hit.collider.transform.CompareTag("InteractiveObj")&& previousHitObject!=null)
                {
                    //设置高光关闭
                    previousHitObject.GetComponent<HighlightableObject>().ConstantOff();
                    previousHitObject = null; // 将之前被碰撞的物体设为null
                }
            }
            else
            {
                // 如果射线没有击中任何物体，且之前被碰撞的物体不为空
                if (previousHitObject != null)
                {
                    //设置高光关闭
                    previousHitObject.GetComponent<HighlightableObject>().ConstantOff();
                    previousHitObject = null; // 将之前被碰撞的物体设为null
                }
            }
        }
        
        private void RunSpeed()
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                this.moveSpeed = 10;
                this.playerState = PlayerState.Run;
            }
            else
            {
                this.moveSpeed = 5;
                playerState = PlayerState.Walk;
            }
        }
    }
}
