using UnityEngine;

public class HurtBoxScript : MonoBehaviour
{
    public string tagMask;

    [SerializeField]
    int damage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == tagMask)
        {
            HealthScript health = other.gameObject.GetComponent<HealthScript>();

            if (health != null)
            {
                health.AddHits(damage);
            }
        }
        
        if (other.tag == tagMask)
        {
           PlayerHealthController playerHealth = other.gameObject.GetComponent<PlayerHealthController>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
        }
    }
}
