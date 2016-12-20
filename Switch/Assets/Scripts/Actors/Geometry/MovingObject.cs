using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : TriggerableObject
{
    [Header("Movement Properties")]
    [SerializeField] private Vector3 startPosition;
    [SerializeField] private Vector3 endPosition;

    [Header("Lerping Properties")]
    [SerializeField] private float movementSpeed;
    [SerializeField] private AnimationCurve movementCurve;
    private float timeStarted;

    private void Start()
    {
        this.enabled = false;
    }

    public override void TriggerBehaviour()
    {
        timeStarted = Time.time;
        this.enabled = true;
    }

    private void Update()
    {
        MoveObject();
    }

    private void MoveObject()
    {
        float timeSinceStarted = Time.time - timeStarted;
        float percentageComplete = timeSinceStarted / movementSpeed;

        Vector3 newPos = Vector3.Lerp(startPosition,endPosition,movementCurve.Evaluate(percentageComplete));

        transform.position = newPos;

        if (percentageComplete >= 1.0f)
        {
            EndMovement();
        }
    }

    private void EndMovement()
    {
        this.enabled = false;
    }


}
