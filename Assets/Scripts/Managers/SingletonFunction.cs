using UnityEngine;
using UnityEngine.SceneManagement;

public class SingletonFunction : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            SceneManager.LoadScene(1);
        }
        
    }
}
