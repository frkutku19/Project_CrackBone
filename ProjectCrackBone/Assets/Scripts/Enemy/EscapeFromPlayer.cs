using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class EscapeFromPlayer : MonoBehaviour
{

    private NavMeshAgent agent;
    [SerializeField] Transform playerTransform;
    [SerializeField] float range;
    [SerializeField] float multiplier;
    Animator anim;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        agent.speed = Random.Range(2f, 4f);
    }

    void Update()
    {
        Invoke(nameof(Run), 3);
    }

    void Run()
    {
        Vector3 runTo = transform.position + (transform.position - playerTransform.position * multiplier);
        float distance = Vector3.Distance(transform.position, playerTransform.position);
        if (distance < range)
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