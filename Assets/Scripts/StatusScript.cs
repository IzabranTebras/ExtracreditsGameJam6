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
        _controller.AddImpulse(attackerForward);
        TakeDamage(amount);
    }

    public void TakeDamage(int amount)
    {
        _currentHealth = Mathf.Clamp(_currentHealth - amount, 0, maxHealth);
    }

    public void Heal(int amount)
    {
        _currentHealth = Mathf.Clamp(_currentHealth + amount, 0, maxHealth);
    }
}

