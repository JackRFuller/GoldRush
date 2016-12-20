using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoSingleton<LevelManager>
{
    [SerializeField]
    private LevelData currentLevel;
    public LevelData CurrentLevel {
        get { return currentLevel; }
    }

    private LevelTimer levelClock;
    public LevelTimer LevelClock {
        get { return levelClock; }
    }

    public struct LevelTimer
    {
        public bool isRunning;
        public float[] timeTargets;
        public float levelTimer;
    }

    public static bool isTesting;

    private void Awake()
    {
        LoadInLevel();
    }

    void OnEnable()
    {
        EventManager.StartListening("StartLevel",StartLevelTimer);
        EventManager.StartListening("EndLevel", StopLevelTimer);
    }

    private void OnDisable()
    {
        EventManager.StopListening("StartLevel", StartLevelTimer);
        EventManager.StopListening("EndLevel", StopLevelTimer);
    }

    private void LoadInLevel()
    {
        GameObject level = null;

        if (isTesting)
            level = (GameObject) Instantiate(currentLevel.LevelPrefab);
    }

    void StartLevelTimer()
    {
        levelClock.isRunning = true;
    }

    void StopLevelTimer()
    {
        levelClock.isRunning = false;
    }

    void Update()
    {
        RunTimer();
    }

    void RunTimer()
    {
        if(!levelClock.isRunning)
            return;

        levelClock.levelTimer += Time.deltaTime;

        EventManager.TriggerEvent("LevelTimer");
    }

    #region EditorFunctions

    public static void ToggleLevelEditingMode()
    {
        if (isTesting)
        {
            isTesting = false;
            Debug.Log("Building is ON");
        }
            
        else
        {
            isTesting = true;
            Debug.Log("Testing is ON");
        }
    }

    #endregion

}
