using UnityEngine;
using UnityEngine.UI;

public class CanvasFunctions : MonoBehaviour
{
    public Image healthBar;
    public GameObject pausePanel;
    public Text coins;
    private float currentHealth;
    private float maxHealth = 65f;
    private bool pauseActive;

    void Start()
    {
        
    }

    void Update()
    {
        currentHealth = ManagerScore.playerHealth;
        healthBar.fillAmount = currentHealth/maxHealth;
        if(Input.GetKeyDown(KeyCode.P))
        {
            if(pauseActive)
            {
                ResumeGame();
            }else
            {
                PauseGame();
            }
        }
        coins.text = "Monedas: " + ManagerScore.coinsAmount;
        
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
