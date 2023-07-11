using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootGun : MonoBehaviour
{
    public GameObject prefab;
    public Transform shootPoint;
    AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {
        UpdateShootPoint();
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Google.XR.Cardboard.Api.IsTriggerPressed)
        {
            UpdateShootPoint();
            Shoot();
        }
    }

    void UpdateShootPoint()
    {
        shootPoint = transform.Find("ShootPoint");
    }

    void Shoot()
    {
        GameObject laser = Instantiate(prefab, shootPoint.position, shootPoint.rotation);
        Destroy(laser, 0.3f);
        sound.Play();
    }
}
