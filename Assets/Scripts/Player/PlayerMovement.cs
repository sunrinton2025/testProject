using minyee2913.Utils;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rigid;
    StatController stat;
    public float StopMove, jumpPower;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        stat = GetComponent<StatController>();
    }

    public void ApplyMovement(Vector2 moveDelta)
    {
        float speed = stat.GetResultValue("moveSpeed") * 0.01f;

        transform.Translate(moveDelta.normalized * speed);
    }

    void OnJump()
    {
        rigid.linearVelocityY = jumpPower;
    }
}
