using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float projectileSpeed;
    [SerializeField] private Rigidbody projectileRigidbody;

    public ProjectilePooling parentPool;

    public void InitializeBullet()
    {
        projectileRigidbody.linearVelocity = transform.forward * projectileSpeed;
        Invoke("ResetProjectile", 8f);
    }

    void ResetProjectile()
    {
        CancelInvoke();
        projectileRigidbody.linearVelocity = Vector3.zero;
        projectileRigidbody.angularVelocity = Vector3.zero;

        parentPool.SetProjectileAvailable( this );
    }

    private void OnCollisionEnter(Collision collision)
    {
        ResetProjectile();
    }
}
