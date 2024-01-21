using UnityEngine;

public class Zombie_AI : MonoBehaviour
{
    public float resetParameter=0.2f;
    public Animator anim;
    public Transform player;
    public float moveSpeed=1f;
    public float rotationSpeed=1f;
    public float minDistance=15f;
    public float maxDistance=100f;
    public Vector3 initialPosition;
    public float interactionRange=100f;
    public Transform head;
    public float resetDistance=5f;
    bool isResetting=false;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition=transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("isRunning",false);
        Ray ray = new Ray(head.position, transform.forward);
        Debug.DrawRay(ray.origin,ray.direction*interactionRange,Color.red,1f);
        // Perform the raycast
        if(Physics.Raycast(ray, out RaycastHit hit, interactionRange))
        {
            // Check if the hit object is a door
            //if (hit.collider.CompareTag("door"))
            //{
                // Perform actions related to the door
                Debug.Log("door");
                ResetPosition();
            //}
        }
        else if(!isResetting)
        {
            float distance = (player.position - transform.position).magnitude;
            if(distance<maxDistance)
            {
                Rotate(player.position);
                if(distance>minDistance)
                FollowPlayer();
                else
                Attack();
            }
        }
        if(isResetting)
        {
            Rotate(initialPosition);
            transform.position=Vector3.Lerp(transform.position, initialPosition, resetParameter*Time.deltaTime);
            anim.SetBool("isRunning",true);
            if((transform.position-initialPosition).magnitude<resetDistance) isResetting=false;
        }
        
    }

    void Rotate(Vector3 target)
    {
        Vector3 targetDirection = target - transform.position;
        targetDirection.Normalize();
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    void FollowPlayer()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        anim.SetBool("isRunning",true);
    }

    void Attack()
    {
        Debug.Log("Attack");
    }

    void ResetPosition()
    {
        isResetting=true;
        anim.SetBool("isRunning",true);
        Debug.Log("reset");
    }
}
