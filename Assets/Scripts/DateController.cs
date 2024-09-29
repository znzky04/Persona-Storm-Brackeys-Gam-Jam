using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DateController : MonoBehaviour
{
    public List<GameObject> Days;
    public static DateController Instance;
    public Text[] changesText;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        Days.Clear();
        for (int i = 0; i < this.transform.childCount; i++)
        {
            Days.Add(this.transform.GetChild(i).gameObject);
        }

        for (int i = 0; i < 4; i++)
        {
            Days[i].GetComponentInChildren<Text>().text = null;
            Days[i].GetComponentsInChildren<Image>()[1].enabled = false;
        }

        for (int i = 4; i < 35; i++)
        {
            Days[i].GetComponentInChildren<Text>().text = (i - 3).ToString();
        }
        for (int i = 4; i < 14; i++)
        {
            Days[i].GetComponentsInChildren<Image>()[1].enabled = true;
        }
    }
}
