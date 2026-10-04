using UnityEngine;

public class DistanceTrigger : MonoBehaviour
{
    public Transform targetOpponent;
    public Transform targetMe;
    public float attackDistance = 0.25f; 

    private Animator animator;
    private bool isAttacking = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (targetOpponent == null || animator == null) return;

        
        float distance = Vector3.Distance(targetMe.position, targetOpponent.position);

        
        if (distance <= attackDistance && !isAttacking)
        {
            isAttacking = true;
            animator.SetTrigger("Attack");
            animator.ResetTrigger("Idle");
        }
 
        else if (distance > attackDistance && isAttacking)
        {
            isAttacking = false;
            animator.SetTrigger("Idle");
            animator.ResetTrigger("Attack");
        }
    }
}
