using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    [SerializeField] int totalPoints;

    [SerializeField]
    int hitsNeeded;

    int hitsTaken;

    [SerializeField] private GameManager gameManager;

    private void OnEnable()
    {
        gameManager = FindFirstObjectByType<GameManager>();

        hitsTaken = 0;
    }

    public void AddHits(int hits)
    {
        hitsTaken += hits;

        if (hitsTaken >= hitsNeeded)
        {
            KillEnemy();
        }
    }

    public void KillEnemy()
    {
        gameManager.UpdateScore(totalPoints);
        Destroy(gameObject);
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Weapon"))
    //    {
    //        AddHits(5);
    //    }
    //}
}
