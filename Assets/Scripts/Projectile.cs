using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float projectileSpeed;
    [SerializeField] private Rigidbody projectileRigidbody;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        projectileRigidbody.linearVelocity = transform.forward * projectileSpeed;
        Invoke("ResetProjectile", 8f);
    }

    void ResetProjectile()
    {
        Destroy(gameObject);
    }
}
