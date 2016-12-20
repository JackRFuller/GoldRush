using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartCountdownHandler : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField]
    private Text[] countdownText;
	[SerializeField]
    private Image timerImage;
    [SerializeField]
    private GameObject countdownObject;

    //Lerping Variables
    private float timeStarted;
    private int count = 0;

    private void Start()
    {
        Initialise();
        StartCoroutine(RunCountdown());
    }

    private void Initialise()
    {
        for (int i = 0; i < countdownText.Length; i++)
        {
            countdownText[i].enabled = false;
        }

        timerImage.fillAmount = 0;
        timeStarted = Time.time;

    }

    private IEnumerator RunCountdown()
    {
        for (int i = 0; i < countdownText.Length; i++)
        {
            countdownText[i].enabled = true;
            yield return new WaitForSeconds(1.0f);
            countdownText[i].enabled = false;
        }

        countdownObject.SetActive(false);
    }

    private void Update()
    {
        LerpTimeImage();   
    }

    private void LerpTimeImage()
    {
        float timeSinceStarted = Time.time - timeStarted;
        float percentageComplete = timeSinceStarted/1;

        float fillAmount = Mathf.Lerp(0, 1, percentageComplete);

        timerImage.fillAmount = fillAmount;

        if (percentageComplete >= 1.0f)
        {
            timeStarted = Time.time;
            count++;
            if (count == 3)
            {
                timerImage.fillAmount = 0;
                this.enabled = false;
            }
        }
    }

}
