using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class StatusScript : MonoBehaviour
{

    public int maxHealth = 10;

    private int _currentHealth;
    public int currentHealth { get { return _currentHealth; } }

    private PlayerController _controller = null;

    void Awake()
    {
        _currentHealth = maxHealth;
        _controller = GetComponent<PlayerController>();
    }

    public void TakeDamage(int amount, Vector3 attackerForward)
    {
        if(_controller) _controller.AddImpulse(attackerForward);
        TakeDamage(amount);
    }

    public void TakeDamage(int amount)
    {
        _currentHealth = Mathf.Clamp(_currentHealth - amount, 0, maxHealth);
        if(_currentHealth == 0)
        {
            Death();
        }
    }

    public void Heal(int amount)
    {
        _currentHealth = Mathf.Clamp(_currentHealth + amount, 0, maxHealth);
    }

    private void Death()
    {
        if(gameObject.layer == 9)
        {
            Destroy(gameObject);
            EnemySpawner.enemyNumber--;
        }
        else
        {
            //@todo gameover
        }
    }
}

