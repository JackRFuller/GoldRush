using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoSingleton<UIManager>
{
    [SerializeField]
    private GameObject UI;

    private void OnEnable()
    {
        UI.SetActive(true);
    }

}
