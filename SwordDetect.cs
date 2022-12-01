using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordDetect : MonoBehaviour
{
    Cinemachine.CinemachineImpulseSource source;

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log(other.name);
        if (other.name.ToLower() == "dragon")
        {
            other.GetComponentInParent<PlayerMovement>().Hit();
            source = this.GetComponent<Cinemachine.CinemachineImpulseSource>();
            source.GenerateImpulse(Camera.main.transform.forward);
        }
    }
}
