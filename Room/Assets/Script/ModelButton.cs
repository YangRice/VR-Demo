using UnityEngine;
using UnityEngine.UI;

public class ModelButton : MonoBehaviour {

    public GameObject[] models;

    public void OnDropdownValueChanged(Dropdown target)
    {
        for (int i = 0; i < models.Length; i++)
        {
            models[i].SetActive(target.value == i);
        }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}
}
