using UnityEngine;
using UnityEngine.UI;

public class ManagerGame : MonoBehaviour
{
    public Text nameText;
    public Text costText;
    public Text damageText;
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

    public void UpdateUI(WeaponData newWeapon)
    {
        nameText.text = newWeapon.name;
        costText.text = newWeapon.cost.ToString();
        damageText.text = newWeapon.damage.ToString();
    }
}