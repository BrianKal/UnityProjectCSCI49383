using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("goToMenu", 5f);
    }
    void goToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
