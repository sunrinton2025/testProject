using minyee2913.Utils;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    HealthObject health;
    RangeController range;

    void Start()
    {
        health = GetComponent<HealthObject>();
        range = GetComponent<RangeController>();

        health.OnDamage(onDam);
        health.OnGiveDamage(onGive);
    }

    void onGive(HealthObject.OnGiveDamageEv ev)
    {
    }

    void onDam(HealthObject.OnDamageEv ev)
    {
        ev.cancel = true; //데미지 판정 취소
    }

    void Attack()
    {
        foreach (Transform target in range.GetHitInRange(range.GetRange("attack1"), LayerMask.GetMask("enemy")))
        {
            HealthObject hp = target.GetComponent<HealthObject>();

            if (hp != null)
            {
                hp.GetDamage(10, health, HealthObject.Cause.Melee);
            }
        }
    }
}
