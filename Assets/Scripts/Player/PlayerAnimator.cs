using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField]
    Animator animator;
    [SerializeField]
    Transform character;

    public int direction;

    public void SetDirection(int dir)
    {
        if (dir == 0)
            return;
            
        direction = dir;

        character.transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x) * dir, transform.localScale.y);
    }
}
