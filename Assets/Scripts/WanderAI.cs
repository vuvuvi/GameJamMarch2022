using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WanderAI : MonoBehaviour
{
    [SerializeField]
    float minSpeed;
    [SerializeField]
    float maxSpeed;
    [SerializeField]
    float minDistance;
    [SerializeField]
    float maxDistance;
    [SerializeField]
    float minWaitingTime;
    [SerializeField]
    float maxWaitingTime;

    float minDelta;
    Vector4 boardBounds;

    float currentSpeed;

    float nextActionTime;

    Vector2 wayPoint;

    State currentState;



    public void Init(Vector3 boardBounds)
    {
        this.boardBounds = boardBounds;
    }



    private void Awake()
    {
        AssignAction();
    }

    private void Update()
    {
        switch (currentState)
        {
            case State.MOVING:
                Move();
                break;
            case State.WAITING:
                Wait();
                break;
        }
    }

    private void AssignAction()
    {
        currentState = (State) Random.Range(0, 2);
        switch (currentState)
        {
            case State.MOVING:
                SetNewDestination();
                break;
            case State.WAITING:
                StartWaiting();
                break;
        }
    }

    private void SetNewDestination()
    {
        float distance = Random.Range(minDistance, maxDistance);
        float directionRadAngle = Mathf.Deg2Rad * Random.Range(0f, 360f);
        wayPoint = transform.position + new Vector3(Mathf.Cos(directionRadAngle), Mathf.Sin(directionRadAngle)) * distance;
        currentSpeed = Random.Range(minSpeed, maxSpeed);
        Debug.DrawLine(transform.position, new Vector3(wayPoint.x, wayPoint.y, transform.position.z), Color.red, 5f);
    }

    private void StartWaiting()
    {
        nextActionTime = Random.Range(minWaitingTime, maxWaitingTime);
        // change anim
        // sit if long time
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, wayPoint, currentSpeed * Time.deltaTime);
        if (Vector2.Distance(transform.position, wayPoint) < minDelta)
        {
            SetNewDestination();
        }
    }

    private void Wait()
    {
        if (Time.time >= nextActionTime)
        {
            AssignAction();
        }
    }



    public enum State
    {
        MOVING,
        WAITING
    }
}




