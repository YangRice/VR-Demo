using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]

public class ChangeTextColor : MonoBehaviour {

    Text text;
    Color origin;
    public Color color;

    public void Change()
    {
        text.color = color;
    }

    public void Revert()
    {
        text.color = origin;
    }

    // Use this for initialization
    void Start () {
        text = gameObject.GetComponent<Text>();
        origin = text.color;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
