using UnityEngine;
using System.Collections;
using System.Xml;

class Feature
{
    public Feature(XmlNode featureNode)
    {
        Name = featureNode.Attributes["name"].Value;
        foreach (XmlNode node in featureNode.ChildNodes)
        {
            if (node.Name == "CameraTranslate")
            {
                cameraTranslate = new Vector3(
                    float.Parse(node.Attributes["x"].Value),
                    float.Parse(node.Attributes["y"].Value),
                    float.Parse(node.Attributes["z"].Value)
                    );
            }
        }
    }
    public string Name;
    public Vector3 cameraTranslate = Vector3.zero;
}

public class FeatureReader : MonoBehaviour
{
    public GameObject prefabButton;
    Feature[] features;

    public void OnClick(int i)
    {
        Debug.Log("OnClick " + features[i].Name);
    }

    // Use this for initialization
    void Start()
    {
        XmlDocument xml = new XmlDocument();
        xml.Load("shoe.xml");
        XmlNode root = xml.FirstChild;
        XmlNodeList featureNodes = root.ChildNodes;
        features = new Feature[featureNodes.Count];

        int offset = 0;
        int i = 0;
        foreach (XmlNode featureNode in featureNodes)
        {
            features[i] = new Feature(featureNode);
            Feature feature = features[i];

            GameObject buttonCanvas = (GameObject)Instantiate(prefabButton);
            var button = buttonCanvas.GetComponentInChildren<UnityEngine.UI.Button>();
            var text = button.GetComponentInChildren<UnityEngine.UI.Text>();
            var rect = button.GetComponent<UnityEngine.RectTransform>();
            if (i == 0)
                button.onClick.AddListener(() => OnClick(0));
            if (i == 1)
                button.onClick.AddListener(() => OnClick(1));
            text.text = feature.Name;
            rect.position = new Vector3(rect.position.x, rect.position.y - offset);

            offset += 60;
            i++;
        }
        var prefabb = prefabButton.GetComponentInChildren<UnityEngine.UI.Button>();
        prefabb.GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
