using QFramework;
using QFramework.UnityFireSafetyProject;
using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Insiantiateobj : MonoBehaviour
{
    //获取物体，因物体较少，所以采用直接挂载的方式获取
    public Transform Model;//呈现的模型，所放的位置
    public Transform ShowPanel;//展示界面
    public Transform Exit;//退出按钮
    public GameObject Introduction;//用于放置介绍文本
    string[] namesplit;//用于存放每一个文字的数组
    Button exitBtn= null;
    int Number = 1;
    int index = 0;
    public GameObject obj1;
    //public Animator animatorCube;
    void Start()
    {
        exitBtn = Exit.gameObject.GetComponent<Button>();
        exitBtn.onClick.AddListener(OnDestroyShowPanel);
        StartCoroutine( TypeText());
    }
    void Update()
    {
        float time = 0;
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
        obj1.AddComponent<Animator>();
        //获取动画控制器
        obj1.GetComponent<Animator>().runtimeAnimatorController = GameApp.Instance.mResLoader.LoadSync<RuntimeAnimatorController>("Cube");
        namesplit = SplitTextByLength(obj1.name,1);
        
    }
    private void OnDestroyShowPanel()
    {
        MianPlayer.showState.Value = true;
        ShowPanel.gameObject.DestroySelf();
        MouseContoller.isLocked = true;
    }
    private void OnDestroy()
    {
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
    public void Stoprotate()
    {
        obj1.GetComponent<Animator>().SetTrigger("Stop");
    }
    public void Startrotate()
    {
        obj1.GetComponent<Animator>().SetTrigger("Start");
    }
}

