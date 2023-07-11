using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBehavior : MonoBehaviour
{
    public GameObject player;
    GameObject shield;
    public GameObject shieldPrefab;
    public AudioSource shieldActivateSound;
    public AudioSource shieldDeactivateSound;
    float shieldTimer = 0f;
    bool outOfBattery = false;
    public GameObject batteryText;

    void OnPointerEnter()
    {
        if (GameManager.isShieldActive)
        {
            GameManager.isShieldActive = false;
            Deactivate();
        }
        else if (shieldTimer < 60f)
        {
            GameManager.isShieldActive = true;
            Activate();
        }
    }

    private void Start()
    {
        GameManager.isShieldActive = false;
    }

    void Update()
    {
        if (GameManager.isShieldActive)
        {
            shieldTimer += Time.deltaTime;
            if (shieldTimer >= 60f && !outOfBattery)
            {
                GameManager.isShieldActive = false;
                Deactivate();
            }
        }
        UpdateBatteryText();
    }

    void Activate()
    {
        shield = Instantiate(shieldPrefab, player.transform.position, Quaternion.identity);
        shieldActivateSound.Play();
    }

    void Deactivate()
    {
        Destroy(shield);
        shieldDeactivateSound.Play();
    }
    void UpdateBatteryText()
    {
        TextMesh batteryTextMesh = batteryText.GetComponent<TextMesh>();
        float timeLeft = Mathf.Max(0f, 60f - shieldTimer);
        batteryTextMesh.text = Mathf.CeilToInt(timeLeft).ToString() + "s";
    }
}