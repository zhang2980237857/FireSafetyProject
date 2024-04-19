using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CameraTarget : MonoBehaviour
{

    public Transform target; //���Ҫ�����Ŀ������
    public Vector3 pivotOffset = Vector3.zero; // ���Χ��Ŀ���ƫ����
    public float distance = 0f; // �����Ŀ��ľ���
    private float minDistance = 1.4f; // �����Ŀ�����С����
    private float maxDistance = 15f; // �����Ŀ���������
    public float zoomSpeed = 100f; // �����ٶ�
    public float xSpeed = 250.0f; // ���ˮƽ��ת�ٶ�
    public float ySpeed = 250.0f; // �����ֱ��ת�ٶ�
    public bool allowYTilt = true; // �Ƿ����������ֱ��ת
    public float yMinLimit = -360f; // ���������ֱ��ת����С�Ƕ�
    public float yMaxLimit = 360f; // ���������ֱ��ת�����Ƕ�
    private float currentX = 0.0f; // ��ǰ���ˮƽ��ת�Ƕ�
    private float currentY = 0.0f; // ��ǰ�����ֱ��ת�Ƕ�
    private float targetX = 0f; // Ŀ��ˮƽ��ת�Ƕ�
    private float targetY = 0f; // Ŀ�괹ֱ��ת�Ƕ�
    public float targetDistance = 0f; // �����Ŀ��ľ���
    public float weightCenterHeight = 100.0f;//���ڵ�����������ģ���ֹ��������Ĺ��ߣ��޷�չʾ��������
    Insiantiateobj InsiantiateobjScript;
    void Start()
    {
        //��ʼ������
        var angles = transform.eulerAngles;
        targetX = currentX = angles.x;
        targetY = currentY = Mathf.Clamp(angles.y - 20, yMinLimit, yMaxLimit);
        targetY = currentY = angles.y - 20;
        targetDistance = 3.5f;
        InsiantiateobjScript = GetComponent<Insiantiateobj>();
    }
    void Update()
    {
        
    }
    private void LateUpdate()
    {
        if (!target) return;
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        targetDistance -= scroll * zoomSpeed;
        targetDistance = Mathf.Clamp(targetDistance, minDistance, maxDistance);
        //�������������½Ƕ�
        if (Input.GetMouseButton(1) || (Input.GetMouseButton(0) && (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))))//�������ֺ������Լ�������
        {

            InsiantiateobjScript.isStart = false;
            
            targetX += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
            if (allowYTilt)
            {
                targetY -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
            }
        }
        if (Input.GetMouseButtonUp(1))
        {
            InsiantiateobjScript.isStart = true;
        }
        //ת�������
        currentX = Mathf.Lerp(currentX,targetX,xSpeed*Time.deltaTime);
        currentY = Mathf.Lerp(currentY, targetY, ySpeed * Time.deltaTime);
        targetY  = Mathf.Clamp(targetY, yMinLimit, yMaxLimit);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0); 
        distance = targetDistance;
        distance = Mathf.Clamp(distance, minDistance,maxDistance);
        Vector3 position = rotation * new Vector3(0.0f, weightCenterHeight-0.5f, -distance) + target.position + pivotOffset;
        transform.rotation = rotation;
        transform.position = position;
        Debug.Log("��ǰ����"+distance);
    }

}


