using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinAmount : MonoBehaviour
{
    public ScriptableCoin money;

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            ManagerScore.coinsAmount += money.coinMoney;
            Destroy(this.gameObject);
        }
    }
}
