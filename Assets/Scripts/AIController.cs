using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AIController : MonoBehaviour
{
    public int damage = 10;

    private NavMeshAgent _agent = null;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        _agent.SetDestination(World.GetPlayer().transform.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 10)
        {
            collision.gameObject.GetComponent<StatusScript>().TakeDamage(damage, transform.forward);
        }
    }

    public void Death()
    {
        _agent.isStopped = true;
        _agent.SetDestination(transform.position);
    }
}
