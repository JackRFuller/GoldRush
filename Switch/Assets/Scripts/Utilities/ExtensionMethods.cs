﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtensionMethods : MonoBehaviour
{

    #region Input
    public static bool GetSwitchInput()
    {
        if (Input.GetMouseButtonUp(0))
            return true;
        else
        {
            return false;
        }
    }

    public static bool GetSlowMoTrigger()
    {
        if (Input.GetMouseButtonDown(1))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool GetNormalTimeTrigger()
    {
        if (Input.GetMouseButtonUp(1))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
#endregion

    public static string FormatTime(float time)
    {
        string formattedTime = string.Empty;

        var intTime = (int)Mathf.Floor(time);
        var minutes = intTime / 60;
        var seconds = intTime % 60;
        var fraction = time * 100;
        fraction = fraction % 100;
        formattedTime = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, fraction);

        return formattedTime;
    }


}
