using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTrigger : MonoBehaviour
{
    [SerializeField] private GameObject objects;

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            objects.SendMessage("TriggerBehaviour",SendMessageOptions.DontRequireReceiver);
        }
    }
	
}
