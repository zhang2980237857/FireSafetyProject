using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    public float moveSpeed = 15f; // �ƶ��ٶ�  

    private Vector3 movement; // ���ڴ洢��������ƶ�����  

    void Update()
    {
        // ��ȡ�û�������  
        movement.x = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        movement.z = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        // Ӧ���ƶ�  
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
