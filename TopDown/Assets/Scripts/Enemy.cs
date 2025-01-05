using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform pointA;

    [SerializeField] private Transform pointB;

    [SerializeField] private float enemSpeed = 10f;

    private Transform targetPoint;

    private float rotateSpeed = 10f;

    public Player player;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindFirstObjectByType<Player>();
        targetPoint = player.gameObject.transform;
        transform.LookAt(new Vector3(targetPoint.position.x, transform.position.y, targetPoint.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        if (targetPoint != null)
        {
            transform.Translate(new Vector3(0,0,1) * enemSpeed * Time.deltaTime);
        }
        //var step = enemSpeed * Time.deltaTime;

        //if(Vector3.Distance(transform.position, pointA.position) < 0.0001f)
        //{
        //    targetPoint = pointB;
        //    Debug.Log("Moving towards B");
        //}
        
        //else if(Vector3.Distance(transform.position, pointB.position) < 0.0001f)
        //{
        //    targetPoint = pointA;
        //    Debug.Log("Moving towards A");
        //}
        

        //RotateTowardsTarget();
        //transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, step);
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
