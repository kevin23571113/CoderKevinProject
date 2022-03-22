using UnityEngine;

public class ManagerScore : MonoBehaviour
{
    public static ManagerScore instancia;
    public static int playerHealth = 20;

    void Awake()
    {
        if(ManagerScore.instancia == null)
        {
            ManagerScore.instancia = this;
            DontDestroyOnLoad(gameObject);
        }else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}