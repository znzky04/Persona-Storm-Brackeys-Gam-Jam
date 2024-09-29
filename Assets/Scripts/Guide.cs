using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guide : MonoBehaviour
{
    GameObject temp;
    public void OpenTODO()
    {
        PanelController.Instance.OpenEvent();
        temp = Instantiate(MainController.Instance.EventDialogPrefab, MainController.Instance.ChooseEventPanel.transform);
    }

    public void OpenCallender()
    {
        Destroy(temp.gameObject);
        PanelController.Instance.OpenCallender();
    }

    public void StartGame()
    {
        this.gameObject.SetActive(false);
        MainController.Instance.StartCoroutine(MainController.Instance.TimeChange(EventController.Instance.Time));
    }
}
