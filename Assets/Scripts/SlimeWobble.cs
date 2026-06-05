using UnityEngine;

public class SlimeWobble : MonoBehaviour
{
    public Transform parentSlime;

    public float wobbleAmount = 0.08f;
    public float wobbleSpeed = 6f;

    Vector3 baseScale;

    void Start()
    {
        baseScale = transform.localScale;
    }

    void Update()
    {
        float wobble = Mathf.Sin(Time.time * wobbleSpeed) * wobbleAmount;

        transform.localScale = new Vector3(
            baseScale.x + wobble,
            baseScale.y - wobble,
            baseScale.z + wobble
        );
    }
}