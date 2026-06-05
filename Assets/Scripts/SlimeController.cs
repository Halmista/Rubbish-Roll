using UnityEngine;

public class SlimeController : MonoBehaviour
{
    public float moveForce = 15f;

    private Rigidbody rb;

    int collected = 0;

    public SlimeStickSystem stickSystem;
    public float slimeSize = 1f;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 movement;

#if UNITY_EDITOR

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        movement = new Vector3(x, 0, z);

#else

        movement = new Vector3(
            Input.acceleration.x,
            0,
            Input.acceleration.y
        );

#endif

        rb.AddForce(movement * moveForce);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Trash>(out Trash trash))
        {
            if (slimeSize >= trash.requiredSize)
            {
                Vector3 dir = (other.transform.position - transform.position).normalized;

                stickSystem.Stick(other.transform, dir);

                Grow();
            }
        }
    }

    void Grow()
    {
        collected++;

        slimeSize += 0.1f;

        transform.localScale = Vector3.one * slimeSize;
    }
}