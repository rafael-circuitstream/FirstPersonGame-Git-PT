using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private PlayerInput player;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("Instance is already filled");
            Destroy(gameObject);
        }
        
    }

    public void UnfreezePlayer()
    {
        player.enabled = true;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void FreezePlayer()
    {
        player.enabled = false;
        
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public PlayerInput GetPlayer()
    {
        return player;
    }
}
