using UnityEngine;
using System.Collections.Generic;

public class SlimeStickSystem : MonoBehaviour
{
    public float radiusMultiplier = 0.6f;

    List<Transform> stuckObjects = new List<Transform>();

    void Update()
    {
        foreach (var obj in stuckObjects)
        {
            obj.localPosition += new Vector3(
                Mathf.Sin(Time.time * 5f) * 0.002f,
                0,
                Mathf.Cos(Time.time * 5f) * 0.002f
            );
        }
    }
    public void Stick(Transform obj, Vector3 hitDirection)
    {
        obj.SetParent(transform);

        Collider col = obj.GetComponent<Collider>();
        if (col) col.enabled = false;

        stuckObjects.Add(obj);

        PlaceObject(obj, hitDirection);
    }

    void PlaceObject(Transform obj, Vector3 dir)
    {
        dir += new Vector3(
        Random.Range(-0.2f, 0.2f),
        0,
        Random.Range(-0.2f, 0.2f)
        );
        
        dir.Normalize();

        float radius = transform.localScale.x * radiusMultiplier;

        Vector3 offset = dir * radius;

        obj.localPosition = offset;

        // Make it face outward slightly (important for feel)
        obj.rotation = Quaternion.Euler(
        Random.Range(0, 360),
        Random.Range(0, 360),
        Random.Range(0, 360)
        );
    }
}