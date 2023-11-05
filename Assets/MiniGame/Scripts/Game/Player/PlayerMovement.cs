using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
  
    private Rigidbody2D rb;
    private Vector2 movementDirection;
    private Animator anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()//Або можна використати нову систему вводу, яку в подальшому і планую використовувати(наприклад стрільба)
    {
        movementDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        ActivateMovingAnimation();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movementDirection * moveSpeed * Time.fixedDeltaTime);
    }

    private const string NameWalkingBoolAnim = "Walking";
    private void ActivateMovingAnimation()
    {
        if (movementDirection != Vector2.zero)
        {
            anim.SetBool(NameWalkingBoolAnim, true);
        }
        else
        {
            anim.SetBool(NameWalkingBoolAnim, false);
        }
    }
}
