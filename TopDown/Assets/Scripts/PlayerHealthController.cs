using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    [SerializeField]
    float health = 100;

    float currentHealth;

    [SerializeField] Player player;

    [SerializeField] private GameManager gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = health;
        player = GetComponent<Player>();
        gameManager = FindFirstObjectByType<GameManager>();
        Debug.Log("Player has " +  health + " points of health!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth == 0)
        {
            //this is where we call the gameover function on the player
            Debug.Log("Player must die!");
            gameManager.GameOver();
        }
    }

    public void GiveHealth(float healVal)
    {
        currentHealth += healVal;

        if (currentHealth >= health)
        {
            currentHealth = health;
        }
    }
}
