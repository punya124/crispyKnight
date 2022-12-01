using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float Movespeed = 6f;
    public CharacterController controller;
    public Transform dragonBody;
    public Transform dragonBodyMain;
    public GameObject xztracker;
    public Transform groundCheck;
    public float groundDist = 0.2f;
    public LayerMask groundMask;
    public Transform enemy;
    bool isGrounded;
    Vector3 move;

    public Animator anim;

    public float Health = 100f;
    public float Hunger = 50f;
    Vector3 rotZ;

    public Slider Healthslider;
    public Slider Hungerslider;
    public Slider AltSlider;

    public GameObject gameOver;

    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDist, groundMask);
        anim.SetBool("isGroundedAnim", isGrounded);

        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        float flight = Input.GetAxis("Flight");

        dragonBody.Rotate(Vector3.up * horizontal);
        dragonBodyMain.Rotate(rotZ);
        move = transform.up * flight * 0.4f + transform.forward * vertical;
        controller.Move(move * Movespeed * Time.deltaTime);

        anim.SetFloat("Vertical", vertical);

        if (isGrounded)
        {
            Movespeed = 30f;
            dragonBodyMain.localRotation = Quaternion.EulerAngles(Vector3.forward * 0);
        }
        else
        {
            Movespeed = 60f;
            dragonBodyMain.localRotation = Quaternion.EulerAngles(Vector3.forward * -horizontal/2);
        }

        xztracker.transform.position = new Vector3(this.transform.position.x, enemy.position.y, this.transform.position.z);

        if(Hunger >= 0)
        {
            
            Recover();
            Hunger -= Random.value/30;
        }
        
        if(Hunger > 100)
        {
            Hunger = 120;   
        }

        if(Health <= 0)
        {
            Debug.Log("Game Over");
            StartCoroutine(GameOver());
        }

        Healthslider.value = Health;
        Hungerslider.value = Hunger;
        //AltSlider.value = transform.position.y;
    }

    private void Recover()
    {
        if (Health< 100)
        {
            Health += Hunger / 1000;
            Hunger -= 0.05f;
        }
    }

    public void Hit()
    {
        Health-= Random.Range(3, 7) ;

        Debug.Log("OUCH! Health: " + Health);
    }

    IEnumerator GameOver()
    {
        gameOver.SetActive(true);
        yield return new WaitForSeconds(2);
        Health = 100;
        Hunger = 50;
        gameOver.SetActive(false);
        gameObject.GetComponent<Quest>().Quest3();
    }
}
