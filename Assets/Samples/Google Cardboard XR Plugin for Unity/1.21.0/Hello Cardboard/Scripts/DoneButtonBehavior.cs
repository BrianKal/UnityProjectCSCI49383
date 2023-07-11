using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoneButtonBehavior : MonoBehaviour
{
    bool looking = false;
    public GameObject sectionOn;
    public GameObject sectionOff;
    public GameObject cubeOn;
    public GameObject cubeOn2;
    public GameObject cubeOff;
    // Update is called once per frame
    void Update()
    {
        if (Google.XR.Cardboard.Api.IsTriggerPressed && looking)
        {
            sectionOn.SetActive(true);
            sectionOff.SetActive(false);
            cubeOff.SetActive(false);
            cubeOn.SetActive(true);
            cubeOn2.SetActive(true);
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
