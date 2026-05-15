using UnityEngine;
using UnityEngine.Events;

public class PressurePadTrigger : MonoBehaviour
{
    public UnityEvent OnPressureActivate;
    public UnityEvent OnPressureDeactivate;

    private void OnTriggerEnter(Collider other)
    {
        OnPressureActivate.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        OnPressureDeactivate.Invoke();
    }


}
