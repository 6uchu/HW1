using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 10f;

    Rigidbody rb;
    Vector3 targetPos;
    bool moving = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        targetPos = transform.position;
    }

    void Update()
    {
        if (Mouse.current.rightButton.wasPressedThisFrame)
        {
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                targetPos = hit.point;
                moving = true;
            }
        }
    }

    void FixedUpdate()
    {
        if (!moving) return;

        Vector3 dir = (targetPos - rb.position);
        dir.y = 0;

        if (dir.magnitude < 0.1f)
        {
            moving = false;
            return;
        }

        dir.Normalize();

        Quaternion targetRot = Quaternion.LookRotation(dir);
        rb.rotation = Quaternion.Slerp(
            rb.rotation,
            targetRot,
            rotationSpeed * Time.fixedDeltaTime
        );

        rb.MovePosition(rb.position + dir * speed * Time.fixedDeltaTime);
    }
}