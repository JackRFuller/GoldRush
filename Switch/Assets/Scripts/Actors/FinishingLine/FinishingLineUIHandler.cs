using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishingLineUIHandler : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField]
    private Text distanceText;

    private Transform playerTransform;

    private void Start()
    {
        playerTransform = FindObjectOfType<PlayerInputHandler>().transform;

        if (!playerTransform)
        {
           DisableObject();
        }
    }

    private void Update()
    {
        RotateToFacePlayer();

        CalculateDistanceToPlayer();
    }

    private void RotateToFacePlayer()
    {
        Vector3 targetPosition = new Vector3(playerTransform.position.x,
                                             this.transform.position.y,
                                             playerTransform.position.z);


        this.transform.LookAt(targetPosition);
    }

    private void CalculateDistanceToPlayer()
    {
        float distance = Vector3.Distance(transform.position, playerTransform.position);
        string distanceString = distance.ToString("F1") + "m";
        distanceText.text = distanceString;
    }

    private void DisableObject()
    {
        this.gameObject.SetActive(false);
    }

	

}
