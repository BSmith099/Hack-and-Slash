using UnityEngine;

public class EnemyDeathWall : MonoBehaviour
{
    private Enemy enemy;

    private void OnTriggerEnter(Collider other)
    { 
        if(other.gameObject.tag == "Enemy")
        {
            other.GetComponent<Enemy>().KillEnemy();
        }
    }
}
