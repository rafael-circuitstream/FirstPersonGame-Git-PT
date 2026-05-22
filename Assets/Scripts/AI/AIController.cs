using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform target;

    public bool detectedPlayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void SetCustomDestination(Transform newTarget)
    {
        agent.SetDestination(newTarget.position);
    }

    private void UpdateDestination()
    {
        agent.SetDestination(target.position);
    }

    private void Update()
    {
        if(detectedPlayer)
        {
            UpdateDestination();
        }

        if(Vector3.Distance(transform.position, target.position) < 5f)
        {
            detectedPlayer = true;
            //ATTACK THE PLAYER
            //DEAL DAMAGE
            //PLAY SOUND
        }
        else
        {
            detectedPlayer = false;
        }
    }

}
