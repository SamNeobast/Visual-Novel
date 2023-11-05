using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    private Rigidbody2D rb;
   private Camera cam;

    private Vector2 mousePosition;

    private void Start()
    {
        cam = FindFirstObjectByType<Camera>().GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        Vector2 lookDirection = mousePosition - rb.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }
}
