using QFramework;
using QFramework.UnityFireSafetyProject;
using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Insiantiateobj : MonoBehaviour
{
    //��ȡ���壬��������٣����Բ���ֱ�ӹ��صķ�ʽ��ȡ
    public Transform Model;//���ֵ�ģ�ͣ����ŵ�λ��
    public Transform ShowPanel;//չʾ����
    public Transform Exit;//�˳���ť
    public TextMeshProUGUI Introduction;//���ڷ��ý����ı�
    string[] namesplit;//���ڴ��ÿһ�����ֵ�����
    Button exitBtn= null;
    int Number = 1;
    int index = 0;
    void Start()
    {
        exitBtn = Exit.gameObject.GetComponent<Button>();
        exitBtn.onClick.AddListener(OnDestroyShowPanel);
        StartCoroutine( TypeText());
    }
    void Update()
    {
        float time = 0;
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
        //Introduction.text = obj1.name;
        namesplit = SplitTextByLength(obj1.name,1);
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
    /// <summary>
    /// ���ճ����з��ı�
    /// </summary>
    /// <param name="text">�ı�</param>
    /// <param name="length">����ÿ������</param>
    /// <returns></returns>
    static string[] SplitTextByLength(string text, int length)
    {
        int numOfParts = (int)Math.Ceiling((double)text.Length-7 / length);//������Էֳɼ����֣�����ȡֵ����֤�����
        string[] parts = new string[numOfParts];

        for (int i = 0; i < numOfParts; i++)
        {
            int startIndex = i * length;
            int remainingLength = Math.Min(length, text.Length - startIndex);//��ֹ��ȡ�ĳ��ȳ���
            parts[i] = text.Substring(startIndex, remainingLength);//ȡ�Ӵ�
        }
        return parts;
    }
    /// <summary>
    /// ����������ʾ
    /// </summary>
    /// <returns></returns>
    IEnumerator TypeText()
    {
        
        while (index < namesplit.Length)
        {
            Introduction.text += namesplit[index];
            index++;
            yield return new WaitForSeconds(0.2f);//���ʱ��
        }
    }
}

