using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AIController : MonoBehaviour
{
    public int damage = 10;

    private NavMeshAgent _agent = null;
    private PlayerController _player = null;

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
            collision.gameObject.GetComponent<StatusScript>().TakeDamage(damage, transform);
        }
    }
}
