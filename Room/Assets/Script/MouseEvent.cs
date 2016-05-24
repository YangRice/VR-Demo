using UnityEngine;
using UnityEngine.Events;
using System.Collections;

[RequireComponent(typeof(MeshRenderer))]

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


    MeshRenderer mesh;
    bool isHover = false;
    
    //void OnMouseEnter()
    //{
    //    onMouseEnter.Invoke();
    //}

    //void OnMouseExit()
    //{
    //    onMouseExit.Invoke();
    //}

    // Use this for initialization
    void Start()
    {
        mesh = gameObject.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray;
        RaycastHit hit;
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit) && hit.collider == gameObject.GetComponent<Collider>())
        {
            if (!isHover)
                onMouseEnter.Invoke();
            isHover = true;
            
        }
        else
        {
            if (isHover)
                onMouseExit.Invoke();
            isHover = false;
        }
    }
}
