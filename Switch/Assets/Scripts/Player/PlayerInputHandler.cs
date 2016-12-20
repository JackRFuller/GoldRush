using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour {

	
	
	// Update is called once per frame
	void Update ()
    {
        if (ExtensionMethods.GetSwitchInput())
        {
            SwitchObjects();
        }

        SetSlowMotionState();
	}

    private void SwitchObjects()
    {
        EventManager.TriggerEvent("Switch");
    }

    private void SetSlowMotionState()
    {
        if (ExtensionMethods.GetSlowMoTrigger())
        {
            TimeManager.Instance.TriggerSlowMotionState();
        }
        else if(ExtensionMethods.GetNormalTimeTrigger())
        {
            TimeManager.Instance.ReturnToStandardSpeed();
        }
    }
}
