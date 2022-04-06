using UnityEngine;
using UnityEngine.UI;

public class ManagerGame : MonoBehaviour
{
    public static ManagerGame instancia;
    public static int EnemigosSala_1 = 5;

    public Text nameText;
    public Text costText;
    public Text damageText;

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

    public void UpdateUI(WeaponData weaponData)
    {
        nameText.text = weaponData.name;
        costText.text = weaponData.cost.ToString();
        damageText.text = weaponData.damage.ToString();
    }
}