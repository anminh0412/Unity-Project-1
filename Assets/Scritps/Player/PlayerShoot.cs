using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour
{
    public float fireRate = 0.2f;
    public Transform firingPoint;
    public GameObject bulletPrefab;
    private bool checkWeaponExist;
    public Image image;

    float timeUntilFire;
    PlayerController playerController;
    private void Start()
    {
        playerController = gameObject.GetComponent<PlayerController>();
    }
    private void Update()
    {       
        checkWeaponExist = GetComponent<SummonWeapon>().exist;
        if (Input.GetKey(KeyCode.J) && timeUntilFire < Time.time && !checkWeaponExist)
        {
            Shoot();
            GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySound("skillJ");
            timeUntilFire = Time.time + fireRate;
            image.color = new Color(image.color.r, image.color.g, image.color.b, 0.4f);
            Debug.Log("ban ne");
            Invoke("ResetAlpha", fireRate);
        }
        void Shoot()
        {
            float angle = playerController.isFacingRight ? 0f : 180f;
            Instantiate(bulletPrefab, firingPoint.position, Quaternion.Euler(new Vector3(0f, 0.5f, angle)));
        }
    }
    void ResetAlpha()
    {
        image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);
    }
}
