using QFramework.UnityFireSafetyProject;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseContoller : MonoBehaviour
{
    private Transform playerTransform; //先获取玩家位置
    private float mouseSensivity = 300f; //鼠标灵敏度
    private float yRotation = 0;    //y轴旋转
    private float height = 1.8f;        //玩家高度
    public static bool isLocked;   //是否锁定还是放开鼠标
    private CharacterController characterController;
    void Start()
    {
        isLocked = true;
        playerTransform = transform.GetComponentInParent<MianPlayer>().transform;
        characterController = GetComponentInParent<CharacterController>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        RotationView();//避免角色移动的时候旋转摄像头出现抖动
    }
    private void RotationView()
    {
        //一进来设置鼠标锁定
        Cursor.lockState = isLocked ? CursorLockMode.Locked : CursorLockMode.None;
        float mouseX = Input.GetAxis("Mouse X") * mouseSensivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensivity * Time.deltaTime;
        yRotation -= mouseY;
        yRotation = Mathf.Clamp(yRotation, -60f, 60f);          //保持旋转角度在-60到60度之间
        transform.localRotation = Quaternion.Euler(yRotation, 0, 0); //摄像机上下旋转
        playerTransform.Rotate(mouseX * Vector3.up);  //玩家左右旋转
    }
    
}
