using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameCatch : MonoBehaviour
{
    public string tempName;
    public GameObject flamePrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.tag == "flammable")
        {
            if(other.name != tempName)
            {
                tempName = other.name;
                Instantiate(flamePrefab, other.transform);
                other.layer = 6;
            }
        }
    }
}
