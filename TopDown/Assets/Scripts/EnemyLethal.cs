using UnityEngine;

public class EnemyLethal : MonoBehaviour
{
    [SerializeField] private Transform pointA;

    [SerializeField] private Transform pointB;

    [SerializeField] private float enemSpeed = 10f;

    private Transform targetPoint;

    [SerializeField] private float rotateSpeed = 20f;

    public Player player;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindFirstObjectByType<Player>();
        targetPoint = player.gameObject.transform;
        //transform.LookAt(new Vector3(targetPoint.position.x, transform.position.y, targetPoint.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        var step = enemSpeed * Time.deltaTime;

        if (targetPoint != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, step);
        }

        //RotateTowardsTarget();
        transform.LookAt(player.transform, Vector3.up);
    }

    void RotateTowardsTarget()
    {
        float step = rotateSpeed * Time.deltaTime;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetPoint.position, step, 0f);
        transform.rotation = Quaternion.LookRotation(newDir);
    }

    public void KillEnemy()
    {
        Destroy(gameObject);
    }
}
