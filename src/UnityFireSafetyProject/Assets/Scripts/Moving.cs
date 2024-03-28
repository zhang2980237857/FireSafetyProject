using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    public float moveSpeed = 15f; // 移动速度  

    private Vector3 movement; // 用于存储摄像机的移动方向  

    void Update()
    {
        // 获取用户的输入  
        movement.x = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        movement.z = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        // 应用移动  
        transform.Translate(movement);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");
        //if (Input.GetMouseButton(0))
            transform.Rotate(-y, x, 0);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
    }
}
