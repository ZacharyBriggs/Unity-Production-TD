using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "WeaponCooldown")]
public class WeaponCooldown : FloatVariable
{    
    [SerializeField]
    public float CurrentTime
    {
        get { return _value; }
        set
        {
            _value = value;
            if (onValueChanged != null)
                onValueChanged();
        }
    }



    //if WeaponCoolDown.CanShoot
    //then shoot
    public bool CanShoot
    {
        get { return !isShooting; }
    }

    public bool isShooting;
    private void OnEnable()
    {
        CurrentTime = 0;
    }

    public void StartCooldown(MonoBehaviour mb)
    {
        if (isShooting)
            return;
        mb.StartCoroutine(CountDown());
    }

    public IEnumerator CountDown()
    {
        float ct = _MaxValue;
        while (ct >= 0)
        {
            isShooting = true;
            ct -= Time.deltaTime;
            CurrentTime = ct;
            
            yield return null;
        }

        CurrentTime = 0;
        isShooting = false;
    }
}
