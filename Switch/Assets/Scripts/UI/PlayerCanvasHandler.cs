using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCanvasHandler : MonoBehaviour {

	[Header("Slow Motion Bar")]
    [SerializeField]
    private GameObject slowMotionBarObjs;
    [SerializeField]
    private Image slowMotionBarImage;
    private float amountOfSlowMo;

    [Header("Timer Bar")]
    [SerializeField]
    private Text levelTimerText;

    #region Events

    private void OnEnable()
    {
        SubscribeToEvents();
    }

    private void SubscribeToEvents()
    {
        EventManager.StartListening("SlowMotionMode",ReduceSlowMotionBar);
        EventManager.StartListening("LevelTimer", UpdateTimerBar);
    }

    private void OnDisable()
    {
        UnSubscribeToEvents();   
    }

    private void UnSubscribeToEvents()
    {
        EventManager.StopListening("SlowMotionMode", ReduceSlowMotionBar);
        EventManager.StopListening("LevelTimer", UpdateTimerBar);
    }

#endregion

    void Start()
    {
        InitialiseSlowMotionBar();
    }

    #region SlowMotionBar

    private void InitialiseSlowMotionBar()
    {
        slowMotionBarObjs.SetActive(false);
        amountOfSlowMo = TimeManager.Instance.AmountOfSlowMo;
    }

    private void ReduceSlowMotionBar()
    {
        if(!slowMotionBarObjs.activeInHierarchy)
            slowMotionBarObjs.SetActive(true);

        float percentageUsed = TimeManager.Instance.CurrentSlowMo / amountOfSlowMo;
        slowMotionBarImage.fillAmount = percentageUsed;
        if (percentageUsed < 0.25f)
            slowMotionBarImage.color = Color.red;
        if(percentageUsed >= 0.25f)
            slowMotionBarImage.color = Color.white;
    }


    #endregion

    #region TimerBar

    void UpdateTimerBar()
    {
        float timer = LevelManager.Instance.LevelClock.levelTimer;

        levelTimerText.text = ExtensionMethods.FormatTime(timer);

    }

#endregion
}
