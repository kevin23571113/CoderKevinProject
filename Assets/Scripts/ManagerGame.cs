using UnityEngine;

public class ManagerGame : MonoBehaviour
{
    public static ManagerGame instancia;
    public static int EnemigosSala_1 = 5;

    void Awake()
    {
        if(ManagerGame.instancia == null)
        {
            ManagerGame.instancia = this;
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