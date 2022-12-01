using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    public float Health = 100f;
    public GameObject checker;
    public LayerMask particleLayer;
    public CharacterController characterController;
    float radius = 120f;
    Collider[] NearFires;
    public GameObject dragon;
    public Transform dragontrack;
    public Image dmgScreen;
    public Slider Healthslider;
    public GameObject attackanim;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Health <= 0)
        {
            characterController.gameObject.SetActive(false);

        }

        NearFires = Physics.OverlapSphere(checker.transform.position, radius, particleLayer);
        if (NearFires.Length > 0)
        {
            Defence();
        }
        else {
            Attack();
        }

        if (!characterController.isGrounded)
        {
            characterController.Move(-transform.up);
        }

        Healthslider.value = Health;

    }

    private void OnParticleCollision(GameObject other)
    {
        if(other.name == "FlameThrower" || other.layer == 6)
        {
            Health -= 1;
            Debug.Log("Health: " + Health);
        }

        if (other.name == "FireBall" || other.layer == 6)
        {
            Health -= 2;
            Debug.Log("Health: " + Health);
        }
    }

    void Defence()
    {
        this.transform.LookAt(new Vector3(NearFires[0].gameObject.transform.position.x, transform.position.y, NearFires[0].gameObject.transform.position.z));
        characterController.Move((-transform.forward * 20 * Time.deltaTime));
        anim.SetFloat("Velocity", -1);
    }

    void Attack()
    {
        Vector3 dragonPosRandomised = new Vector3(dragon.transform.position.x + Random.Range(-10, 10), dragon.transform.position.y + Random.Range(-10, 10), dragon.transform.position.z + Random.Range(-10, 10));

        this.transform.LookAt(new Vector3 (dragontrack.position.x, transform.position.y, dragontrack.position.z));

        if(Vector3.Distance(this.transform.position, dragontrack.transform.position) <= 100f)
        {
            if (!(attackanim.GetComponent<ParticleSystem>().isEmitting))
            {
                attackanim.transform.position = this.transform.position;
                attackanim.transform.LookAt(dragonPosRandomised);
                attackanim.SetActive(false);
                attackanim.GetComponent<ParticleSystem>().playOnAwake= true;
                attackanim.SetActive(true);
            }
            anim.SetFloat("Velocity", 0);
        }

        else
        {
            characterController.Move((transform.forward * 0.5f));
            anim.SetFloat("Velocity", 1);
        }
    }

    private void Awake()
    {
        Healthslider.gameObject.SetActive(true);
    }
}
