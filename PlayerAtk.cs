using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtk : MonoBehaviour
{
    public GameObject flamebreathparticles;
    public GameObject flamebreathparticles2;
    public GameObject focus;
    public GameObject xztrack;
    public GameObject shield;

    private AudioSource audioSrc;
    public AudioClip audioClip;
    public AudioClip audioClip2;

    public GameObject target;

    Cinemachine.CinemachineImpulseSource source;

    private void Start()
    {
        flamebreathparticles.SetActive(false);
        flamebreathparticles2.SetActive(false);
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.S))
        {
            shield.SetActive(true);
            flamebreathparticles.SetActive(false);
            flamebreathparticles2.SetActive(false);
        }
        else{
            shield.SetActive(false);

            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("LSlash");
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                Debug.Log("RSlash");
            }

            if (!flamebreathparticles.GetComponent<ParticleSystem>().IsAlive() && !flamebreathparticles2.GetComponent<ParticleSystem>().IsAlive())
            {
                xztrack.layer = 0;
                xztrack.GetComponent<Collider>().enabled = false;
                flamebreathparticles.transform.rotation = focus.transform.rotation;
                flamebreathparticles2.transform.LookAt(target.transform);
                if (Input.GetButtonDown("Fire1"))
                {
                    Shoot();
                    xztrack.GetComponent<Collider>().enabled = true;
                    xztrack.layer = 6;
                    audioSrc.clip = audioClip;
                    audioSrc.PlayDelayed(0.75f);
                }
                if (Input.GetButtonDown("Fire2"))
                {
                    Shoot2();
                    xztrack.layer = 6;
                    xztrack.GetComponent<Collider>().enabled = true;
                    audioSrc.PlayOneShot(audioClip2);
                }
            }
        }

        

    }

    void Shoot()
    {
        flamebreathparticles.GetComponent<ParticleSystem>().playOnAwake = true;
        flamebreathparticles.SetActive(false);
        flamebreathparticles.SetActive(true);
        source = flamebreathparticles.GetComponent<Cinemachine.CinemachineImpulseSource>();
        source.GenerateImpulse(Camera.main.transform.forward);
    }

    void Shoot2()
    {
        flamebreathparticles2.GetComponent<ParticleSystem>().playOnAwake = true;
        flamebreathparticles2.SetActive(false);
        flamebreathparticles2.SetActive(true);
        source = flamebreathparticles2.GetComponent<Cinemachine.CinemachineImpulseSource>();
        source.GenerateImpulse(Camera.main.transform.forward);
    }
}
