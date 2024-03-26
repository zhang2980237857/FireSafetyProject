using UnityEngine;
using QFramework;
using UnityEngine.UIElements;

namespace QFramework.UnityFireSafetyProject
{
    public partial class MianPlayer : ViewController
    {
        public float moveSpeed = 5f;    //��ɫ�ƶ��ٶ�
        Vector3 moveAmount;             //�ƶ�����
        Animator anim;		//��ɫ����������
        private CharacterController characterController;
        public static BindableProperty<int> timeSet = new BindableProperty<int>(1);
        public static BindableProperty<bool> contrll = new BindableProperty<bool>(false);
        public static BindableProperty<bool> showState = new BindableProperty<bool>(true);
        public GameObject image;
        void Start()
        {
            
            //anim = GetComponent<Animator>();
            characterController = this.GetComponent<CharacterController>();
            timeSet.RegisterWithInitValue((timeSet) =>
            {
                Time.timeScale = timeSet;
            }).UnRegisterWhenGameObjectDestroyed(this);

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

            //��ȡ�ƶ���λ
            moveAmount = (transform.right * hor + transform.forward * ver).normalized;
            //ת��Ϊ�ƶ�����
            characterController.Move(moveAmount*moveSpeed*Time.deltaTime);  //��ɫ�ƶ�
        }

      
    }
}
