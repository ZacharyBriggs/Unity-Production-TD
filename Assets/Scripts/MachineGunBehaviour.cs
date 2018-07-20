
using UnityEngine;

public class MachineGunBehaviour : MonoBehaviour
{
    [SerializeField]
    protected WeaponCooldown _Cooldown;
    public GameEvent OnShootEvent;

    public int Damage;
    public float Range;

    protected IDamageable Target;

    private LineRenderer line;

    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.alignment = LineAlignment.Local;
    }

    [ContextMenu("shoot")]
    protected virtual void Shoot()
    {
        if (_Cooldown.CanShoot)//if we can shoot then shoot
            _Cooldown.StartCooldown(this);

        if (Target == null) //if we dont' have a target just return;
            return;

        Target.TakeDamage(Damage);
    }
}
