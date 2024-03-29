using QFramework;
using QFramework.UnityFireSafetyProject;
using System;
using System.Collections;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.UI;


public class Insiantiateobj : MonoBehaviour
{
    //获取物体，因物体较少，所以采用直接挂载的方式获取
    public Transform Model;//呈现的模型，所放的位置
    public Transform ShowPanel;//展示界面
    public GameObject Introduction;//用于放置介绍文本
    string[] namesplit;//用于存放每一个文字的数组
    int index = 0;
    public GameObject obj1;
    public bool isStart = true;
    public float rotationAmount = 30;//旋转程度
    [Header("下面的是按钮")]
    [Tooltip("拖取一个退出按钮")]public Button exitBtn = null;
    [Tooltip("拖取一个停止按钮")] public Button StopRatationBtn = null;   //停止旋转按钮
    //public Animator animatorCube;
    void Start()
    {
        exitBtn.onClick.AddListener(OnDestroyShowPanel);
        StopRatationBtn.onClick.AddListener(() =>
        {
            isStart = false;
        });
        StartCoroutine( TypeText());
    }
    void Update()
    {
        MouseContoller.isLocked = false;//需优化
        ToggleButtonsInteractability(MianPlayer.contrll.Value);
    }
    public void ints(GameObject obj)
    {
        //将获取的脚本进行实例化
        obj1 = Instantiate(obj,Model);
        obj1.GetComponent<Rigidbody>().useGravity = false;
        Vector3 pos = new Vector3(0, 0, 0);
        obj1.transform.localPosition = pos;
        namesplit = SplitTextByLength(obj1.name,1);
        
    }
    void LateUpdate()
    {
        if (isStart)
        {
            obj1.transform.Rotate(Vector3.right, rotationAmount * Time.deltaTime);
            obj1.transform.Rotate(Vector3.up, rotationAmount * Time.deltaTime);
        }
        
    }
    private void OnDestroyShowPanel()
    {
        MianPlayer.showState.Value = true;
        ShowPanel.gameObject.DestroySelf();
        MouseContoller.isLocked = true;
    }
    private void OnDestroy()
    {
        if (!exitBtn)
        {
            return;
        }
        //及时移除防止内存泄露
        exitBtn?.onClick?.RemoveAllListeners();
    }
    void ToggleButtonsInteractability(bool value)
    {
        //将按钮失活，防止在打开界面的同时点击到该界面
        Button[] buttons = ShowPanel.GetComponentsInChildren<Button>();
        foreach (Button button in buttons)
        {
            button.interactable = !value;
        }
    }
    /// <summary>
    /// 按照长度切分文本，为了实现文字的逐步显现
    /// </summary>
    /// <param name="text">文本</param>
    /// <param name="length">决定每个长度</param>
    /// <returns></returns>
    static string[] SplitTextByLength(string text, int length)
    {
        int numOfParts = (int)Math.Ceiling((double)text.Length-7 / length);//求出可以分成几部分，向上取值，保证不溢出
        string[] parts = new string[numOfParts];

        for (int i = 0; i < numOfParts; i++)
        {
            int startIndex = i * length;
            int remainingLength = Math.Min(length, text.Length - startIndex);//防止所取的长度超出
            parts[i] = text.Substring(startIndex, remainingLength);//取子串
        }
        return parts;
    }
    /// <summary>
    /// 更新文字显示
    /// </summary>
    /// <returns></returns>
    IEnumerator TypeText()
    {
        
        while (index < namesplit.Length)
        {
            Introduction.GetComponent<Text>().text += namesplit[index]+"\n";
            index++;
            yield return new WaitForSeconds(0.2f);//间隔时间
        }
    }
}

