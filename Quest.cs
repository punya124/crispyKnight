using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[System.Serializable]
public class Quest : MonoBehaviour
{
    public string Title;
    public string Description;

    public GameObject player;
    public string LevelAt = "Quest1";

    public Text titledisplay;
    public Text descriptiondisplay;
    public Animator qdispanim;

    public int PreyKills;
    public GameObject playerHome;
    public GameObject enemy;
    public GameObject pointer;
    public GameObject pointerLookAt;
    public Animator qCompAnim;
    public GameObject panel;
    public GameObject panel2;
    private void Start()
    {
        if (PlayerPrefs.HasKey("LevelAt"))
        {
            Invoke(PlayerPrefs.GetString("LevelAt"), 0f);
        }
        else
        {
            Invoke(LevelAt, 0.1f);
        }
        qdispanim = descriptiondisplay.GetComponentInParent<Animator>();
    }

    private void Update()
    {
        PlayerPrefs.SetString("LevelAt", LevelAt);
        titledisplay.text = Title;
        descriptiondisplay.text = Description;
        if(LevelAt == "Quest1" && PreyKills == 1)
        {
            qCompAnim.Play("UIAnimation", 0, 0.0f);
            qdispanim.enabled = false;
            LevelAt = "Quest2";
            Quest2();
        }

        if(LevelAt == "Quest2" && Vector3.Distance(playerHome.transform.position, player.transform.position) <= 100f)
        {
            qCompAnim.Play("UIAnimation", 0, 0.0f);
            qdispanim.enabled = false;
            
            LevelAt = "Quest3";
            Quest3();
        }

        if(LevelAt == "Quest4" && !enemy.active)
        {
            qCompAnim.Play("UIAnimation", 0, 0.0f);
            PlayerPrefs.DeleteAll();
            Quest5();
        }

        pointer.transform.LookAt(pointerLookAt.transform);
    }

    public void Quest1()
    {
        LevelAt = "Quest1";
        Title = "Find and Kill prey";
        Description = "Fly around and look for any wildlife that can provide you with an appetising meal. Once you spot your meal of choice, cook it with your breath and enjoy the taste of success.";
        PreyKills = 0;
        pointerLookAt = GameObject.FindGameObjectWithTag("wildlife");
    }

    public void Quest2()
    {
        LevelAt = "Quest2";
        Title = "Return Home";
        Description = "Go home and tell Princess Cecilia about today's adventures!";
        pointerLookAt = playerHome;
        qdispanim.enabled = true;
    }

    public void Quest3()
    {
        LevelAt = "Quest3";
        panel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        enemy.SetActive(false);
    }

    public void Quest4()
    {
        Cursor.lockState = CursorLockMode.Locked;
        panel.SetActive(false);
        enemy.transform.position = new Vector3(179.4f, 79.3f, 3.1f);
        LevelAt = "Quest4";
        Title = "Protect the princess";
        Description = "A knight has appeared to capture the princess. KILL HIM!";
        enemy.SetActive(true);
        pointerLookAt = enemy;
        qdispanim.enabled = true;
    }

    public void Quest5()
    {
        panel2.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }

    public void EndGame()
    {
        Debug.Log("Application Quit");
        Application.Quit();
    }
}
