using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoSingleton<TimeManager>
{
    [SerializeField]
    private float amountOfSlowMo = 5.0f; // Determines how much time the player is allowed the run slow mo for
    public float AmountOfSlowMo {
        get { return amountOfSlowMo; }
    }

    private float currentSlowMo; //Tracks how much of their slow motion allowance they've used
    public float CurrentSlowMo
    {
        get
        {
            return currentSlowMo;
            
        }
    }
    [SerializeField]
    private float slowMoSpeed = 0.3f; //Controls how slow the player goes
    private bool isSlowMoMode;
    [SerializeField]
    private float slowMoCooldownTime;
    [SerializeField]
    private float slowMoRenewSpeed;

    private void Start()
    {
        Initiatlise();
    }

    private void Initiatlise()
    {
        currentSlowMo = amountOfSlowMo;
    }

    void Update()
    {
        if(isSlowMoMode)
            SetSlowMotionState();

        ReduceSlowMoAmount();
    }

    
    void SetSlowMotionState()
    {
        if (Time.timeScale == 1.0f)
            Time.timeScale = slowMoSpeed;
    }

    public void TriggerSlowMotionState()
    {
        if(currentSlowMo > 0)
            isSlowMoMode = true;
    }

    /// <summary>
    /// Triggered by PlayerInputHandler
    /// </summary>
    public void ReturnToStandardSpeed()
    {
        isSlowMoMode = false;

        Time.timeScale = 1.0f;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
    }

    /// <summary>
    /// Triggered by PlayerInputHandler
    /// </summary>
    public void ReduceSlowMoAmount()
    {
        if (Time.timeScale == slowMoSpeed)
        {
            if (currentSlowMo > 0)
            {
                StopCoroutine(RenewSlowMoTime());
                currentSlowMo -= Time.deltaTime;
                EventManager.TriggerEvent("SlowMotionMode");
            }
        }

        if (currentSlowMo <= 0)
        {
            StartCoroutine(RenewSlowMoTime());
            Time.timeScale = 1.0f;
        }

        if (currentSlowMo < amountOfSlowMo && !isSlowMoMode)
        {
            StartCoroutine(RenewSlowMoTime());
        }
    }

    IEnumerator RenewSlowMoTime()
    {
        yield return new WaitForSeconds(slowMoCooldownTime);

        while (currentSlowMo < amountOfSlowMo)
        {
            yield return new WaitForSeconds(slowMoRenewSpeed);
            currentSlowMo += Time.fixedDeltaTime;
            EventManager.TriggerEvent("SlowMotionMode");
        }

        currentSlowMo = amountOfSlowMo;
    }
	
}
