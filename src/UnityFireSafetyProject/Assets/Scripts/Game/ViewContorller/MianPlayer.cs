using UnityEngine;
using QFramework;
using UnityEngine.UIElements;
using UnityEngine.Playables;
using DG.Tweening;

namespace QFramework.UnityFireSafetyProject
{
    public enum PlayerState //���״̬
    {
        None,
        Walk,
        Run,
        Jump
    }
    public partial class MianPlayer : ViewController
    {
        public float moveSpeed = 5f;    //��ɫ�ƶ��ٶ�
        public PlayerState playerState = PlayerState.None;
        Vector3 moveAmount;             //�ƶ�����
        Animator anim;		//��ɫ����������
        private CharacterController characterController;
        public static BindableProperty<int> timeSet = new BindableProperty<int>(1);
        public static BindableProperty<bool> contrll = new BindableProperty<bool>(false);
        public static BindableProperty<bool> showState = new BindableProperty<bool>(true);
        public GameObject image;
        private GameObject previousHitObject; // ֮ǰ����ײ������
        private float rayDistance = 4f;   //������ɻ�ȡ���巶Χ
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
            RunSpeed();
            PlayerMoving();
            image.SetActive(showState.Value);

        }
        private void PlayerMoving()
        {
            float hor = Input.GetAxisRaw("Horizontal");
            float ver = Input.GetAxisRaw("Vertical");

            
            //��ȡ�ƶ���λ
            moveAmount = (transform.right * hor + transform.forward * ver).normalized;
            if (moveAmount!= Vector3.zero)
            {
                //ת��Ϊ�ƶ�����
                characterController.Move(moveAmount * moveSpeed * Time.deltaTime);  //��ɫ�ƶ�
                                                                                    //��������
                if (playerState != PlayerState.Run && moveSpeed <=10)
                {
                    playerState = PlayerState.Walk;
                }else if (moveSpeed >= 10)
                {
                    playerState = PlayerState.Run;
                }
                velocity.y += -9.81f * Time.deltaTime;
                characterController.Move(velocity * Time.deltaTime);  //��ɫ�յ�����
            }
            
        }
        private void CheckForwordObject()   //���ǰ���Ƿ�������
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width/2,Screen.height/2, 0));//����Ļ�м�����һ������
            RaycastHit hit;
            if (Physics.Raycast(ray,out hit,rayDistance))    //�ж��Ƿ���ײ����
            {
                if (hit.collider.transform.CompareTag("InteractiveObj"))
                {
                    if (previousHitObject != null && previousHitObject != hit.collider.gameObject)
                    {
                        //���ø߹�ر�
                        previousHitObject.GetComponent<HighlightableObject>().ConstantOff();
                        previousHitObject.GetComponent<Animation>().enabled = false;
                        previousHitObject = null; // ��֮ǰ����ײ��������Ϊnull
                    }
                    previousHitObject = hit.collider.gameObject;//��������
                    //�жϳ������Ƿ��Ѿ�����չʾ���棬����Ѿ����ھͲ�������
                    if (!GameObject.Find("showPrecorrect(Clone)") && Input.GetMouseButtonDown(0))
                    {
                        
                        //ʵ��������
                        if (!previousHitObject.name.Contains("������ʶ"))
                        {
                            GameApp.Instance.mResLoader.LoadSync<GameObject>("showPrecorrect").Instantiate().GetComponentInChildren<Insiantiateobj>().ints(previousHitObject.transform.gameObject);
                            MianPlayer.showState.Value = false;
                        }
                        else
                        {
                            //����������ʶ���߼�
                            Debug.Log(previousHitObject.name);
                            
                        }
                    }
                    //�򿪸߹�
                    previousHitObject.GetComponent<HighlightableObject>().ConstantOn(Color.red);
                    previousHitObject.GetComponent<Animation>().enabled = true;
                    if (Input.GetMouseButtonDown(0))
                    {
                        previousHitObject.GetComponent<HighlightableObject>().ToFireFlagPannel("����main��崫�ݵ���Ϣ"+transform.name);
                    }
                }
            }
            else
            {
                // �������û�л����κ����壬��֮ǰ����ײ�����岻Ϊ��
                if (previousHitObject != null)
                {
                    //���ø߹�ر�
                    previousHitObject.GetComponent<HighlightableObject>().ConstantOff();
                    previousHitObject.GetComponent<Animation>().enabled = false;
                    previousHitObject = null; // ��֮ǰ����ײ��������Ϊnull
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
