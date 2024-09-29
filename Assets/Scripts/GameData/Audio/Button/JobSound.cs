using UnityEngine;
using UnityEngine.UI;

public class JobSound: MonoBehaviour
{
    public Button button;  // ����Ҫ�����İ�ť
    public AudioSource audioSource;  // ������Ч��AudioSource
    public AudioClip clickSound;  // ���ʱ���ŵ���Ч
    public AudioClip buttonClickSound; // ��ť�����Ч
    public GameObject audioPlayerPrefab; // ���ڲ�����Ч��Ԥ����

    void Start()
    {
        // ȷ����ť����¼�����Ч���ź�����
        button.onClick.RemoveAllListeners();  // �Ƴ����оɵļ���������ֹ�ظ���
        button.onClick.AddListener(OnButtonClick);  // Ϊ��ť����¼��󶨲�����Ч�ĺ���
    }

    // ���Ű�ť�����Ч�ĺ���
    public void OnButtonClick()
    {
        // ����һ���µġ���������Ч����������
        GameObject audioPlayer = Instantiate(audioPlayerPrefab);

        // ��ȡ��Ч�������е� AudioSource ���
        AudioSource newAudioSource = audioPlayer.GetComponent<AudioSource>();

        if (newAudioSource != null && buttonClickSound != null)
        {
            // ������Ч������
            newAudioSource.clip = buttonClickSound;
            newAudioSource.Play();
        }


    }

    // �ڻش���һ��������������ð�ť�������°󶨵���¼�
    public void ResetButton()
    {
        button.interactable = true;  // �������ð�ť�Ľ���
        button.onClick.RemoveAllListeners();  // ȷ�������ظ���
        button.onClick.AddListener(OnButtonClick);  // ���°󶨲�����Ч���¼�
    }

    // ����Ҫ���µ���һ������ʱ���ô˺���
    public void OnNextQuestion()
    {
        ResetButton();  // ���ð�ť״̬��ȷ����Ч������������
    }
}

