using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float height = 8f;
    public float distance = 10f;

    void LateUpdate()
    {
        float size = target.localScale.x;

        Vector3 offset = new Vector3(
            0,
            height + size * 0.8f,
            -(distance + size)
        );

        transform.position = target.position + offset;
        transform.LookAt(target);
    }

   




}