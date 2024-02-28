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

    public void ChangeScale(float scaleAmount)
    {
        transform.localScale += new Vector3(scaleAmount, scaleAmount, scaleAmount);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Vector3 position = attackOrigin == null ? Vector3.zero : attackOrigin.position;
        Gizmos.DrawWireSphere(position, radius);
    }

    public IEnumerator DelayedDetection()
    {
        yield return new WaitForSeconds(detectionDelay);

        Collider2D[] colliders = Physics2D.OverlapCircleAll(attackOrigin.position, radius);

        List<KnockbackFeedback> knockbackScripts = new List<KnockbackFeedback>();
        List<Health> healthComponents = new List<Health>();

        foreach (Collider2D collider in colliders)
        {
            KnockbackFeedback knockbackScript = collider.GetComponent<KnockbackFeedback>();
            if (knockbackScript != null)
            {
                knockbackScripts.Add(knockbackScript);
            }

            Health healthComponent = collider.GetComponent<Health>();
            if (healthComponent != null)
            {
                healthComponents.Add(healthComponent);
            }
        }

        foreach (KnockbackFeedback knockbackScript in knockbackScripts)
        {
            knockbackScript.SetKnockbackMultiplier(knockbackMultiplier);
            knockbackScript.PlayFeedback(gameObject);
        }

        foreach (Health healthComponent in healthComponents)
        {
            healthComponent.GetHit(damage, transform.parent.gameObject);
        }

    }
}

