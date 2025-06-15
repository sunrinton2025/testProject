using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    Vector2 axis;
    public Vector2 GetAxis()
    {
        return axis;
    }

    void OnMove(InputValue value)
    {
        axis = value.Get<Vector2>();
    }
}
