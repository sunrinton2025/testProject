using System.IO.Compression;
using minyee2913.Utils;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerBattle : MonoBehaviour
{
    public StatController stat;
    public HealthObject health;
    public RangeController range;
    public PlayerAnimator animator;
    public Cooldown atkCool = new(1);
    int atkType = 0;
    [SerializeField]
    Slider hpSlider;
    void Awake()
    {
        health = GetComponent<HealthObject>();
        stat = GetComponent<StatController>();
        range = GetComponent<RangeController>();
        animator = GetComponent<PlayerAnimator>();

        health.OnDamageFinal(OnFinalDam);
    }

    void Update()
    {
        hpSlider.value = health.Rate;
        if (animator.direction < 0)
        {
            hpSlider.transform.localScale = new Vector2(-Mathf.Abs(hpSlider.transform.localScale.x), hpSlider.transform.localScale.y);
        } else
            hpSlider.transform.localScale = new Vector2(Mathf.Abs(hpSlider.transform.localScale.x), hpSlider.transform.localScale.y);
    }

    void OnAttack(InputValue value)
    {
        switch (atkType)
        {
            case 0:
                Attack1();
                break;
            case 1:
                Attack2();
                break;
            default:
                atkType = 0;
                OnAttack(value);
                break;
        }
    }

    void OnFinalDam(HealthObject.OnDamageFinalEv ev)
    {
        IndicatorManager.Instance.GenerateText(ev.Damage.ToString(), transform.position + new Vector3(Random.Range(-1f, 1f), 1), Color.red);
    }

    void Attack1()
    {
        if (atkCool.IsIn())
            return;

        atkCool.time = 0.4f;
        atkCool.Start();

        atkType++;

        CamEffector.current.Shake(3);

        float damage = stat.GetResultValue("attackDamage") * 1.2f;
        foreach (Transform target in range.GetHitInRange2D(range.GetRange("attack1"), LayerMask.GetMask("enemy")))
        {
            HealthObject hp = target.GetComponent<HealthObject>();

            if (hp != null)
            {
                hp.GetDamage((int)damage, health, HealthObject.Cause.Melee);
            }
        }
    }

    void Attack2()
    {
        if (atkCool.IsIn())
            return;

        atkCool.time = 0.6f;
        atkCool.Start();

        atkType++;

        CamEffector.current.Shake(6);

        float damage = stat.GetResultValue("attackDamage") * 1.8f;
        foreach (Transform target in range.GetHitInRange2D(range.GetRange("attack1"), LayerMask.GetMask("enemy")))
        {
            HealthObject hp = target.GetComponent<HealthObject>();

            if (hp != null)
            {
                hp.GetDamage((int)damage, health, HealthObject.Cause.Melee);
            }
        }
    }
}
