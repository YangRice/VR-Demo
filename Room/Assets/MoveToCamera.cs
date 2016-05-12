using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class MoveToCamera : MonoBehaviour
{
    class RT
    {
        public Vector3 position = Vector3.zero;
        public Vector3 eulerAngles = Vector3.zero;
        public Quaternion rotation = Quaternion.identity;
        public RT(Transform trans)
        {
            position = trans.position;
            eulerAngles = trans.eulerAngles;
            rotation = trans.rotation;
        }
    }
    RT revert = null;
    RT start = null;
    RT end = null;

    public float speed = 0.01f;
    public float index = 0.0f;
    public bool IsRunning { get { return start != null; } }

    public void OnButtonClick(GameObject obj)
    {
        while (IsRunning)
        {
            LateUpdate();
        }
        revert = new RT(this.transform);
        start = revert;
        end = new RT(obj.transform);
        index = 0.0f;
    }

    public void OnRevertCamera()
    {
        while (IsRunning)
        {
            LateUpdate();
        }
        start = new RT(this.transform);
        end = revert;
        index = 0.0f;
    }

    // Use this for initialization
    void Start()
    {

    }

    public Vector3 camT;
    public Vector3 camR;

    // Update is called once per frame
    void LateUpdate()
    {
        Transform cam = this.transform;
        camT = cam.position;
        camR = cam.rotation.eulerAngles;
        if (start != null && end != null)
        {
            float i = index > 1.0f ? 1.0f : (Mathf.Sin((index + Mathf.PI * 0.5f) * Mathf.PI) + 1.0f) * 0.5f;
            cam.position = Vector3.Lerp(start.position, end.position, i);
            (cam.parent == null ? cam : cam.parent).rotation = Quaternion.Lerp(start.rotation, end.rotation, i);

            index += speed;
        }
        if (index >= 1.0f)
        {
            if (IsRunning)
            {
                cam.position = end.position;
                (cam.parent == null ? cam : cam.parent).rotation = end.rotation;
            }
            start = null;
        }
    }
}
