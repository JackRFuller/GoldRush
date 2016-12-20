using UnityEngine;

public class FinishTriggerHandler : MonoBehaviour
{
    [Header("Line Properties")]
    [SerializeField] private Transform line;
    [SerializeField] private MeshRenderer lineMesh;   


    private Collider col;

    void Start()
    {
        Initialise();
        SetMaterialTiling();
    }

    private void Initialise()
    {
        col = GetComponent<Collider>();
        col.isTrigger = true;
        col.enabled = true;
    }

    private void SetMaterialTiling()
    {
        Material lineMat = lineMesh.material;
        lineMat.mainTextureScale = new Vector2(line.localScale.x,1);
        lineMesh.material = lineMat;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            TriggerStartEvent();
        }
    }

    void TriggerStartEvent()
    {
        EventManager.TriggerEvent("EndLevel");
        col.enabled = false;
    }
}
