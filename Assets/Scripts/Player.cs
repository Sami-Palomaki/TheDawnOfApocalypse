using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public bool isGameOver;
    public HealthBar healthBar;
    public GameOverScreen GameOverScreen;
    public AudioClip[] hurtSounds;
    private AudioSource soundSource;

    [Header("Hurt Image Flash")]
    [SerializeField] private Image hurtImage = null;
    [SerializeField] private float hurtTimer = 0.1f;

    public void GameOver() 
    {
        GameOverScreen.Setup(Target.howManyKills);        
    }

    void Start()
    {
        soundSource = GetComponent<AudioSource>();
        hurtImage.enabled = false;
        isGameOver = false;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if(isGameOver)
        {
            Time.timeScale = 0;                 // Tämä pysäyttäää pelin animaatiot
            AudioListener.pause = true;         // Peliäänet pysähtyvät
            GameOver();
        }
    }

    IEnumerator HurtFlash()
    {
        hurtImage.enabled = true;
        yield return new WaitForSeconds(hurtTimer);
        hurtImage.enabled = false;
    }

    public void TakeDamage(int damage)                  // Tässä pelaaja ottaa damagea
    {
        StartCoroutine(HurtFlash());
        currentHealth -= damage;
        HurtSounds();

        healthBar.SetHealth(currentHealth);

        if(currentHealth <= 0)              // Jos health laskee alle nollan, peli päättyy
        {
            isGameOver = true;
        }
    }

    public void HurtSounds()
    {
        int n = Random.Range(1, hurtSounds.Length);    //Arpoo minkä osuma äänen toistaa
        soundSource.clip = hurtSounds[n];
        soundSource.PlayOneShot(soundSource.clip);      //Toistaa osuma-äänen

        hurtSounds[n] = hurtSounds[0];                 //Tällä varmistetaan, ettei ääntä toisteta kuin kerran
        hurtSounds[0] = soundSource.clip;
    }
}
