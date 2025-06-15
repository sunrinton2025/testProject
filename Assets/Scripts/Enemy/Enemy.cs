using UnityEngine;
using minyee2913.Utils;
using System;

public class Enemy : MonoBehaviour
{
    public Vector3 playerPos;
    public GameObject player;
    public HealthObject health;
    public RangeController range;
    public Vector3 moveDir;
    public float moveSpeed;
    public float attackRange;
    public Cooldown atkCool = new(1);
    public float damage;
    void Awake()
    {
        player = GameObject.Find("Player");
        range = GetComponent<RangeController>();
        health = GetComponent<HealthObject>();
    }
    void Update()
    {
        playerPos = player.transform.position;
        moveDir = (playerPos - this.transform.position).normalized;
    }

    void FixedUpdate()
    {
        EnemyMove(moveDir,moveSpeed);
    }
    void EnemyMove(Vector3 moveDir, float moveSpeed)
    {
        if ((playerPos - this.transform.position).magnitude > attackRange)
        {
            transform.Translate(moveDir * moveSpeed * Time.deltaTime);
        }
        else
        {
            Attack();
        }
    }
    void Attack()
    {
        if (atkCool.IsIn())
            return;

        atkCool.time = 0.4f;
        atkCool.Start();

        CamEffector.current.Shake(1);
        foreach (Transform target in range.GetHitInRange2D(range.GetRange("enemyRange"), LayerMask.GetMask("player")))
        {
            HealthObject hp = target.GetComponent<HealthObject>();

            if (hp != null)
            {
                hp.GetDamage((int)damage, health, HealthObject.Cause.Melee);
            }
        }
    }
}
