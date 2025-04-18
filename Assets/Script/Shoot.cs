using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using Unity.VisualScripting;
public class Shoot : MonoBehaviour
{

    public Transform firePoint;
    public GameObject Bullet;
    private EntityControllerPlayerInput _playerController; // Référence au script de déplacement
    public Item gun;
    public TMP_Text munitionUI;
    
    public Animator animator;
    
    public TMP_Text StatueUI;
    private int _munition = 10;
    public int munitionMax = 10;
    public bool weaponOut = false;
    public bool _weaponGet = false;
    void Start()
    {
        _playerController = GetComponent<EntityControllerPlayerInput>(); // Récupération du script de déplacement
        munitionMax = _munition;
        UpdateMunition();
        StatueUI.gameObject.SetActive(false);
        munitionUI.gameObject.SetActive(false);
    }

    void Update()
    {
        if (_weaponGet == false)
        {
            GetWeapon();
        }
    }

    private void OnShoot()
    {

        //Va avoir toute la logique de shoot

        if (Inventory.Instance.content.Contains(gun) && _munition > 0 && weaponOut ==true) //Inventory.Instance.content.Contains(gun)
        {
            GameObject bullet = Instantiate(Bullet, firePoint.position, firePoint.rotation); //fait spawn le prefab de la bullet sur le firepoint

            //On récupère le script Bullet pour lui donner la direction
            Bullet bulletScript = bullet.GetComponent<Bullet>();
            if (bulletScript != null) //Vérification opur voir si le script Bullet a bien était trouvé sur l'objet bullet
            {
                bulletScript.SetDirection(_playerController.isFacingRight); //transmet la position du joueur à la balle
            }

            _munition -= 1;
            UpdateMunition();
        }
        else
        {
            return;
        }
    }


    private void GetWeapon()
    {
        if (Inventory.Instance.content.Contains(gun))
        {
            StatueUI.gameObject.SetActive(true);
            StatueUI.text = "Statue Weapon : OFF";
            StatueUI.color = Color.red;  
            munitionUI.gameObject.SetActive(true);
            _weaponGet = true;
        }
    }
    private void OnWeapon()
    {
        if (weaponOut == true)
        {
            StatueWeaponOff();
        }

        else
        {
            StatueWeaponOn();
        }

    }

    public void StatueWeaponOff() //permet de désactiver l'arme
    {
        weaponOut = false;
        StatueUI.text = "Statue Weapon : OFF";
        StatueUI.color = Color.red;
        animator.SetBool("Gun", false);   
    }

    public void StatueWeaponOn() //permet d'activer l'arme
    {
        weaponOut = true;
        StatueUI.text = "Statue Weapon : ON";
        StatueUI.color = Color.green;
        animator.SetBool("Gun", true); 
    }
    private void OnRechargement()
    {
        _munition = munitionMax;
        UpdateMunition();
    }
    public void UpdateMunition()
    {
        munitionUI.text = _munition.ToString() + "/" + munitionMax.ToString();
    }

}
