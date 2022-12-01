using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreyScript : MonoBehaviour
{
    public float Health = 10f;
    public float movementSpeed;
    public float t = 0;
    public GameObject foodItem;
    public GameObject player;
    CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = this.gameObject.GetComponent<CharacterController>();
        Health = Random.Range(8, 20);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        t++;
        

        RandomMove();
        if (t%10 == 0)
        {
                RandomRotate();
        }

        if (!controller.isGrounded)
        {
            controller.Move(-transform.up);
        }
        if (Health <= 0)
        {
            Instantiate(foodItem, new Vector3(transform.position.x, transform.position.y + 5f, transform.position.z), transform.rotation);
            player.GetComponent<Quest>().PreyKills++;
            Destroy(gameObject);
        }
        if(transform.position.y <= -1)
        {
            Destroy(gameObject);
        }
    }
    private void OnParticleCollision(GameObject other)
    {
        if (other.name == "FlameThrower")
        {
            Health -= 1;
            Debug.Log("Health: " + Health);
        }
        if (other.name == "FireBall")
        {
            Health -= 5;
            Debug.Log("Health: " + Health);
        }
    }

    void RandomMove()
    {
        controller.Move(transform.forward * movementSpeed * Time.deltaTime);
    }

    void RandomRotate()
    {
        float yturndirection = Random.Range(-1, 1);
        transform.Rotate(0, 10f * yturndirection, 0);
    }
}
