using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{
    NavMeshAgent agent;
    GameObject player;
    Animator animator;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        animator.SetBool("IsWalking", true);
        agent.SetDestination(player.transform.position);
    }
}
