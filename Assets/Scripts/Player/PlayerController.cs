using minyee2913.Utils;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    HealthObject health;
    RangeController range;
    StatController stat;
    Cooldown atkCool = new(1);

    void Start()
    {
        health = GetComponent<HealthObject>();
        range = GetComponent<RangeController>();
        stat = GetComponent<StatController>();

        health.OnDamage(onDam);
        health.OnGiveDamage(onGive);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Attack();
    }

    void onGive(HealthObject.OnGiveDamageEv ev)
    {
        IndicatorManager.Instance.GenerateText(ev.Damage.ToString(), ev.target.transform.position, Color.white);
    }

    void onDam(HealthObject.OnDamageEv ev)
    {
    }

    void Attack()
    {
        if (atkCool.IsIn())
            return;

        atkCool.Start();
        
        stat.AddBuf("buf1", new Buf
        {
            Comment = "공격력 30% 증가",
            key = "attackDamage",
            mathType = StatMathType.Increase,
            value = 30
        });

        stat.RemoveBuf("buf1");

        stat.Calc("attackDamage");

        SoundManager.Instance.PlaySound("Effects/explode", 4, 1, 1);

        float damage = stat.GetResultValue("attackDamage") * 1.2f;
        foreach (Transform target in range.GetHitInRange2D(range.GetRange("attack1"), LayerMask.GetMask("enemy")))
        {
            Debug.Log(target);
            HealthObject hp = target.GetComponent<HealthObject>();

            if (hp != null)
            {
                hp.GetDamage((int)damage, health, HealthObject.Cause.Melee);
            }
        }
    }
}
