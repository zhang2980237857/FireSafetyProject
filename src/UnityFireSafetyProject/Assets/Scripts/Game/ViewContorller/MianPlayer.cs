using UnityEngine;
using QFramework;

namespace QFramework.UnityFireSafetyProject
{
    public partial class MianPlayer : ViewController
    {
        public float moveSpeed = 5f;    //角色移动速度
        Vector3 moveAmount;             //移动距离
        Animator anim;		//角色动画控制器
        private CharacterController characterController;
        void Start()
        {
            //anim = GetComponent<Animator>();
            characterController = this.GetComponent<CharacterController>();

        }

        void FixedUpdate()
        {
            PlayerMoving();
        }
        private void PlayerMoving()
        {
            float hor = Input.GetAxisRaw("Horizontal");
            float ver = Input.GetAxisRaw("Vertical");

            //获取移动方位
            moveAmount = (transform.right * hor + transform.forward * ver).normalized;
            //转换为移动距离
            characterController.Move(moveAmount*moveSpeed*Time.deltaTime);  //角色移动
        }
    }
}
