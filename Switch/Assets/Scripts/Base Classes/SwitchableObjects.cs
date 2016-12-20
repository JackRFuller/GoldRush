using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchableObjects : MonoBehaviour
{
    protected ObjectComponents objectComponents;
    protected struct ObjectComponents
    {
        public Material enabledMaterial;
        public Material disabledMaterial;

        public MeshRenderer mesh;
        public Collider col;
    }

    [SerializeField]
    private ObjectState.State objectState;

    private bool isObjectActive;
    
    #region Events

    protected  virtual void OnEnable()
    {
        SubscribeToEvents();
    }

    protected virtual void SubscribeToEvents()
    {
       EventManager.StartListening("Switch", SwitchObjectState);
    }

    protected virtual void OnDisable()
    {
        UnSubscribeFromEvents();
    }

    protected virtual void UnSubscribeFromEvents()
    {
        EventManager.StopListening("Switch", SwitchObjectState);
    }

#endregion

    void Start()
    {
        GetKeyComponents();
        SetObjectStartingState();
    }

    void GetKeyComponents()
    {
        objectComponents.mesh = GetComponent<MeshRenderer>();
        objectComponents.col = GetComponent<Collider>();

        objectComponents.enabledMaterial = MaterialManager.Instance.EnabledMaterial;
        objectComponents.disabledMaterial = MaterialManager.Instance.DisabledMaterial;
    }

    protected  virtual void SetObjectStartingState()
    {
        switch (objectState)
        {
            case ObjectState.State.Enabled:
                EnableObject();
                break;

            case ObjectState.State.Disabled:
                DisableObject();
                break;
        }
    }

    protected virtual void SwitchObjectState()
    {
        switch (objectState)
        {
            case ObjectState.State.Disabled:
                EnableObject();
                objectState = ObjectState.State.Enabled;
                break;
            case ObjectState.State.Enabled:
                DisableObject();
                objectState = ObjectState.State.Disabled;
                break;
        }
    }

    protected virtual void EnableObject()
    {
        objectComponents.mesh.material = objectComponents.enabledMaterial;

        objectComponents.col.enabled = true;
    }

    protected virtual void DisableObject()
    {
        objectComponents.mesh.material = objectComponents.disabledMaterial;

        objectComponents.col.enabled = false;
    }
}
