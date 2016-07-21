using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]

public class MoveControl : MonoBehaviour
{

    public Vector3 lowerBound = Vector3.zero;
    public Vector3 upperBound = Vector3.zero;

    void Start()
    {
        lowerBound = (lowerBound == Vector3.zero ? gameObject.transform.position : lowerBound);
        upperBound = (upperBound == Vector3.zero ? gameObject.transform.position : upperBound);
    }

    void Update()
    {
        if ((RigidbodyConstraints.FreezePositionX & gameObject.GetComponent<Rigidbody>().constraints) == 0)
        {
            float upperX = upperBound.x - gameObject.transform.localPosition.x;
            float lowerX = lowerBound.x - gameObject.transform.localPosition.x;
            if (upperX < 0.0f || lowerX > 0.0f) gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            if (upperX < 0.0f) gameObject.transform.Translate(upperX, 0, 0);
            if (lowerX > 0.0f) gameObject.transform.Translate(lowerX, 0, 0);
        }
        if ((RigidbodyConstraints.FreezePositionY & gameObject.GetComponent<Rigidbody>().constraints) == 0)
        {
            float upperY = upperBound.y - gameObject.transform.localPosition.y;
            float lowerY = lowerBound.y - gameObject.transform.localPosition.y;
            if (upperY < 0.0f || lowerY > 0.0f) gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            if (upperY < 0.0f) gameObject.transform.Translate(0, upperY, 0);
            if (lowerY > 0.0f) gameObject.transform.Translate(0, lowerY, 0);
        }
        if ((RigidbodyConstraints.FreezePositionZ & gameObject.GetComponent<Rigidbody>().constraints) == 0)
        {
            float upperZ = upperBound.z - gameObject.transform.localPosition.z;
            float lowerZ = lowerBound.z - gameObject.transform.localPosition.z;
            if (upperZ < 0.0f || lowerZ > 0.0f) gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            if (upperZ < 0.0f) gameObject.transform.Translate(0, 0, upperZ);
            if (lowerZ > 0.0f) gameObject.transform.Translate(0, 0, lowerZ);
        }
    }

    public void MoveX(float x)
    {
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(x, 0, 0);
    }

    public void MoveY(float y)
    {
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, y, 0);
    }

    public void MoveZ(float z)
    {
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, z);
    }

}
