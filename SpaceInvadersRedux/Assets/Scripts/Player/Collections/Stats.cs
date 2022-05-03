using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Stats : MonoBehaviour
{
    //Local Variables
    public int maxHealth = 100;
    public int currentHealth;
    int healAmount;

    public float cooldownTime = 1f;
    private float currentCooldown;
    bool invincible = false;

    //References
    public AdjustableBar healthbar;
    public Flash Flash;

    public AudioClip healSound;
    public AudioSource sound;

    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMax(maxHealth);
        currentCooldown = cooldownTime;
        healSound = AudioFiles.Health;
    }

    // Update is called once per frame
    void Update()
    {
        currentCooldown -= Time.deltaTime;
        if (currentCooldown <= 0)
        {
            invincible = false;
        }
        healthbar.SetCurrent(currentHealth);

        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 14 && (currentHealth < maxHealth))
        {
            if (other.tag == "healthkit1")
            {
                healAmount = 15;
            }
            if (other.tag == "healthkit2")
            {
                healAmount = 30;
            }
            if (other.tag == "healthkit3")
            {
                healAmount = 50;
            }
            PlaySound(healSound);
            Flash.StartFlash(0.25f, 0.40f, Color.green);
            Recover(healAmount);
            Destroy(other.gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        if (!invincible)
        {
            currentHealth -= damage;
            Flash.StartFlash(0.25f, 0.40f, Color.red);
            invincible = true;
            currentCooldown = cooldownTime;
        }         
    }

    public void Recover(int heal)
    {
        if ((currentHealth + heal) > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
            currentHealth += heal;
    }

    private void PlaySound(AudioClip audio)
    {
        sound.clip = audio;
        sound.Play();
        Debug.Log("Sound has triggered.");
    }
}
