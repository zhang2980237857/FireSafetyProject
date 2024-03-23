using QFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Insiantiateobj : MonoBehaviour
{
    //获取物体，因物体较少，所以采用直接挂载的方式获取
    public Transform Model;
    public Transform ShowPanel;
    public Transform Exit;
    Button exitBtn= null;
    int Number = 1;
    void Start()
    {
        exitBtn = Exit.gameObject.GetComponent<Button>();
        exitBtn.onClick.AddListener(OnDestroyShowPanel);
    }
    void Update()
    {
    }
    public void ints(GameObject obj)
    {
        //将获取的脚本进行实例化
        MouseContoller.isLocked = false;
        GameObject obj1 = Instantiate(obj,Model);
        obj1.GetComponent<Rigidbody>().useGravity = false;
        Vector3 pos = new Vector3(0, 0, 0);
        obj1.transform.localPosition = pos;
        Number += 1;
    }
    private void OnDestroyShowPanel()
    {
        ShowPanel.gameObject.DestroySelf();
        MouseContoller.isLocked = true;
    }
    private void OnDestroy()
    {
        //及时移除防止内存泄露
        exitBtn?.onClick?.RemoveAllListeners();
    }
}
