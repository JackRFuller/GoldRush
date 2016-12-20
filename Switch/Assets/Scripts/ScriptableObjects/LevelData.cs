using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "ScriptableObjects/Level Data", order = 1)]
public class LevelData : ScriptableObject
{
    [SerializeField]
    private ObjectState.State startingState;
    public ObjectState.State StartingState {
        get { return startingState; }
    }

    [SerializeField]
    private GameObject levelPrefab;
    public GameObject LevelPrefab {
        get { return levelPrefab; }
    }

    [SerializeField]
    private float[] timeTargets = new float[3];
    public float[] TimeTargets
    {
        get { return timeTargets; }
    }


	
}
