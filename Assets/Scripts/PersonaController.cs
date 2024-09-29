using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersonaController : MonoBehaviour
{
    public static PersonaController Instance;
    public Text description;
    public Sprite[] PersonaSprites;
    public List<int> personaAmountList;
    public List<GameObject> PersonaList;
    [TextArea]
    public List<string> desList;
    private void Awake()
    {
        if (Instance == null) 
        {
            Instance = this;
        }
        personaAmountList.Clear();

        for (int i = 0; i < 5; i++)
        {
            personaAmountList.Add(50);
        }
        desList.Clear();
        desList.Add("Cathy: Suffers from depression, showing a timid manner. Anxious, extremely sensitive.When facing challenges, she usually chooses to escape or rely on others.");
        desList.Add("Barbara: Full of confidence and more willing to socialize. Extroverted and lively. Has vanity but kind-hearted. Self-centered. Cares much about others' views.");
        desList.Add("Dorothy: Suffering from mania. Stubborn,conceited. Aggressive and reckless, strong control desire. Always hostile to the outside world and hard to trust others. Overreacts, resorts to violence.");
        desList.Add("Edith: Stop at nothing. Indifferent and almost heartless in rationality. Harsh and picky. Skilled at manipulating situations for own goals and takes pleasure in torturing others.");
        desList.Add("Florence: Utilitarian and realistic. Timid but good at self-protection. Obeys the stronger and looks down on the weaker. Relatively rational with less emotional fluctuation.");

        for (int i = 0; i < 5; i++)
        {
            //Debug.Log(i);
            PersonaList[i].GetComponent<Persona>().id = i;
            PersonaList[i].GetComponent<Persona>().blank.sprite = PersonaSprites[PersonaList[i].GetComponent<Persona>().id];
            PersonaList[i].GetComponent<Persona>().back.sprite = PersonaSprites[PersonaList[i].GetComponent<Persona>().id];
            PersonaList[i].GetComponent<Persona>().blank.fillAmount = personaAmountList[PersonaList[i].GetComponent<Persona>().id] / 100f;
        }
        ChangeAvatar();
    }

    public void ChangeAmount()
    {
        for (int i = 0; i < 5; i++)
        {
            PersonaList[i].GetComponent<Persona>().blank.fillAmount = Mathf.Max(0f, personaAmountList[PersonaList[i].GetComponent<Persona>().id] / 100f);
            //Debug.Log(personaAmountList[PersonaList[i].GetComponent<Persona>().id] / 100f);
        }
    }

    public void ChangeAvatar()
    {
        for (int i = 0; i < 5; i++)
        {
            PersonaList[i].GetComponent<Persona>().back.sprite = PersonaSprites[PersonaList[i].GetComponent<Persona>().id];
            PersonaList[i].GetComponent<Persona>().blank.sprite = PersonaSprites[PersonaList[i].GetComponent<Persona>().id];
        }

        ChangeDescription();
    }

    public void DailyChange()
    {
        for (int i = 0; i < 5; i++)
        {
            if (PersonaList[i].GetComponent<Persona>().id != 4) 
            {
                PersonaList[i].GetComponent<Persona>().id++;
            }
            else
            {
                PersonaList[i].GetComponent<Persona>().id = 0;
            }
        }
        ChangeAmount();
        ChangeAvatar();
    }

    public void ChangeDescription()
    {
        for (int i = 0; i < 5; i++)
        {
            if (i == 0)
            {
                PersonaList[i].GetComponent<Persona>().panel.GetComponentInChildren<Text>().text = "Current Persona\n\n" + desList[PersonaList[i].GetComponent<Persona>().id];
            }
            else
            {
                PersonaList[i].GetComponent<Persona>().panel.GetComponentInChildren<Text>().text = desList[PersonaList[i].GetComponent<Persona>().id];
            }
        }
    }
}
