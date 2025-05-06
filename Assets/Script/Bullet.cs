using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 20;
    public float speed = 20f;
    public Rigidbody2D rb;
    private bool _isFacingRight; // Stock la direction de tir

    void Start()
    {
        float direction = _isFacingRight ? 1f : -1f; // Détermine la direction, ? : permet d'écrire de manière condensée une condition, si c'est 1f on tire à droite si c'est -1f on tire à gauche 
        // rb.velocity = transform.right * speed; //le rigidbody va aller à droite par rapport au speed demandé
        rb.velocity = new Vector2(direction * speed, 0f); // Applique la vélocité (vitesse de l'objet), 0f la force à rester sur la même hauteur sur l'axe x


    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        Cible cible = hitInfo.GetComponent<Cible>();
        if (cible != null)
        {
            cible.TakeDamage(1); // chaque tir ajoute +1
        }

        Destroy(gameObject); // détruire la balle après impact
    }


    public void SetDirection(bool facingRight)
    {
        _isFacingRight = facingRight;
    }

}