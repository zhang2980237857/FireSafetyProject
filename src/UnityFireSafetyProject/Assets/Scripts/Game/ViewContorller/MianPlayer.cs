using UnityEngine;
using QFramework;

namespace QFramework.UnityFireSafetyProject
{
    public partial class MianPlayer : ViewController
    {
        public float moveSpeed = 5f;    //��ɫ�ƶ��ٶ�
        Vector3 moveAmount;             //�ƶ�����
        Animator anim;		//��ɫ����������
        private CharacterController characterController;
        public static BindableProperty<int> timeSet = new BindableProperty<int>(1);
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
