using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoodButton : MonoBehaviour
{
    public bool isSoldOut = false;
    public string GoodName;
    public Text SoldOutText;
    [TextArea]
    public string description;
    public int costMoney;
    public Image ChosenGood;
    public Text GoodDescription;
    public int ID;

    public Button buyButton;

    public void ChooseGood()
    {
        ChosenGood.sprite = this.GetComponent<Image>().sprite;
        GoodDescription.text = description;
        if (costMoney <= CurrencyController.Instance.Money && !GoodsController.Instance.haveBought) 
        {
            buyButton.interactable = true;
            GoodsController.Instance.GoodID = ID;
        }
    }

}
