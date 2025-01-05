using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 7f;

    [SerializeField] private PlayerInputs playerInput;

    [SerializeField] private GameObject sword;

    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 inputVector = playerInput.GetMovementVectorNormalized();
    

        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        transform.position += moveDir * Time.deltaTime * moveSpeed;

        float rotSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotSpeed);

        //if(playerInput.attackAction != null && playerInput.attackAction.IsPressed())
        //{
        //    StartCoroutine(AttackCoroutine());
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            StartCoroutine(SlowPlayerCoroutine());
        }
    }

    public void DoAttack()
    {
        StartCoroutine(AttackCoroutine());
    }
   IEnumerator AttackCoroutine()
    {
        sword.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        sword.SetActive(false);
    }

    IEnumerator SlowPlayerCoroutine()
    {
        moveSpeed = 3f;
        yield return new WaitForSeconds(2f);
        moveSpeed = 7f;
    }
}
