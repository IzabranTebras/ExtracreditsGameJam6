using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class StatusScript : MonoBehaviour
{

    public int maxHealth = 10;

    private int _currentHealth;
    public int currentHealth { get { return _currentHealth; } }

    private PlayerController _controller = null;

    void Start()
    {
        _currentHealth = maxHealth;
        _controller = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int amount, Transform attackerPosition = null)
    {
        _currentHealth = Mathf.Clamp(_currentHealth - amount, 0, maxHealth);

        if (attackerPosition)
        {
            _controller.AddImpulse(attackerPosition);
        }
    }

    public void Heal(int amount)
    {
        _currentHealth = Mathf.Clamp(_currentHealth + amount, 0, maxHealth);
    }
}

