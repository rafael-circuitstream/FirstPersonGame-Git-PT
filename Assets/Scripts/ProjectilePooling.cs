using UnityEngine;
using System.Collections.Generic;


public class ProjectilePooling : MonoBehaviour
{
    [SerializeField] private Projectile projectilePrefab;
    [SerializeField] private int poolAmount;

    [SerializeField] private List<Projectile> availableProjectiles;
    [SerializeField] private List<Projectile> usedProjectiles;

    void Awake()
    {
        while(availableProjectiles.Count < poolAmount)
        {
            CreateProjectile();
        }
    }

    void CreateProjectile()
    {
        Projectile clonedProjectile = Instantiate(projectilePrefab);

        clonedProjectile.parentPool = this;

        clonedProjectile.gameObject.SetActive(false);

        clonedProjectile.transform.SetParent(transform);

        availableProjectiles.Add(clonedProjectile);
    }

    public Projectile GetAvailableProjectile()
    {
        if(availableProjectiles.Count == 0)
        {
            CreateProjectile();
        }


        Projectile toRetrieve = availableProjectiles[0];

        availableProjectiles.Remove(toRetrieve);
        usedProjectiles.Add(toRetrieve);

        return toRetrieve;
    }

    public void SetProjectileAvailable(Projectile toReset)
    {
        if(usedProjectiles.Contains(toReset))
        {
            toReset.gameObject.SetActive(false);

            availableProjectiles.Add(toReset);
            usedProjectiles.Remove(toReset);
        }

    }

}
