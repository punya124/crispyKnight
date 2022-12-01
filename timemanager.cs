using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timemanager : MonoBehaviour
{
    private float time;
    public GameObject prefab;
    public GameObject prefabParent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time++;
        if (time % 50 == 0 && prefabParent.transform.childCount <= 20)
        {
            Vector3 RandomPos = new Vector3(Random.Range(-800, 800), 400, Random.Range(-500, 500));

            RaycastHit hit;
            if(Physics.Raycast(RandomPos, Vector3.down, out hit))
            {
                Vector3 spawnpoint = new Vector3 (hit.point.x, hit.point.y + 1, hit.point.z);
                Instantiate(prefab, spawnpoint, transform.rotation, prefabParent.transform);
            }
        }
    }
}
