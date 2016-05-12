using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]

public class PlayMovie : MonoBehaviour
{
    public MovieTexture movieTexture;
    public Canvas canvas;
    int Mask = 0;

    public void OnPlay()
    {
        movieTexture.Play();
    }

    // Use this for initialization
    void Start()
    {
        GetComponent<Renderer>().material.mainTexture = movieTexture as MovieTexture;
        Mask = Camera.main.cullingMask;
    }

    void OnMouseDown()
    {
        movieTexture.Stop();
    }

    void Update()
    {
        if (movieTexture.isPlaying)
            Camera.main.cullingMask = (1 << LayerMask.NameToLayer("Video"));
        else
            Camera.main.cullingMask = Mask;

        canvas.gameObject.SetActive(!movieTexture.isPlaying);
        GetComponent<Renderer>().enabled = movieTexture.isPlaying;
    }
}
