using UnityEngine;

public class CustomPhysicsModule : MonoBehaviour
{
    [SerializeField] private float gravityForce;
    [SerializeField] private float sphereCheckRadius;
    [SerializeField] private LayerMask floorLayerMask;

    public Vector3 upDownForce;

    void Update()
    {
        if( IsGrounded()  )
        {
            if(upDownForce.y < 0)
            {
                upDownForce.y = 0;
            }
            
        }
        else
        {
            if (upDownForce.y > -10)
            {
                upDownForce.y += gravityForce * Time.deltaTime;
            }
        }   
    }

    public void AddJumpForce(float force)
    {
        if( IsGrounded() )
        {
            upDownForce.y = force;
        }
    }

    private bool IsGrounded()
    {
        return Physics.CheckSphere(transform.position, sphereCheckRadius, floorLayerMask);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, sphereCheckRadius);
    }
}
