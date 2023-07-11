using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AboutButtonBehavior : MonoBehaviour
{
    bool looking = false;
    public GameObject sectionOn;
    public GameObject sectionOff;
    public GameObject cubeOn;
    public GameObject cubeOff;
    public GameObject cubeOff2;
    // Update is called once per frame
    void Update()
    {
        if (Google.XR.Cardboard.Api.IsTriggerPressed && looking)
        {
            sectionOn.SetActive(true);
            sectionOff.SetActive(false);
            cubeOff.SetActive(false);
            cubeOff2.SetActive(false);
            cubeOn.SetActive(true);
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
