using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    public float regenDelay = 5f;        // Temps à attendre avant de commencer la regen
    public float regenRate = 1f;         // Points de vie régénérés par seconde

    private Coroutine regenCoroutine;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(20);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        healthBar.SetHealth(currentHealth);

        // Si une régénération est en cours, on l'arrête et on la redémarre
        if (regenCoroutine != null)
        {
            StopCoroutine(regenCoroutine);
        }
        regenCoroutine = StartCoroutine(RegenerateHealth());
    }

    private IEnumerator RegenerateHealth()
    { //on indique que le joueur se régénere

        yield return new WaitForSeconds(regenDelay);

        while (currentHealth < maxHealth) //boucle tant que le joueur n'a pas la vie maximale
        {
            currentHealth += Mathf.CeilToInt(regenRate * Time.deltaTime); //cmb de vie on régènére cette frame, mathf.ceiltoint arrondit à l'entier supérieur
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); //clamp permet de ne pas dépasser maxHealth
            healthBar.SetHealth(currentHealth);
            yield return null; //on attend la frame suivante avant de continuer
        }

        regenCoroutine = null; //on met la coroutine à null pour la relancer plus tard si besoin
    }
}