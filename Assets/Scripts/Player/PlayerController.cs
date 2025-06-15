using minyee2913.Utils;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerBattle))]
[RequireComponent(typeof(PlayerCamera))]
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(PlayerAnimator))]
public class PlayerController : MonoBehaviour
{
    public static PlayerController Local { get; private set; }
    public PlayerMovement movement;
    public PlayerBattle battle;
    public PlayerCamera cam;
    public PlayerInput input;
    public PlayerAnimator animator;

    void Awake()
    {
        movement = GetComponent<PlayerMovement>();
        battle = GetComponent<PlayerBattle>();
        cam = GetComponent<PlayerCamera>();
        input = GetComponent<PlayerInput>();
        animator = GetComponent<PlayerAnimator>();

        Local = this;
    }

    void Update()
    {
        cam.Follow();
    }

    void FixedUpdate()
    {
        float xInput = input.GetAxis().x;
        movement.ApplyMovement(new Vector2(xInput, 0) * Time.fixedDeltaTime);
        animator.SetDirection((int)xInput);
    }
}
