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
    [SerializeField]
    float towardsRegionPositionProbability;
    [SerializeField]
    Animator animator;
    [SerializeField] float minDelta;
    Collider2D board;
    float currentSpeed;
    float nextActionTime;
    Vector2 wayPoint;
    State currentState;
    Dude dude;
    DudesManager dudesManager;



    public void Init(Collider2D board, Dude dude, DudesManager dudesManager)
    {
        this.board = board;
        this.dude = dude;
        this.dudesManager = dudesManager;
    }



    private void Start()
    {
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
        if (Random.value < towardsRegionPositionProbability)
        {
            float minDistance = Mathf.Infinity;
            Transform closestRegion = null;
            foreach (var region in dudesManager.RegionsPositions)
            {
                float distanceToRegion = Vector3.Distance(transform.position, region.position);
                if (distanceToRegion < minDistance)
                {
                    minDistance = distanceToRegion;
                    closestRegion = region;
                }
            }
            wayPoint = closestRegion.position;
        }
        else
        {
            float distance = distanceDistribution.Evaluate(Random.value) * dude.StatsManager.Mobility;
            // do
            // {
            //     float directionRadAngle = Mathf.Deg2Rad * Random.Range(0f, 360f);
            //     wayPoint = transform.position + new Vector3(Mathf.Cos(directionRadAngle), Mathf.Sin(directionRadAngle)) * distance;
            // } while (wayPoint.x < boardBounds.w || wayPoint.x > boardBounds.y || wayPoint.y < boardBounds.z || wayPoint.y > boardBounds.x);
            // } while (!board.OverlapPoint(wayPoint));
        }
        currentSpeed = speedDistribution.Evaluate(Random.value);
        Debug.DrawLine(transform.position, new Vector3(wayPoint.x, wayPoint.y, transform.position.z), Color.red, 5f);
        transform.localScale = new Vector3(wayPoint.x > transform.position.x ? -1 : 1, 1, 1);
        animator.SetBool("IsWalking", true);
    }

    private void StartWaiting()
    {
        nextActionTime = Time.time + waitingTimeDistribution.Evaluate(Random.value);
        animator.SetBool("IsWalking", false);
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
}

public enum State
{
    MOVING,
    WAITING
}
