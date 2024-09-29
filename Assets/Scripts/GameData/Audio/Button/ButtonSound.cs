using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    public Button button;  // 你需要关联的按钮
    public AudioSource audioSource;  // 播放音效的AudioSource
    public AudioClip clickSound;  // 点击时播放的音效


    void Start()
    {
        // 确保按钮点击事件与音效播放函数绑定
        button.onClick.RemoveAllListeners();  // 移除所有旧的监听器，防止重复绑定
        button.onClick.AddListener(PlaySound);  // 为按钮点击事件绑定音效播放函数
    }

    // 播放按钮点击音效的函数
    public void PlaySound()
    {
        // 如果音效已经播放，停止并重新播放
        audioSource.Stop();  // 停止之前播放的音效
        audioSource.clip = clickSound;  // 设置点击音效
        audioSource.Play();  // 播放音效
    }


    // 在回答完一个问题后重新启用按钮，并重新绑定点击事件
    public void ResetButton()
    {
        button.interactable = true;  // 重新启用按钮的交互
        button.onClick.RemoveAllListeners();  // 确保不会重复绑定
        button.onClick.AddListener(PlaySound);  // 重新绑定播放音效的事件
    }

    // 当需要更新到下一个问题时调用此函数
    public void OnNextQuestion()
    {
        ResetButton();  // 重置按钮状态，确保音效可以正常播放
    }
}
