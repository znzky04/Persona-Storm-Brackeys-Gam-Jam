using UnityEngine;

public class MusicManager : MonoBehaviour
{
    // ��̬ʵ��������ȷ��ֻ����һ�� MusicManager
    private static MusicManager instance;

    // ���ֲ�����
    public AudioSource audioSource;

    // ����������Ƶ����
    public AudioClip backgroundMusic;

    // Awake �����ڳ�������ʱ����
    void Awake()
    {
        // �����ǰû��ʵ����������Ϊ��ǰʵ���������ֳ�������
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // ȷ�������ڳ����л�ʱ��������
        }
        // ����Ѿ���ʵ�����ڣ��������´����Ķ��󣬷�ֹ�ظ�����
        else
        {
            Destroy(gameObject);  // ��ֹ���ʵ�����������ص�
        }
    }

    // ����Ϸ��ʼʱ����
    void Start()
    {
        if (audioSource != null)
        {
            PlayMusic();
        }
         // ���ű�������
    }

    // ���ű�������
    public void PlayMusic()
    {
        // ȷ���б�������Ƭ�δ���
        if (backgroundMusic != null)
        {
            audioSource.clip = backgroundMusic;  // ������Ƶ����
            audioSource.loop = true;  // ����Ϊѭ������
            audioSource.Play();  // ��ʼ����
        }
    }
}

