using TMPro;
using UnityEngine;

public class ResourceVisual : MonoBehaviour
{
    public GameResource resource;
    public TextMeshProUGUI rT, rL;

    private ResourceBank resourceBank;

    private void Start()
    {

        resourceBank = FindObjectOfType<ResourceBank>();
        if (resourceBank != null)
        {
            UpdateVisual(resourceBank.GetResource(resource).Value);
            resourceBank.GetResource(resource).OnValueChanged += UpdateVisual;
        }
    }

    private void UpdateVisual(int newV)
    {
        rT.text = newV.ToString();
        rL.text = resource.ToString();
    }

    private void OnDestroy()
    {
        if (resourceBank != null)
        {
            resourceBank.GetResource(resource).OnValueChanged -= UpdateVisual;
        }
    }
}