using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ChoiceConfig_", menuName = "Choice/ChoiceConfig")]

public class ChoiceConfig : ScriptableObject
{
    public List<Choice> choicesList;
}
