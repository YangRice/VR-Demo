using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(MeshRenderer))]

public class PlayMovie : MonoBehaviour
{
    public MovieTexture movieTexture;
    public Canvas canvas;
    int Mask = 0;

    public void Play()
    {
        movieTexture.Play();
        gameObject.GetComponent<MeshRenderer>().enabled = true;
    }

    public void Stop()
    {
        movieTexture.Stop();
        gameObject.GetComponent<MeshRenderer>().enabled = false;
    }

    // Use this for initialization
    void Start()
    {
        GetComponent<Renderer>().material.mainTexture = movieTexture as MovieTexture;
        Mask = Camera.main.cullingMask;
    }

    void OnMouseDown()
    {
        //movieTexture.Stop();
    }

    void Update()
    {
    //    if (movieTexture.isPlaying)
    //        Camera.main.cullingMask = (1 << LayerMask.NameToLayer("Video"));
    //    else
    //        Camera.main.cullingMask = Mask;

        if (canvas)
            canvas.gameObject.SetActive(!movieTexture.isPlaying);
        gameObject.GetComponent<MeshRenderer>().enabled = movieTexture.isPlaying;
    }
}
