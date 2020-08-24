using DG.Tweening;
using System;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class StatusScript : MonoBehaviour
{

    public int maxHealth = 10;
    public float timeToDestroyAfterDeath = 1.0f;

    [Header("FX")]
    public ParticleSystem deathFX = null;
    public ParticleSystem impactFX = null;
    public ParticleSystem invulnerableFX = null;
    public float timeToDestroyFX = 5.0f;

    private int _currentHealth;
    public int currentHealth { get { return _currentHealth; } }

    private PlayerController _controller = null;
    private AIController _aiController = null;

    bool invulnerable;
    float invulnerableTimer;
    float invAfterHit = 0.5f; //invulnerability for 1 second after a hit;
    void Awake()
    {
        _currentHealth = maxHealth;
        _controller = GetComponent<PlayerController>();
        _aiController = GetComponent<AIController>();
    }

    private void Update()
    {
        if (invulnerable)
        {
            invulnerableTimer -= Time.deltaTime;
            if (invulnerableTimer < 0)
            {
                invulnerable = false;
                invulnerableFX.Stop();
            }
        }
    }
    public void TakeDamage(int amount, Vector3 attackerForward)
    {
        if(_controller) _controller.AddImpulse(attackerForward);
        TakeDamage(amount);
    }

    public void TakeDamage(int amount)
    {
        if (invulnerable && amount < 100) return;   //if damage is too big (deathfloor) invulnebility dont work
        _currentHealth = Mathf.Clamp(_currentHealth - amount, 0, maxHealth);
        if(_currentHealth == 0)
        {
            Death();
        }
        else
        {
            impactFX.Play();
        }
    }

    public void Heal(int amount)
    {
        _currentHealth = Mathf.Clamp(_currentHealth + amount, 0, maxHealth);
    }

    private void Death()
    {
        deathFX.transform.parent = null;
        deathFX.Play();
        Destroy(deathFX.gameObject, timeToDestroyFX);

        if (gameObject.layer == 9)
        {
            _aiController.Death();
            Destroy(gameObject, timeToDestroyAfterDeath);
            EnemySpawner.enemyNumber--;
            FindObjectOfType<HUDManager>().IncreaseScore(5);
        }
        else
        {
            FindObjectOfType<HUDManager>().GameOver();
            _controller.GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    internal void setInvulnerable(float time)
    {
        invulnerable= true;
        invulnerableTimer = time;
        invulnerableFX.Play();
    }
}

