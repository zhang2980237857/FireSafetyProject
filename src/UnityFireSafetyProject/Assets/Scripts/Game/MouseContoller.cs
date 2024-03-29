using QFramework.UnityFireSafetyProject;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseContoller : MonoBehaviour
{
    private Transform playerTransform; //�Ȼ�ȡ���λ��
    private float mouseSensivity = 300f; //���������
    private float yRotation = 0;    //y����ת
    private float height = 1.8f;        //��Ҹ߶�
    public static bool isLocked;   //�Ƿ��������Ƿſ����
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
        RotationView();//�����ɫ�ƶ���ʱ����ת����ͷ���ֶ���
    }
    private void RotationView()
    {
        //һ���������������
        Cursor.lockState = isLocked ? CursorLockMode.Locked : CursorLockMode.None;
        float mouseX = Input.GetAxis("Mouse X") * mouseSensivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensivity * Time.deltaTime;
        yRotation -= mouseY;
        yRotation = Mathf.Clamp(yRotation, -60f, 60f);          //������ת�Ƕ���-60��60��֮��
        transform.localRotation = Quaternion.Euler(yRotation, 0, 0); //�����������ת
        playerTransform.Rotate(mouseX * Vector3.up);  //���������ת
    }
    
}
