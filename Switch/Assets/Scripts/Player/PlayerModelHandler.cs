using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModelHandler : MonoBehaviour
{
    [SerializeField]
    private vp_FPBodyAnimator playerModel;

    private SkinnedMeshRenderer mesh;
    private Material blackMaterial;
    private Material whiteMaterial;

    private bool isBlack;

    [SerializeField]
    private Material[] modelMaterials = new Material[7];

    void Start()
    {
        GetModel();
    }

    void GetModel()
    {
        mesh = this.GetComponent<SkinnedMeshRenderer>();

        blackMaterial = MaterialManager.Instance.BlackMaterial;
        whiteMaterial = MaterialManager.Instance.WhiteMaterial;
    }

    void SetStartingColour()
    {
       
    }

    private void SwitchModelColor()
    {
        if (isBlack)
        {
            isBlack = false;
            SetModelColor(whiteMaterial);
            Debug.Log("TurnWhite");
        }
        else
        {
            isBlack = true;
            SetModelColor(blackMaterial);
            Debug.Log("TurnBlack");
        }
    }

    private void SetModelColor(Material mat)
    {
        modelMaterials[2] = mat;
        modelMaterials[3] = mat;
        modelMaterials[4] = mat;

        mesh.materials = modelMaterials;

        playerModel.InitMaterials();

        //mesh.sharedMaterials[2] = mat;
        //mesh.sharedMaterials[3] = mat;
        //mesh.sharedMaterials[4] = mat;
    }
	
}
