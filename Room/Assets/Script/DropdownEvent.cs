using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class DropdownEvent : MonoBehaviour {

    [SerializeField]
    public DropdownItemEvent[] itemEvents;

    [SerializeField]
    public DropdownItemEvent onItemClick;

    [System.Serializable]
    public class DropdownItemEvent : UnityEvent<bool> { }
    
    public void OnValueChanged(int value)
    {
        onItemClick.Invoke(value > 0);

        for (int i = 0; i < itemEvents.Length; i++)
            itemEvents[i].Invoke(i == value);
    }
}
