using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EventConfig_", menuName = "Event/EventConfig")]

public class EventsConfig : ScriptableObject
{
    public List<Event> EventsList;
}
