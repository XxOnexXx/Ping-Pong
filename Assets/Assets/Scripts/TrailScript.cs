using UnityEngine;

public class TrailScript : MonoBehaviour
{
    [SerializeField] GameObject[] ballTrail;
    [SerializeField] float startTimer;
    [SerializeField] float timeBwSpawns;
    void Start()
    {
        
    }


    void Update()
    {
        if (timeBwSpawns <= 0)
        {
            SpawnTrail();
            timeBwSpawns = startTimer;
            

        }
        else
        {
            timeBwSpawns -= Time.deltaTime;
        }
    }

    void SpawnTrail()
    {
        int rand = Random.Range(0, ballTrail.Length);
        GameObject trail = Instantiate(ballTrail[rand], transform.position, Quaternion.identity);
        Destroy(trail, 1.15f);
    }
}
