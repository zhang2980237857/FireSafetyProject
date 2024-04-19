using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CameraTarget : MonoBehaviour
{

    public Transform target; //相机要跟随的目标物体
    public Vector3 pivotOffset = Vector3.zero; // 相机围绕目标的偏移量
    public float distance = 0f; // 相机与目标的距离
    private float minDistance = 1.4f; // 相机与目标的最小距离
    private float maxDistance = 15f; // 相机与目标的最大距离
    public float zoomSpeed = 100f; // 缩放速度
    public float xSpeed = 250.0f; // 相机水平旋转速度
    public float ySpeed = 250.0f; // 相机垂直旋转速度
    public bool allowYTilt = true; // 是否允许相机垂直旋转
    public float yMinLimit = -360f; // 限制相机垂直旋转的最小角度
    public float yMaxLimit = 360f; // 限制相机垂直旋转的最大角度
    private float currentX = 0.0f; // 当前相机水平旋转角度
    private float currentY = 0.0f; // 当前相机垂直旋转角度
    private float targetX = 0f; // 目标水平旋转角度
    private float targetY = 0f; // 目标垂直旋转角度
    public float targetDistance = 0f; // 相机与目标的距离
    public float weightCenterHeight = 100.0f;//用于调整物体的中心，防止物体的中心过高，无法展示整个物体
    Insiantiateobj InsiantiateobjScript;
    void Start()
    {
        //初始化参数
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
        //根据鼠标操作更新角度
        if (Input.GetMouseButton(1) || (Input.GetMouseButton(0) && (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))))//操作部分后续可以继续更改
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
        //转换后更新
        currentX = Mathf.Lerp(currentX,targetX,xSpeed*Time.deltaTime);
        currentY = Mathf.Lerp(currentY, targetY, ySpeed * Time.deltaTime);
        targetY  = Mathf.Clamp(targetY, yMinLimit, yMaxLimit);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0); 
        distance = targetDistance;
        distance = Mathf.Clamp(distance, minDistance,maxDistance);
        Vector3 position = rotation * new Vector3(0.0f, weightCenterHeight-0.5f, -distance) + target.position + pivotOffset;
        transform.rotation = rotation;
        transform.position = position;
        Debug.Log("当前距离"+distance);
    }

}


