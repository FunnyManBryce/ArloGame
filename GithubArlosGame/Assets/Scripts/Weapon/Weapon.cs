using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float detectionDelay = 0.1f; 
    public float attackDelay = 0.2f;
    public Transform attackOrigin;
    public float radius = 0.3f;
    public int damage = 1;
    public float knockbackMultiplier = 3f;

    public bool attackBlocked;

    public Animator animator;
    public SpriteRenderer weaponRenderer;


    public void ResetAttackBlocked()
    {
        attackBlocked = false;
    }

    public IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(attackDelay);
        attackBlocked = false;
    }

    public void DetectColliders()
    {
        StartCoroutine(DelayedDetection());
    }

    private IEnumerator DelayedDetection()
    {
        yield return new WaitForSeconds(detectionDelay);

        foreach (Collider2D collider in Physics2D.OverlapCircleAll(attackOrigin.position, radius))
        {
            Debug.Log(collider.name);

            KnockbackFeedback knockbackScript = collider.GetComponent<KnockbackFeedback>();

            if (knockbackScript != null)
            {
                knockbackScript.SetKnockbackMultiplier(knockbackMultiplier);
                knockbackScript.PlayFeedback(gameObject);
            }

            Health health;

            if (health = collider.GetComponent<Health>())
            {
                health.GetHit(damage, transform.parent.gameObject);
            }
        }
    }
}

