using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ContextButton : MonoBehaviour {

    public GameObject targetPanel;
    public ScrollRect targetImage;
    public RectTransform content;

    public void OnButtonClick()
    {
        if (targetImage.content != null)
            targetImage.content.gameObject.SetActive(false);
        targetImage.content = content;
        content.gameObject.SetActive(true);

        targetImage.verticalNormalizedPosition = 1;
        targetPanel.SetActive(true);
    }

    void OnDisable()
    {
        targetPanel.SetActive(false);
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
    }
}
