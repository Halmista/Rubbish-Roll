using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public Vector3 baseOffset = new Vector3(0f, 3f, -5f);

    public float followSpeed = 5f;

    private Quaternion fixedRotation;

    void Start()
    {
        fixedRotation = transform.rotation;
    }

    void LateUpdate()
    {
        if (target == null) return;

        float size = target.localScale.x;

        // Pull camera back as slime grows
        float pullback = Mathf.Max(0, size - 1f);

        Vector3 dynamicOffset = new Vector3(
            baseOffset.x,
            baseOffset.y + pullback * 0.5f,
            baseOffset.z - pullback * 1.5f
        );

        Vector3 desiredPosition =
            target.position + dynamicOffset;

        transform.position = Vector3.Lerp(
            transform.position,
            desiredPosition,
            followSpeed * Time.deltaTime
        );

        transform.rotation = fixedRotation;
    }
}