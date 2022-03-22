using UnityEngine;

public class ManagerSounds : MonoBehaviour
{
    public static ManagerSounds instancia;

    AudioSource _audSource;

    void Awake()
    {
        if(ManagerSounds.instancia == null)
        {
            ManagerSounds.instancia = this;
            DontDestroyOnLoad(gameObject);
            _audSource = GetComponent<AudioSource>();
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
        if(Input.GetKeyDown(KeyCode.P))
        {
            Pausar();
        }else if(Input.GetKeyDown(KeyCode.U))
        {
            Despausar();
        }
    }

    public static void Pausar()
    {
        instancia._audSource.Pause();
    }

    public static void Despausar()
    {
        instancia._audSource.UnPause();
    }
}