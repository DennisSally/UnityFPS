using StarterAssets;
using UnityEngine;
using UnityEngine.AI;

public class Robot : MonoBehaviour
{
    FirstPersonController player;
    NavMeshAgent agent;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void Start()
    {
        player = FindFirstObjectByType<FirstPersonController>();

    }
    private void Update()
    {
        agent.SetDestination(player.transform.position);
    }
}