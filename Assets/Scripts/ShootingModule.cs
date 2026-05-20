using UnityEngine;

public class ShootingModule : MonoBehaviour
{
    [SerializeField] private Transform weaponTip;
    [SerializeField] private ProjectilePooling projectilePool;

    public void Shoot()
    {
        Projectile projectileInstance = projectilePool.GetAvailableProjectile();
        
        projectileInstance.transform.position = weaponTip.position;
        projectileInstance.transform.rotation = weaponTip.rotation;
        
        projectileInstance.gameObject.SetActive(true);
        projectileInstance.InitializeBullet();
    }
}
