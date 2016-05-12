using UnityEngine;
using System.Collections;

public class MouseControl : MonoBehaviour {

    public new Transform camera = null;
    public float momentum;
    public float minDistance = 5;
    public float maxDistance = 30;

    Vector2 speed = new Vector2(0, 0);
    bool ignoreMouse = false;

    public void SetEnableMouseControl(bool enabled)
    {
        ignoreMouse = !enabled;
    }
    
    // Use this for initialization
    void Start () {
	    
	}

    // Update is called once per frame
    void Update ()
    {
        float wheel = Input.GetAxis("Mouse ScrollWheel");
        if (wheel != 0.0f)
        {
            camera.position = camera.position - camera.position.normalized * wheel * 10;
            if (camera.position.magnitude > maxDistance)
                camera.position = camera.position.normalized * maxDistance;
            if (camera.position.magnitude < minDistance)
                camera.position = camera.position.normalized * minDistance;
        }

        speed *= momentum;
        if (Input.GetMouseButton(0) && !ignoreMouse)
            speed += new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        transform.Rotate(new Vector3(-speed.y, speed.x, 0));

        float z = transform.rotation.eulerAngles.z;
        z = (z > 180 ? z - 360 : z);
        transform.Rotate(new Vector3(0, 0, -z));

        float x = transform.rotation.eulerAngles.x;
        x = (x > 180 ? x - 360 : x);
        transform.Rotate(new Vector3(x < -10 ? -x - 10 : 0, 0, 0));
        transform.Rotate(new Vector3(x > 45 ? -x + 45 : 0, 0, 0));
    }
}
