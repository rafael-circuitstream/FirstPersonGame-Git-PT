using UnityEngine;

public class ShootingModule : MonoBehaviour
{
    [SerializeField] private Transform weaponTip;
    [SerializeField] private Projectile projectilePrefab;

    public void Shoot()
    {
        Instantiate(projectilePrefab, weaponTip.position, weaponTip.rotation);
    }
}
