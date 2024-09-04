using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CollectCoin : MonoBehaviour
{
    public Text CoinText;
    public int coins=0;
    // Start is called before the first frame update
    private void Start()
    {
        CoinText.text = "0";
    }
    public void AddCoins()
    {
        
            coins += 50;
            CoinText.text = coins.ToString();
        
    }
}
