using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject trashPrefab;
    public GameObject slime;

    [SerializeField]
    private int maxTrash = 8;

    [SerializeField]
    private int currentTrashCount;

    [SerializeField]
    private int score;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentTrashCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        while(currentTrashCount < maxTrash)
        {
            SpawnTrash();
        }
    }

    public void SpawnTrash()
    {

        float slimePositionX;
        float trashPositionX;
        float slimePositionZ;
        float trashPositionZ;



        slimePositionX = slime.transform.position.x;

        trashPositionX = Random.Range(-5f, 5f);
        while(trashPositionX > -1 &&  trashPositionX < 1)
        {
            trashPositionX = Random.Range(-5f, 5f);
        }



        slimePositionZ = slime.transform.position.z;

        trashPositionZ = Random.Range(-5f, 5f);
        while (trashPositionZ > -1 && trashPositionZ < 1)
        {
            trashPositionZ = Random.Range(-5f, 5f);
        }


        Vector3 trashSpawnPosition = new Vector3(trashPositionX, 0.3f, trashPositionZ);

        Quaternion trashRotation = Quaternion.Euler(0, Random.Range(0f, 360f), 0);

        Instantiate(trashPrefab, trashSpawnPosition, trashRotation);

        currentTrashCount++;


    }


    public void AddPoints()
    {
        score++;
    }

    public void AbsorbedTrash()
    {
        currentTrashCount--;
        AddPoints();
        SpawnTrash();

    }
}
