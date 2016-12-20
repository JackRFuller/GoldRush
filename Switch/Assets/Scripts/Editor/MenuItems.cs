using UnityEngine;
using UnityEditor;

public class MenuItems
{
    [MenuItem(("Switch/Toggle Level Building"))]
    private static void ToggleLevelBuilding()
    {
        LevelManager.ToggleLevelEditingMode();
    }
	
}
