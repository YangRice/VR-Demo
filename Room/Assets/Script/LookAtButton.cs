using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[RequireComponent(typeof(Toggle))]

public class LookAtButton : MonoBehaviour
{

    public GameObject[] controls;
    public LineRenderer lineRenderer;

    bool isChecked = false;
    public GameObject cameraLookAt;

    [SerializeField]
    public MoveToCameraEvent moveToCamera;
    [SerializeField]
    public RevertCameraEvent revertCamera;
    [System.Serializable]
    public class MoveToCameraEvent : UnityEvent<GameObject> { }
    [System.Serializable]
    public class RevertCameraEvent : UnityEvent { }

    public void OnChecked(bool check)
    {
        if (check == isChecked)
            return; // avoiding extra move camera

        isChecked = check;
        if (check)
        {
            moveToCamera.Invoke(cameraLookAt);
        }
        else
        {
            revertCamera.Invoke();
        }
    }

    public void SetInactive(bool inactive)
    {
        gameObject.SetActive(!inactive);
    }

    public bool notInteractable
    {
        get
        {
            return !GetComponent<Toggle>().interactable;
        }
        set
        {
            GetComponent<Toggle>().interactable = !value;
        }
    }

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject obj in controls)
        {
            obj.SetActive(isChecked);
        }

        var image = gameObject.GetComponent<Image>();
        var p2d = transform.position;
        p2d.x -= image.rectTransform.rect.width / 2;

        if (lineRenderer != null)
        {
            var p = Camera.main.ScreenPointToRay(p2d).GetPoint(10);
            lineRenderer.SetPosition(0, p);
            lineRenderer.gameObject.SetActive(!isChecked);
        }

    }
}