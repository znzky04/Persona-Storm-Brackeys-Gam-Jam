using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.UI;

public class GoodsController : MonoBehaviour
{
    public static GoodsController Instance;
    public GameObject[] Goods;
    public GameObject Shop;
    public bool haveBought = false;
    public int GoodID;
    public List<int> GoodAffectList;
    public int costMoney;
    public Button buyButton;

    private void Awake()
    {
        if (Instance == null) 
        {
            Instance = this;
        }
        ResetAffect();
    }

    public void EndButton()
    {
        haveBought = false;
        MainController.Instance.DayEnd();
        Shop.SetActive(false);
    }

    public void BuyButton()
    {
        Goods[GoodID].GetComponent<GoodButton>().isSoldOut = true;
        Goods[GoodID].GetComponent<GoodButton>().SoldOutText.enabled = true;
        Goods[GoodID].GetComponent<GoodButton>().GetComponent<Button>().interactable = false;
        ResetAffect();
        switch (GoodID)
        {
            case 0:
                GoodAffectList[0] = 10;
                GoodAffectList[2] = -10;
                break;
            case 1:
                GoodAffectList[PersonaController.Instance.PersonaList[0].GetComponent<Persona>().id] = 5;
                break;
            case 2:
                GoodAffectList[PersonaController.Instance.PersonaList[0].GetComponent<Persona>().id] = -5;
                break;
            case 3:
                GoodAffectList[3] = -5;
                GoodAffectList[4] = 6;
                break;
            case 4:
                GoodAffectList[2] = 5;
                GoodAffectList[3] = 5;
                GoodAffectList[1] = 5;
                break;
            case 5:
                GoodAffectList[0] = 7;
                GoodAffectList[1] = 7;
                GoodAffectList[2] = 7;
                GoodAffectList[3] = 7;
                GoodAffectList[4] = 7;
                break;
        }
        costMoney = Goods[GoodID].GetComponent<GoodButton>().costMoney;
        CurrencyController.Instance.CostMoney(costMoney);
        for (int i = 0; i < GoodAffectList.Count; i++)
        {
            PersonaController.Instance.personaAmountList[i] += GoodAffectList[i];
        }
        PersonaController.Instance.ChangeAmount();
        MainController.Instance.AmountChanged(GoodAffectList, costMoney);
        haveBought = true;
        buyButton.interactable = false;
    }

    public void ResetAffect()
    {
        GoodAffectList.Clear();
        for (int i = 0; i < 5; i++)
        {
            GoodAffectList.Add(0);
        }
    }
}
