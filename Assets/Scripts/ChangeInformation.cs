using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeInformation : MonoBehaviour
{
    public List<int> changes;
    private void Awake()
    {
        changes.Clear();
        for (int i = 0; i < 6; i++)
        {
            changes.Add(0);
        }
    }

    public void ShowChanges()
    {
        for (int i = 0; i < changes.Count - 1; i++) 
        {
            if (changes[i] > 0) 
            {
                DateController.Instance.changesText[i].text = "+" + changes[i].ToString();
            }
            else
            {
                DateController.Instance.changesText[i].text = changes[i].ToString();
            }
        }
        if (changes[5] > 0) 
        {
            DateController.Instance.changesText[5].text = "-" + changes[5].ToString();
        }
        else
        {
            DateController.Instance.changesText[5].text = "0";
        }
        
    }
}
