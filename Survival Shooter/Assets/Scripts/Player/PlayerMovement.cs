using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;

    private Vector3 movement;
    private Animator animator;
    private Rigidbody player;
    private int floorMask;
    private float cameraRayLength = 100f;

    private void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");
        animator = GetComponent<Animator>();
        player = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal"); // -1 0 1
        float v = Input.GetAxisRaw("Vertical");
        Move(h, v);
        Turn();
        Animate(h, v);
    }

    private void Move(float h, float v)
    {
        movement.Set(h, 0f, v);
        movement = movement.normalized * speed * Time.deltaTime; // normalized to avoid benefit from going diagonally
        player.MovePosition(transform.position + movement);
    }

    private void Turn()
    {
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorHit;

        // if you've hit something with ray
        if (Physics.Raycast(cameraRay, out floorHit, cameraRayLength, floorMask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0f;

            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            player.MoveRotation(newRotation);
        }
    }

    private void Animate(float h, float v)
    {
        bool walking = h != 0f || v != 0f;
        animator.SetBool("IsWalking", walking);
    }
}
