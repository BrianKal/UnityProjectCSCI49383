using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonBehavior : MonoBehaviour
{
    bool looking = false;

    // Update is called once per frame
    void Update()
    {
        if (Google.XR.Cardboard.Api.IsTriggerPressed && looking)
        {
            SceneManager.LoadScene("MyGame");
        }
    }

    public void OnPointerEnter()
    {
        looking = true;
    }

    public void OnPointerExit()
    {
        looking = false;
    }
}
