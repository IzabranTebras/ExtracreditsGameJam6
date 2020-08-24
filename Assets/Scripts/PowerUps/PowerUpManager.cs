using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(StatusScript))]

public class PowerUpManager : MonoBehaviour
{
    public AbstractSkill normalShot;
    public AbstractSkill supershot;

    public Sprite normalShotSprite;
    public Sprite multiShotSprite;

    public enum PowerUpID
    {
        Normal,
        Barrage,
        Invulnerability,
        Heal,
        Speed
    }

    PlayerController _controller;
    StatusScript _status;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<PlayerController>();
        _status = GetComponent<StatusScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PowerUpAction(PowerUpID id)
    {
        switch(id)
        {
            case PowerUpID.Normal:
                {
                    _controller.AddAmmo(10, normalShot);
                    FindObjectOfType<HUDManager>().ChangeAmmoImage(normalShotSprite);
                    break;
                }
            case PowerUpID.Barrage:
                {
                    _controller.AddAmmo(10,supershot);
                    FindObjectOfType<HUDManager>().ChangeAmmoImage(multiShotSprite);
                    break;
                }
            case PowerUpID.Heal:
                {
                    _status.Heal(10);
                    break;
                }
            case PowerUpID.Invulnerability:
                {
                    _status.setInvulnerable(10);
                    break;
                }
            case PowerUpID.Speed:
                {
                    _controller.IncreaseSpeed(0.5f, 10);
                    break;
                }
        }
    }
}
