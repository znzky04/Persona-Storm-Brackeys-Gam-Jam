using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JobHolder : MonoBehaviour
{
    public Event jobEvent;
    public Text JobName;
    public Image JobAvatar;
    public Button AcceptButton;
    public bool JobOREvent;

    public void LoadEvent()
    {
        if (MainController.Instance.isJob)
        {
            if (!JobOREvent) 
            {
                EventController.Instance.WrongTip.text = "Please pick a job.";
            }
            else
            {
                EventController.Instance.CurrentEvent = jobEvent;
                EventController.Instance.StartCoroutine(EventController.Instance.ShowText(EventController.Instance.CurrentEvent));
                MainController.Instance.TipText.text = null;
                EventController.Instance.WrongTip.text = null;
                MainController.Instance.isEvent = false;
                MainController.Instance.isJob = false;
                Destroy(this.gameObject);
            }
        }

        if (MainController.Instance.isEvent)
        {
            if (JobOREvent)
            {
                EventController.Instance.WrongTip.text = "Please pick a Todo.";
            }
            else
            {
                EventController.Instance.CurrentEvent = jobEvent;
                MainController.Instance.GameEventsList.EventsList.Remove(jobEvent);
                EventController.Instance.StartCoroutine(EventController.Instance.ShowText(EventController.Instance.CurrentEvent));
                MainController.Instance.TipText.text = null;
                EventController.Instance.WrongTip.text = null;
                MainController.Instance.isEvent = false;
                MainController.Instance.isJob = false;
                if (MainController.Instance.ChooseEventPanel.transform.childCount > 0) 
                {
                    for (int i = 0; i < MainController.Instance.ChooseEventPanel.transform.childCount; i++)
                    {
                        Destroy(MainController.Instance.ChooseEventPanel.transform.GetChild(i).gameObject);
                    }
                }
            }
        }
    }

    public void Pick()
    {
        MainController.Instance.GoodPanel.SetActive(false);
        MainController.Instance.pickText.SetActive(false);
        MainController.Instance.letter.SetActive(true);
        string FinalName = "-";
        switch (JobName.text)
        {
            case ("Programmer"):
            case ("Accountant"):
                FinalName = "Cathy";
                break;
            case ("Hotel Waiter"):
            case ("Customer Service"):
                FinalName = "Barbara";
                break;
            case ("Insurance Salesman"):
            case ("Teacher"):
                FinalName = "Dorothy";
                break;
            case ("Human Resource"):
            case ("Project Leader"):
                FinalName = "Edith";
                break;
            case ("Product Planner"):
            case ("Head Chef"):
                FinalName = "Florence";
                break;
        }
        MainController.Instance.letter.GetComponentInChildren<Text>().text = "You wake up from bed as usual.\n\nYou’ve found a job that suits you and gained a group of like-minded friends.\n\nYou feel as though you’ve lost something, but those lost parts have shaped the life you have now.\n" + FinalName + " , you think that's yout name.\nThere’s nothing left to worry about. Now, you just want to live happily here.";
    }
}
