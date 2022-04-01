using UnityEngine;
using UnityEngine.UI;

public class CanvasFunctions : MonoBehaviour
{
    public Image healthBar;
    public GameObject pausePanel;
    private float currentHealth;
    private float maxHealth = 20f;
    private bool pauseActive;




    void Start()
    {
        
    }

    void Update()
    {
        currentHealth = ManagerScore.playerHealth;
        healthBar.fillAmount = currentHealth/maxHealth;
        if(Input.GetKeyDown(KeyCode.T))
        {
            if(pauseActive)
            {
                ResumeGame();
            }else
            {
                PauseGame();
            }
        }
    }

    void PauseGame()
    {
        pausePanel.SetActive(true);
        pauseActive = true;
        Time.timeScale = 0;
    }

    void ResumeGame()
    {
        pausePanel.SetActive(false);
        pauseActive = false;
        Time.timeScale = 1;
    }
}
