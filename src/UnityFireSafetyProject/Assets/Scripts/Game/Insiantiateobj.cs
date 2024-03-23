using QFramework;
using QFramework.UnityFireSafetyProject;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Insiantiateobj : MonoBehaviour
{
    //��ȡ���壬��������٣����Բ���ֱ�ӹ��صķ�ʽ��ȡ
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
        MouseContoller.isLocked = false;//���Ż�
        ToggleButtonsInteractability(MianPlayer.contrll.Value);
    }
    public void ints(GameObject obj)
    {
        //����ȡ�Ľű�����ʵ����
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
        //��ʱ�Ƴ���ֹ�ڴ�й¶
        exitBtn?.onClick?.RemoveAllListeners();
    }
    void ToggleButtonsInteractability(bool value)
    {
        Button[] buttons = ShowPanel.GetComponentsInChildren<Button>();

        foreach (Button button in buttons)
        {
            button.interactable = !value;
        }
    }
}
