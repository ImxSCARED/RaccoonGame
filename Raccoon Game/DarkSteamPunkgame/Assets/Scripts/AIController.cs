using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class AIController : MonoBehaviour
{
    Renderer ren;

    public NavMeshAgent navMeshAgent;

    public float startWaitTime;
    public float timeToRotate;
    public float speedWalk;
    public float speedRun;

    public float viewRadius;
    public float viewAngle;

    public LayerMask playerMask;
    public LayerMask obstacleMask;

    public float meshResolution;
    public int edgeIterations;
    public float edgeDistance;

    public Transform[] waypoints;
    int m_CurrentWaypointIndex;

    Vector3 playerLastPosition = Vector3.zero;
    Vector3 m_PLayerPosition;

    float m_WaitTime;
    float m_TimeToRotate;
    bool m_PlayerInRange;
    bool m_PlayerNear;
    bool m_IsPatrol;
    bool m_CaughtPlayer;

    //light
    public Light myLight;
    public Color myLightColour;

    //audio
    public AudioSource foundPlayer;



    // Start is called before the first frame update
    void Start()
    {
        //variables
        m_PLayerPosition = Vector3.zero;
        m_IsPatrol = true;
        m_CaughtPlayer = false;
        m_PlayerInRange = false;
        m_WaitTime = startWaitTime;
        m_TimeToRotate = timeToRotate;

        m_CurrentWaypointIndex = 0;
        navMeshAgent = GetComponent<NavMeshAgent>();

        navMeshAgent.isStopped = false;
        navMeshAgent.speed = speedWalk;
        navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);



    }

    // Update is called once per frame
    void Update()
    {
        EnviromentView();

        if (!m_IsPatrol)
        {
            

            Chasing();
            //change color
            ren = GetComponent<Renderer>();
            ren.material.color = Color.red;
            myLight.color = Color.red;

        }
        else
        {
           

            Patroling();
            //change color
            ren = GetComponent<Renderer>();
            ren.material.color = Color.yellow;
            myLight.color = Color.yellow;
        }
    }

    //chasing

    private void Chasing()
    {
        

        m_PlayerNear = false;
        playerLastPosition = Vector3.zero;
        //did enemy reach the stopping distance?
        if (!m_CaughtPlayer)
        {
            //is enemy not near the player?
            Move(speedRun);
            navMeshAgent.SetDestination(m_PLayerPosition);
        }
        //if enemy is not near player, return to patrol
        if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {                                                                                                                                                   //variable
            if (m_WaitTime <= 0 && !m_CaughtPlayer && Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) >= 1.5f)
            {
                m_IsPatrol = true;
                m_PlayerNear = false;
                Move(speedWalk);
                m_TimeToRotate = timeToRotate;
                m_WaitTime = startWaitTime;
                navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);

            }
            else
            {                                                                                                           //variable
                if (Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) >= 1f)
                {
                    Stop();
                    m_WaitTime -= Time.deltaTime;
                }
            }
        }

    }
    //patrolling
    private void Patroling()
    {
        
        //if player is near

        if (m_PlayerNear)
        {
            if (m_TimeToRotate <= 0)
            {
                Move(speedWalk);
                LookingPlayer(playerLastPosition);
            }
            else
            {
                Stop();
                m_TimeToRotate -= Time.deltaTime;
            }
        }
        else
        {
            //player is not near
            m_PlayerNear = false;
            playerLastPosition = Vector3.zero;
            navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
            if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
            {
                if (m_WaitTime <= 0)
                {
                    NextPoint();
                    Move(speedWalk);
                    m_WaitTime = startWaitTime;

                }
                else
                {
                    Stop();
                    m_WaitTime -= Time.deltaTime;

                }
            }
        }
    }
    void Move(float speed)
    {
        navMeshAgent.isStopped = false;
        navMeshAgent.speed = speed;
    }
    void Stop()
    {
        navMeshAgent.isStopped = true;
        navMeshAgent.speed = 0;
    }
    //patrol point movement
    public void NextPoint()
    {
        m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;
        navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
    }

    void CaughtPlaye()
    {
        m_CaughtPlayer = true;
    }
    //looking for player
    void LookingPlayer(Vector3 player)
    {
        navMeshAgent.SetDestination(player);
        if (Vector3.Distance(transform.position, player) <= 0.3)
        {
            if (m_WaitTime <= 0)
            {
                m_PlayerNear = false;
                Move(speedWalk);
                navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
                m_WaitTime = startWaitTime;
                m_TimeToRotate = timeToRotate;
            }
            else
            {
                Stop();
                m_WaitTime -= Time.deltaTime;
            }
        }
    }
    void EnviromentView()
    {
        //detect player
        Collider[] playerInRange = Physics.OverlapSphere(transform.position, viewRadius, playerMask);

        for (int i = 0; i < playerInRange.Length; i++)
        {
            Transform player = playerInRange[i].transform;
            Vector3 dirToPlayer = (player.position - transform.position).normalized;
            if (Vector3.Angle(transform.forward, dirToPlayer) < viewAngle / 2)
            {
                //distance to player
                float dstToPlayer = Vector3.Distance(transform.position, player.position);
                //angle enemy can see player (raycast)
                if (!Physics.Raycast(transform.position, dirToPlayer, dstToPlayer, obstacleMask))
                {
                    m_PlayerInRange = true;
                    m_IsPatrol = false;
                }
                //is player behind obstacle?
                else
                {
                    m_PlayerInRange = false;
                }
            }
            //is player in view?
            if (Vector3.Distance(transform.position, player.position) > viewRadius)
            {
                m_PlayerInRange = false;
            }
            if (m_PlayerInRange)
            {
                m_PLayerPosition = player.transform.position;
            }
        }
    }

}



