using UnityEngine;
using UnityEngine.Events;
using System.Collections;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshCollider))]

public class MouseEvent : MonoBehaviour
{


    [SerializeField]
    public MeshMouseEnterEvent onMouseEnter;
    [System.Serializable]
    public class MeshMouseEnterEvent : UnityEvent { }
    [SerializeField]
    public MeshMouseExitEvent onMouseExit;
    [System.Serializable]
    public class MeshMouseExitEvent : UnityEvent { }

    public void EnableMouseEvent()
    {
        enabled = true;
    }

    public void DisableMouseEvent()
    {
        enabled = false;
    }

    void OnMouseEnter()
    {
        if (enabled)
        {
            onMouseEnter.Invoke();
        }
    }

    void OnMouseExit()
    {
        if (enabled)
        {
            onMouseExit.Invoke();
        }
    }

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}
