using UnityEngine;
using System.Collections;

public class explodeAinmate : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Animation animation = this.GetComponent<Animation>();
        animation.wrapMode = WrapMode.Once;
        
    }
	
	// Update is called once per frame
	void Update () {
        
        //GetComponent<Animation>().Stop();

    }
	public string aniName;
    public void explode()
    {
        Animation animation = this.GetComponent<Animation>();
		animation[aniName].speed = 1;
		animation[aniName].time = 0;
		animation.Play(aniName);
    }

    public void unexplode()
    {
        Animation animation = this.GetComponent<Animation>();
		animation[aniName].speed = -1;
		animation[aniName].time = animation[aniName].length;
		animation.Play(aniName);
    }
}
