using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSave : MonoBehaviour
{
    private int num = 1;
    public void LoadG()
    {
        SceneManager.LoadScene(2);
    }

    public void NewG()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(1);
    }
}
