using UnityEngine;

public class PlayerPersistence : MonoBehaviour
{
    public void SaveData(GameManager gameManager)
    {
        PlayerPrefs.SetInt("money", gameManager.score);
    }

    public void DeletePlayerStats()
    {
        PlayerPrefs.DeleteAll();
        print("Data is " + PlayerPrefs.GetInt("money"));
    }

    public PlayerData LoadData()
    {
        int money = PlayerPrefs.GetInt("money");

        PlayerData playerData = new PlayerData()
        {
            Money = money
        };

        return playerData;
    }
}
