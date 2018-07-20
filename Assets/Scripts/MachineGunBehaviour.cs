
using Cinemachine;
using UnityEngine;

public class MachineGunBehaviour : MonoBehaviour
{
    [SerializeField] protected WeaponCooldown _Cooldown;
    public GameEvent OnShootEvent;

    public int Damage;
    public float Range;

    protected IDamageable Target;
    [TagField] public string TargetTag = "Enemy";
    private LineRenderer line;

    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.alignment = LineAlignment.Local;
    }

    [ContextMenu("shoot")]
    protected virtual void Shoot()
    {

        if (_Cooldown.CanShoot) //if we can shoot then shoot
            _Cooldown.StartCooldown(this);
        else
            return;
        
        Debug.Log("shoot");
        OnShootEvent.Raise();
        RaycastHit hit;
        var camforwardcast = Camera.main.transform.forward * 1000;
        //todo:: we could set the linerenderer to exactly where it goes if we make it here
        if (Physics.Raycast(this.transform.position, camforwardcast, out hit))
        {
            if (hit.collider.gameObject.CompareTag(TargetTag))
                Target = hit.collider.gameObject.GetComponent<EnemyBehaviour>();

            if (Target == null) //if we dont' have a target just return;
                return;

            Target.TakeDamage(Damage);
        }
    }
}
