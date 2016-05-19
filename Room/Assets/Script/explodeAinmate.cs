using UnityEngine;
using System.Collections;

public class explodeAinmate : MonoBehaviour {
    
    [SerializeField]
    public GameObject[] hideObjects;

    new Animation animation = null;
    bool isExploding = false;

    // Use this for initialization
    void Start () {
        animation = gameObject.GetComponent<Animation>();
        animation.wrapMode = WrapMode.Once;
    }
	
	// Update is called once per frame
	void Update () {
        var ani = animation[aniName];
        foreach (var hideObj in hideObjects)
        {
            hideObj.SetActive(ani.time == 0 && !isExploding);
        }
    }
	public string aniName;
    public void explode()
    {
		animation[aniName].speed = 1;
		animation[aniName].time = 0;
		animation.Play(aniName);
        isExploding = true;
    }

    public void unexplode()
    {
		animation[aniName].speed = -1;
		animation[aniName].time = animation[aniName].length;
		animation.Play(aniName);
        isExploding = false;
    }
}
