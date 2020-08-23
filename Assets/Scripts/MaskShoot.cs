using DG.Tweening;
using UnityEngine;

[CreateAssetMenu(menuName = "Skill/BasicShoot", fileName = "BasicShootSkill")]
public class MaskShoot : AbstractSkill
{
    [Header("Stats")]
    public int damage = 0;

    [Header("Projectile settings")]
    public float cadency = 0.0f;
    public int projectilesPerShot = 1;
    public float delayBetweenProjectiles = 0.3f;
    public GameObject projectile = null;
    public float projectileSpeed = 0.0f;

    private int currentProjectiles = 0;

    public override void Activate(PlayerController controller)
    {
        if (!Activated)
        {
            base.Activate(controller);

            currentProjectiles = projectilesPerShot;
            Shoot(controller);
        }
    }

    public override void Deactivate()
    {
        base.Deactivate();
    }

    private void Shoot(PlayerController controller)
    {
        GameObject maskGO = Instantiate(projectile, controller.shootPosition.position, controller.shootPosition.rotation);
        MaskProjectile maskProjectile = maskGO.GetComponent<MaskProjectile>();
        maskProjectile.speed = projectileSpeed;
        --currentProjectiles;

        if(currentProjectiles <= 0)
        {
            DOVirtual.DelayedCall(cadency, Deactivate);
        }
        else
        {
            DOVirtual.DelayedCall(delayBetweenProjectiles, () => Shoot(controller));
        }
    }
}
