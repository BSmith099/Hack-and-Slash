using UnityEngine;

public static class PlayerPersistence
{
    public static void SaveData(GameManager gameManager)
    {
        PlayerPrefs.SetInt("money", gameManager.score + gameManager.PlayerData.Money);
    }

    public static void ResetScore(GameManager gameManager)
    {
        gameManager.PlayerData.Money = 0;
    }

    public static PlayerData LoadData()
    {
        int money = PlayerPrefs.GetInt("money");

        PlayerData playerData = new PlayerData()
        {
            Money = money
        };

        return playerData;
    }
}
