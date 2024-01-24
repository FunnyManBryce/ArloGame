using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int currentHealth, maxHealth;

    public UnityEvent<GameObject> OnHitWithRefrence, OnDeathWithRefrence;

    [SerializeField] private bool isDead = false;
    public bool isInvincible = false;
    [SerializeField] private float invincibilityDuration = 1.5f;

    [SerializeField] private PlayerBlinkFeedback invincibilityFeedback;

    [SerializeField] playerController player;
    public void InitializeHealth(int healthValue)
    {
        currentHealth = healthValue;
        maxHealth = healthValue;
        isDead = false;
    }

    public void GetHit(int amount, GameObject sender)
    {
        if (isDead)
            return;
        if (sender.layer == gameObject.layer)
            return;
        if (isInvincible)
            return;
        currentHealth -= amount;
        if (currentHealth > 0)
        {
            OnHitWithRefrence?.Invoke(sender);

            int playerLayer = LayerMask.NameToLayer("Player");
            
            if (sender.layer != playerLayer)
            {
                StartCoroutine(StartInvicibilty());
            }
            player.OnTakeDamage();
        }
        else
        {
            Debug.Log("balls");
            OnDeathWithRefrence?.Invoke(sender);
            isDead = true;
            Destroy(gameObject);
        }
    }
    public IEnumerator StartInvicibilty() 
    {
        isInvincible = true;

        invincibilityFeedback?.PlayBlinkFeedback();

        yield return new WaitForSeconds(invincibilityDuration);

        isInvincible = false;
    }
}
