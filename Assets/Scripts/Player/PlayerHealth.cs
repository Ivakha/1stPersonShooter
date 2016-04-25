using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    public Image damageImage;
    //public AudioClip deathClip;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);

    GameController gameController;
    Animator anim;
    AudioSource playerAudio;
    PlayerMovement playerMovement;
    PlayerShooting playerShooting;
    PlayerRotation playerRotation;
    Rigidbody rigidbody;
    
    bool isDead;
    bool damaged;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();
        playerMovement = GetComponent<PlayerMovement>();
        playerRotation = GetComponent<PlayerRotation>();
        playerShooting = GetComponentInChildren<PlayerShooting>();
        playerAudio = GetComponent<AudioSource>();
        rigidbody = GetComponent<Rigidbody>();
        currentHealth = startingHealth;
    }

    void Update()
    {
        if (damaged)
        {
            damageImage.color = flashColour;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;
    }

    public void TakeDamage(int amount)
    {
        damaged = true;

        currentHealth -= amount;

        healthSlider.value = currentHealth / 100f;

        playerAudio.Play();

        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }

    void Death()
    {
        isDead = true;

        Camera.main.transform.localPosition = new Vector3(0, -0.75f, 0);

        //playerShooting.DisableEffects ();

        //anim.SetTrigger("Die");

        //playerAudio.clip = deathClip;
        //playerAudio.Play();

        rigidbody.detectCollisions = false;
        playerRotation.enabled = false;
        playerMovement.enabled = false;
        playerShooting.enabled = false;
        GameObject.FindWithTag("Gun").SetActive(false);
        gameController.GameOver();
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }

}
