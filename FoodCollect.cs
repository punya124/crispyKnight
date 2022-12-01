using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCollect : MonoBehaviour
{

    public GameObject player;
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.transform.name);
        if (collision.gameObject.transform.name == "dragon")
        {
            player = collision.gameObject;
            player.GetComponentInParent<PlayerMovement>().Hunger += 50;
            Destroy(gameObject);
        }
    }
}
