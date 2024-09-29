using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    public Button button;  // ����Ҫ�����İ�ť
    public AudioSource audioSource;  // ������Ч��AudioSource
    public AudioClip clickSound;  // ���ʱ���ŵ���Ч


    void Start()
    {
        // ȷ����ť����¼�����Ч���ź�����
        button.onClick.RemoveAllListeners();  // �Ƴ����оɵļ���������ֹ�ظ���
        button.onClick.AddListener(PlaySound);  // Ϊ��ť����¼�����Ч���ź���
    }

    // ���Ű�ť�����Ч�ĺ���
    public void PlaySound()
    {
        // �����Ч�Ѿ����ţ�ֹͣ�����²���
        audioSource.Stop();  // ֹ֮ͣǰ���ŵ���Ч
        audioSource.clip = clickSound;  // ���õ����Ч
        audioSource.Play();  // ������Ч
    }


    // �ڻش���һ��������������ð�ť�������°󶨵���¼�
    public void ResetButton()
    {
        button.interactable = true;  // �������ð�ť�Ľ���
        button.onClick.RemoveAllListeners();  // ȷ�������ظ���
        button.onClick.AddListener(PlaySound);  // ���°󶨲�����Ч���¼�
    }

    // ����Ҫ���µ���һ������ʱ���ô˺���
    public void OnNextQuestion()
    {
        ResetButton();  // ���ð�ť״̬��ȷ����Ч������������
    }
}
