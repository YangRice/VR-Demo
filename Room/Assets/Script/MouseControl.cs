using UnityEngine;
using System.Collections;

public class MouseControl : MonoBehaviour
{

    public new Transform camera = null;
    public float momentum;
    public float minDistance = 5;
    public float maxDistance = 30;
    public float wheelSpeed = 10;
    public float maxAngle = 60;
    public float minAngle = 5;
    public bool hasFloor = true;
    public bool HasFloor { set { hasFloor = value; } }

    Vector2 speed = new Vector2(0, 0);
    bool ignoreMouse = false;

    public void SetEnableMouseControl(bool enabled)
    {
        ignoreMouse = !enabled;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float wheel = Input.GetAxis("Mouse ScrollWheel");
        if (wheel != 0.0f)
        {
            camera.position = camera.position - camera.position.normalized * wheel * wheelSpeed;
            if (camera.position.magnitude > maxDistance)
                camera.position = camera.position.normalized * maxDistance;
            if (camera.position.magnitude < minDistance)
                camera.position = camera.position.normalized * minDistance;
        }

        speed *= Mathf.Abs(momentum);
        if (Input.GetMouseButton(0) && !ignoreMouse)
            speed += new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")) * Mathf.Sign(momentum);

        transform.Rotate(new Vector3(-speed.y, speed.x, 0));

        float z = transform.rotation.eulerAngles.z;
        z = (z > 180 ? z - 360 : z);
        transform.Rotate(new Vector3(0, 0, -z));

        float x = Vector3.ProjectOnPlane(camera.position, new Vector3(0, 1, 0)).magnitude;
        float y = camera.position.y;
        float angle = Mathf.Atan(y / x) * Mathf.Rad2Deg;

        if (hasFloor)
        {
            transform.Rotate(new Vector3(angle < minAngle ? -angle + minAngle : 0, 0, 0));
            transform.Rotate(new Vector3(angle > maxAngle ? -angle + maxAngle : 0, 0, 0));
        }
    }
}
