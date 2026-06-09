using Unity.VisualScripting;
using UnityEngine;

public class Trash : MonoBehaviour
{
    public int value;

    public float requiredSize;

    public GameObject slime;
    public SlimeController slimeData;

    public void Start()
    {
        slime = GameObject.Find("Slime");
        slimeData = slime.GetComponent<SlimeController>();
        SetValue(slimeData.collected);
    }

    private void SetValue(int slimeScore)
    {

            value = Random.Range(slimeScore -1, slimeScore + 2);
        Debug.Log("setValue");
            requiredSize = (1 + (0.1f * value));


        transform.localScale = Vector3.one * requiredSize;
    }
}