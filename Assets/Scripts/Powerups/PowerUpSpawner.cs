using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject dashCDR;
    public GameObject fireRateUp;
    public GameObject speedBoost;
    public GameObject flying;
    public GameObject healthUp;
    List<GameObject> prefabList = new List<GameObject>();
    private bool isSpawning = false;
    private int spawnDuration = 5;

    void Start()
    {
        prefabList.Add(dashCDR);
        prefabList.Add(fireRateUp);
        prefabList.Add(speedBoost);
        prefabList.Add(flying);
        prefabList.Add(healthUp);
    }

    // Update is called once per frame
    void Update()
    {
        if(!isSpawning){
            StartCoroutine(spawn());
        }
        

    }

    private IEnumerator spawn() {

        if(transform.childCount == 0){
            isSpawning = true;
            yield return new WaitForSeconds(spawnDuration);
            int prefabIndex = UnityEngine.Random.Range(0,5);
            GameObject powerup = Instantiate(prefabList[prefabIndex]);
            powerup.transform.parent = gameObject.transform;
            powerup.transform.position = gameObject.transform.position;
            isSpawning = false;
        }

    }
}
