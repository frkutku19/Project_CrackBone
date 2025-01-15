using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class EscapeFromPlayer : MonoBehaviour
{

    private NavMeshAgent agent;
    [SerializeField] Transform playerTransform;
    [SerializeField] float multiplier;
    Animator anim;
    EnemyStats stats;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        stats = GetComponent<EnemyStats>();
        agent.speed = stats.enemyStats["Speed"];
    }

    void Update()
    {
        Invoke(nameof(Run), 3);
    }

    void Run()
    {
        Vector3 runTo = transform.position + (transform.position - playerTransform.position * multiplier);
        float distance = Vector3.Distance(transform.position, playerTransform.position);
        if (distance < stats.enemyStats["Range"])
        {
            agent.SetDestination(runTo);
            anim.SetFloat("Speed", 1);
        }
        else
        {
            anim.SetFloat("Speed", 0);
        }
    }
}