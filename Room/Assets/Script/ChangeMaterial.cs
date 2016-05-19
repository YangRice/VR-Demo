using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshRenderer))]

public class ChangeMaterial : MonoBehaviour {
    
    MeshRenderer mesh;
    public Material mat;

    public void Change()
    {
        Material[] newMat = new Material[mesh.materials.Length + 1];
        for (int i = 0; i < mesh.materials.Length; i++)
            newMat[i] = mesh.materials[i];
        newMat[mesh.materials.Length] = mat;

        mesh.materials = newMat;
    }

    public void Revert()
    {
        Material[] newMat = new Material[mesh.materials.Length - 1];
        for (int i = 0; i < newMat.Length; i++)
            newMat[i] = mesh.materials[i];

        mesh.materials = newMat;
    }

    // Use this for initialization
    void Start ()
    {
        mesh = gameObject.GetComponent<MeshRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
	}
}
