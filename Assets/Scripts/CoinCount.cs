using UnityEngine;
using UnityEngine.UI;

public class CoinCount : MonoBehaviour
{
    public Text coinCountText;
    public Text coinsText;  
    int Count = 0;  

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coinCountText.text = Count.ToString();
        coinsText.text = "Coins : " +  Count.ToString();  
    }
    public void AddCount()
    {
        Count++;
        
    }
}
