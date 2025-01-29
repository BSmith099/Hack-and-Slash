using TMPro;
using UnityEngine;

public class MoneyTextScript : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    int totalMoney;

    [SerializeField] TextMeshProUGUI moneyText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        totalMoney = gameManager.currentCash;
        moneyText.text = totalMoney.ToString();
    }
}
