using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTriggerHandler : MonoBehaviour
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
        lineMat.mainTextureScale = new Vector2(line.localScale.x, 1);
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
        EventManager.TriggerEvent("StartLevel");
        col.enabled = false;
    }
}
