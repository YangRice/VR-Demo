using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]

public class MoveControl : MonoBehaviour
{

    public Vector3 lowerBound = Vector3.zero;
    public Vector3 upperBound = Vector3.zero;
    bool freezeX;
    bool freezeY;
    bool freezeZ;

    void Start()
    {
        freezeX = (lowerBound.x == upperBound.x);
        freezeY = (lowerBound.y == upperBound.y);
        freezeZ = (lowerBound.z == upperBound.z);
        lowerBound = (lowerBound == Vector3.zero ? gameObject.transform.localPosition : lowerBound);
        upperBound = (upperBound == Vector3.zero ? gameObject.transform.localPosition : upperBound);
    }

    void Update()
    {
        const float tolerance = 0.01f;
        if (!freezeX)
        {
            float upperX = upperBound.x - gameObject.transform.localPosition.x;
            float lowerX = lowerBound.x - gameObject.transform.localPosition.x;
            if (upperX < -tolerance || lowerX > tolerance) gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            if (upperX < 0.0f) gameObject.transform.Translate(upperX, 0, 0);
            if (lowerX > 0.0f) gameObject.transform.Translate(lowerX, 0, 0);
        }
        if (!freezeY)
        {
            float upperY = upperBound.y - gameObject.transform.localPosition.y;
            float lowerY = lowerBound.y - gameObject.transform.localPosition.y;
            if (upperY < -tolerance || lowerY > tolerance) gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            if (upperY < 0.0f) gameObject.transform.Translate(0, upperY, 0);
            if (lowerY > 0.0f) gameObject.transform.Translate(0, lowerY, 0);
        }
        if (!freezeZ)
        {
            float upperZ = upperBound.z - gameObject.transform.localPosition.z;
            float lowerZ = lowerBound.z - gameObject.transform.localPosition.z;
            if (upperZ < -tolerance || lowerZ > tolerance) gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
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

    public void RotateX(float x)
    {
        gameObject.GetComponent<Rigidbody>().angularVelocity = new Vector3(x, 0, 0);
    }

    public void RotateY(float y)
    {
        gameObject.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, y, 0);
    }

    public void RotateZ(float z)
    {
        gameObject.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, z);
    }
}
