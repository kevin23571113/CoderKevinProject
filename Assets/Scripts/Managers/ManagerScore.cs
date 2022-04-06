using UnityEngine;

public class ManagerScore : MonoBehaviour
{
    public static ManagerScore instancia;
    public static float playerHealth = 20f;
    public static int coinsAmount = 0;

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