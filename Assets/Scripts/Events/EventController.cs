using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventController : MonoBehaviour
{
    public static EventController Instance;


    public GameObject TexturePrefab;
    public GameObject TexturePanel;
    public GameObject ShowTextPanel;
    public TextAsset test;
    public GameObject ChoicePanel;
    public Button[] ChoiceButtons;
    int testIndex = 0;
    int index = -1;
    bool isTextFinished = false;
    bool isReturnPressed;
    public bool isAllShown = false;
    public Event CurrentEvent;
    public float duration = 0.1f;

    public int Time = 0;

    public float possibility = 0.5f;
    public List<bool> IsHiredList;
    public int tempID;

    public Text Tip;
    public Text WrongTip;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        ChoiceButtons = ChoicePanel.GetComponentsInChildren<Button>();
        index = 0;
        //StartCoroutine(ShowText(CurrentEvent));
        IsHiredList.Clear();
        for (int i = 0; i < 10; i++)
        {
            IsHiredList.Add(false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Return))
        {
            isReturnPressed = true;
        }
    }

    private void FixedUpdate()
    {
        if (isReturnPressed)
        {
            ShowAllText(CurrentEvent);
        }
    }

    public IEnumerator ShowText(Event currentEvent)
    {
        isTextFinished = false;
        CurrentEvent = currentEvent;
        Tip.text = "Press Return to continue...";
        /*if (PanelController.Instance != null) 
        {
            PanelController.Instance.OpenCallender();
        }*/

        if (currentEvent.isInitialEvent && index == 0 && currentEvent.isJobEvent) 
        {
            possibility = currentEvent.possibility;
            tempID = currentEvent.jobID;
        }

        if (currentEvent.isInitialEvent && index == 0) 
        {
            Time += currentEvent.timeCost;
        }
        TexturePanel = Instantiate(TexturePrefab, ShowTextPanel.transform);
        TexturePanel.GetComponent<Text>().text = null;
        duration = 0.1f;
        for (int i = 0; i < currentEvent.eventTextList[index].text.Length; i++) 
        {
            TexturePanel.GetComponent<Text>().text += currentEvent.eventTextList[index].text[i];
            yield return new WaitForSeconds(duration);
        }
        isTextFinished = true;
        index++;
        
        if (index == currentEvent.eventTextList.Count) 
        {
            isAllShown = true;
            Tip.text = "Make your choice...";
            ShowChoices(currentEvent.eventChoices);
        }

    }

    public void ShowChoices(ChoiceConfig choiceConfig)
    {
        index = 0;
        foreach(var Btn in ChoiceButtons)
        {
            Btn.GetComponentInChildren<Text>().text = null;
            Btn.interactable = true;
        }
        for (int i = 0; i < CurrentEvent.eventChoices.choicesList.Count; i++) 
        {
            ChoiceButtons[i].GetComponentInChildren<Text>().text = CurrentEvent.eventChoices.choicesList[i].description;
            ChoiceButtons[i].onClick.AddListener(CurrentEvent.eventChoices.choicesList[i].RaiseEvent);
            if (CurrentEvent.eventChoices.choicesList[i].costMoney > CurrencyController.Instance.Money)
            {
                ChoiceButtons[i].interactable = false;
            }
        }
    }

    public void ClearChoiceButtons()
    {
        foreach (var Btn in ChoiceButtons)
        {
            Btn.onClick.RemoveAllListeners();
            Btn.GetComponentInChildren<Text>().text = "-";
        }
    }

    public void ShowAllText(Event currentEvent)
    {
        isReturnPressed = false;
        if (currentEvent != null) 
        {
            if (!isTextFinished)
            {
                duration = 0f;
            }
            else if (!isAllShown)
            {
                StartCoroutine(ShowText(currentEvent));
            }
        }

        /*if (isTextFinished && !isAllShown)
        {
            StartCoroutine(ShowText(currentEvent));
        }
        else if (isTextFinished && isAllShown)
        {
            return;
        }
        else if (!isTextFinished) 
        {
            StopAllCoroutines();
            if (TexturePanel != null)
            {
                TexturePanel.GetComponent<Text>().text = null;
                TexturePanel.GetComponent<Text>().text = currentEvent.eventTextList[index].text;
            }

            isTextFinished = true;
            index++;

            if (index == currentEvent.eventTextList.Count)
            {
                ShowChoices(currentEvent.eventChoices);
            }
        }*/
    }

    public void EventCheck()
    {
        StartCoroutine(MainController.Instance.TimeChange(Time));
    }

    public void CleanAllText()
    {
        if (ShowTextPanel.transform.childCount>0)
        {
            for (int i = 0; i < ShowTextPanel.transform.childCount; i++)
            {
                Destroy(ShowTextPanel.transform.GetChild(i).gameObject);
            }
        }
    }

    [ContextMenu("Test")]
    public void Test()
    {
        isTextFinished = true;
        if (isTextFinished)
        {
            StartCoroutine(TestShowText());
        }
    }
    IEnumerator TestShowText()
    {
        isTextFinished = false;
        TexturePanel = Instantiate(TexturePrefab, ShowTextPanel.transform);
        var textInLines = test.text.Split('\n');
        string temp = textInLines[testIndex];
        TexturePanel.GetComponent<Text>().text = null;
        for (int i = 0; i < temp.Length; i++)
        {
            TexturePanel.GetComponent<Text>().text += temp[i];
            yield return new WaitForSeconds(0.1f);
        }
        isTextFinished = true;
        testIndex++;
    }
}
