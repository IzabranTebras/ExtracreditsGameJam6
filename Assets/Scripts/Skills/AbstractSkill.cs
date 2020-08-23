using UnityEngine;

public abstract class AbstractSkill : ScriptableObject
{
    public bool Activated { get; private set; }

    public void Init()
    {
        Activated = false;
    }

    public virtual void Activate(PlayerController controller)
    {
        Activated = true;
    }

    public virtual void Deactivate()
    {
        Activated = false;
    }
}
