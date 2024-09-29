using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JobInit : MonoBehaviour
{
    public static JobInit Instance;
    public List<bool> finishList;
    public List<string> JobNameList;
    public GameObject Content;
    public GameObject jobPrefab;
    public GameObject PickPanel;
    public GameObject jobPickPrefab;
    public List<Sprite> JobAvatarList;
    public EventsConfig AllJobEvent;
    public List<Event> JobEventsList;
    private void Awake()
    {
        if (Instance == null) 
        {
            Instance = this;
        }
        finishList.Clear();
        for (int i = 0; i < 10; i++)
        {
            finishList.Add(false);
            Instantiate(jobPrefab, Content.transform);
        }
        JobEventsList.Clear();
        JobEventsList = AllJobEvent.EventsList;

        JobNameList.Clear();
        JobNameList.Add("Programmer");
        JobNameList.Add("Accountant");
        JobNameList.Add("Hotel Waiter");
        JobNameList.Add("Customer Service");
        JobNameList.Add("Insurance Salesman");
        JobNameList.Add("Teacher");
        JobNameList.Add("Human Resource");
        JobNameList.Add("Project Leader");
        JobNameList.Add("Product Planner");
        JobNameList.Add("Head Chef");

        for (int i = 0; i < 10; i++)
        {
            Content.transform.GetChild(i).gameObject.GetComponent<JobHolder>().JobName.text = JobNameList[i];
            Content.transform.GetChild(i).gameObject.GetComponent<JobHolder>().JobAvatar.sprite = JobAvatarList[i];
            Content.transform.GetChild(i).gameObject.GetComponent<JobHolder>().JobOREvent = true;
            Content.transform.GetChild(i).gameObject.GetComponent<JobHolder>().jobEvent = JobEventsList[i];
        }
    }

    public void PickJob()
    {
        for (int i = 0; i < 10; i++)
        {
            if (EventController.Instance.IsHiredList[i])  
            {
                var temp = Instantiate(jobPickPrefab, PickPanel.transform);
                temp.GetComponent<JobHolder>().JobName.text = JobNameList[i];
                temp.GetComponent<JobHolder>().JobAvatar.sprite = JobAvatarList[i];
            }
        }
    }
}
