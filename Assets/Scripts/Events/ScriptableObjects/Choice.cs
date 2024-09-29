using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Choice_", menuName = "Choice/Choice")]

public class Choice : ScriptableObject
{
    [TextArea]
    public string description;
    public List<int> affectCountList;
    public Event eventCallUp;
    public int costMoney;

    public float percentage;

    public void RaiseEvent()
    {
        EventController.Instance.Tip.text = null;
        if (description== "End.....?")
        {
            MainController.Instance.StartCoroutine(MainController.Instance.BadEnd());
            return;
        }

        if (description == "Shop.") 
        {
            MainController.Instance.Shop.SetActive(true);
            EventController.Instance.ClearChoiceButtons();
            return;
        }

        if (eventCallUp == null)
        {
            if (EventController.Instance.CurrentEvent.isJobEvent)
            {
                float temp = Random.Range(0, 1f);
                Debug.Log(temp);
                if (temp <= EventController.Instance.possibility) 
                {
                    EventController.Instance.IsHiredList[EventController.Instance.tempID] = true;
                }
                else
                {
                    EventController.Instance.IsHiredList[EventController.Instance.tempID] = false;
                }
            }
            EventController.Instance.ClearChoiceButtons();
            EventController.Instance.EventCheck();
            EventController.Instance.isAllShown = false;
            EventController.Instance.CurrentEvent = null;
            return;
        }

        
        if (EventController.Instance.CurrentEvent.isJobEvent)
        {
            EventController.Instance.possibility += percentage;
        }
        else
        {
            for (int i = 0; i < affectCountList.Count; i++)
            {
                PersonaController.Instance.personaAmountList[i] += affectCountList[i];
            }
            PersonaController.Instance.ChangeAmount();
            CurrencyController.Instance.CostMoney(costMoney);
            MainController.Instance.AmountChanged(affectCountList, costMoney);
        }
        EventController.Instance.isAllShown = false;
        EventController.Instance.StartCoroutine(EventController.Instance.ShowText(eventCallUp));
        EventController.Instance.ClearChoiceButtons();

    }
}
