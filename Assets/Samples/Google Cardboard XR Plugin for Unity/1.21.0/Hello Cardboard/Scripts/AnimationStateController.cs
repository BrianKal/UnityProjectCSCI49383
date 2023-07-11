using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationStateController : MonoBehaviour
{
    public AudioSource teleportSound;
    Animator animator;
    public AudioSource deathSound;
    bool Looking = false;
    bool isDead = false;
    public AudioSource enemyShootingSound;
    bool enemyShootingSoundPlaying = false;
    float timer = 0f;
    bool playerDeathSoundPlayed = false;
    AudioSource[] allAudios;
    public AudioSource playerDeathSound;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInParent<Animator>();
        teleportSound.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead && !enemyShootingSoundPlaying)
        {
            timer += Time.deltaTime;
            if (timer >= 14.107f)
            {
                PlaySound();
                timer = -1000f;
            }
        }
        if (Looking && Google.XR.Cardboard.Api.IsTriggerPressed)
        {
            animator.SetBool("isDead", true);
            isDead = true;
            StopSound();
            deathSound.Play();
            ChangeLayer(transform.parent, LayerMask.NameToLayer("Ignore Raycast"));
            Invoke("DeleteDeadEnemy", 7f);
        }
        if (enemyShootingSoundPlaying && GameManager.isShieldActive == false && !playerDeathSoundPlayed)
        {
            Invoke("KillPlayer", 0.2f);
        }
    }

    public void OnPointerEnter()
    {
        Looking = true;
    }
    public void OnPointerExit()
    {
        Looking = false;
    }
    void PlaySound()
    {
        enemyShootingSound.Play();
        enemyShootingSoundPlaying = true;
    }
    void StopSound()
    {
        enemyShootingSound.Stop();
        enemyShootingSoundPlaying = false;
    }
    void ChangeLayer(Transform transform, int layer)
    {
        transform.gameObject.layer = layer;
        foreach (Transform child in transform)
        {
            ChangeLayer(child, layer);
        }
    }
    void DeleteDeadEnemy()
    {
        Destroy(transform.parent.gameObject);
    }
    void KillPlayer()
    {
        allAudios = FindObjectsOfType<AudioSource>();
        foreach (AudioSource audio in allAudios)
        {
            audio.Stop();
        }
        playerDeathSound.Play();
        playerDeathSoundPlayed = true;
        Invoke("deathScreen", 2f);
    }
    void deathScreen()
    {
        SceneManager.LoadScene("GameOver");
    }
}
