using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderAI : MonoBehaviour
{
    [SerializeField]
    AnimationCurve speedDistribution;
    [SerializeField]
    AnimationCurve distanceDistribution;
    [SerializeField]
    AnimationCurve waitingTimeDistribution;
    [SerializeField]
    float movingProbability;
    float minDelta = 0.1f;
    Vector4 boardBounds;
    float currentSpeed;
    float nextActionTime;
    Vector2 wayPoint;
    State currentState;
    Dude dude;
    private float openness, mobility;
    private bool explorator, protector;
    float distance;


    public void Init(Vector4 boardBounds, Dude dude)
    {
        this.boardBounds = boardBounds;
        this.dude = dude;
    }



    private void Start()
    {
        openness = Random.Range(0f, 1f);
        mobility = Random.Range(0f, 1f);
        SetMobility();
        SetOpenness();
        SetNewDestination();
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
        currentState = (State) (Random.value < movingProbability ? State.MOVING : State.WAITING);
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
       //distance = distanceDistribution.Evaluate(Random.value);
        do
        {
            float directionRadAngle = Mathf.Deg2Rad * Random.Range(0f, 360f);
            wayPoint = transform.position + new Vector3(Mathf.Cos(directionRadAngle), Mathf.Sin(directionRadAngle)) * distance;
        } while (wayPoint.x < boardBounds.w || wayPoint.x > boardBounds.y || wayPoint.y < boardBounds.z || wayPoint.y > boardBounds.x);
        currentSpeed = speedDistribution.Evaluate(Random.value);
        Debug.DrawLine(transform.position, new Vector3(wayPoint.x, wayPoint.y, transform.position.z), Color.red, 5f);
    }

    private void StartWaiting()
    {
        nextActionTime = Time.time + waitingTimeDistribution.Evaluate(Random.value);
        // change anim
        // sit if long time
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, wayPoint, currentSpeed * Time.deltaTime);
        if (Vector2.Distance(transform.position, wayPoint) < minDelta)
        {
            AssignAction();
        }
    }

    private void Wait()
    {
        if (Time.time >= nextActionTime)
        {
            AssignAction();
        }
    }

    public void SetMobility()
    {
        if (mobility <= 0.5f)
        {
            distance = Random.Range(0f,0.5f);
            explorator = false; 
        }

        else { explorator = true;
            distance = 1f;
        }

        
    }

    public void SetOpenness()
    {
        if (openness <= 0.5f) {
            distance = 0.2f;
            protector = true; 
        }

        else
        {
            protector = false;
        } 

    }
}

public enum State
{
    MOVING,
    WAITING
}
