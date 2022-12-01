using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killextras : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!this.GetComponent<ParticleSystem>().IsAlive())
        {
            this.transform.parent.gameObject.layer = 0;
            Destroy(this.gameObject);
        }
    }
}
