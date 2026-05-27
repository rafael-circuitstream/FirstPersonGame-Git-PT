using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private float damageRate;

    private HealthModule healthModule;

    private void OnTriggerEnter(Collider other)
    {
        healthModule = other.GetComponent<HealthModule>();
        InvokeRepeating("DealDamage", 0, damageRate);
    }

    private void DealDamage()
    {
        if (healthModule)
        {
            healthModule.DecreaseHealth(damage);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        healthModule = null;
        CancelInvoke();
    }
}
