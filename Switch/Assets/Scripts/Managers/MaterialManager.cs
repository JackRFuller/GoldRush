using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialManager : MonoSingleton<MaterialManager>
{
    [SerializeField] private Material enabledMaterial;
    public Material EnabledMaterial
    {
        get { return enabledMaterial; }
    }

    [SerializeField] private Material disabledMaterial;
    public Material DisabledMaterial
    {
        get { return disabledMaterial; }
    }

    [SerializeField]
    private Material blackMaterial;
    public Material BlackMaterial {
        get { return blackMaterial; }
    }

    [SerializeField]
    private Material whiteMaterial;
    public Material WhiteMaterial {
        get { return whiteMaterial; }
    }


}
