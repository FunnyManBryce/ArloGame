using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PyromancerAI : Enemy
{
    public bool isRunning;
    public bool isSummoning;
    public float runDistance;
    public int fireballsTillSummon;
    public int maxSummons;
    public int currentSummons;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.speed = 0;
        player = GameObject.FindGameObjectWithTag("Player");
        target = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            enemyPosition = new Vector3(enemyTarget.position.x, enemyTarget.position.y, 0);
            playerPosition = new Vector3(target.position.x, target.position.y, 0);
            distanceFromPlayer = new Vector3(enemyPosition.x - playerPosition.x, enemyPosition.y - playerPosition.y, 0);
            animator.SetFloat("Speed", agent.speed);
            animator.SetBool("Attacking", isAttacking);
            animator.SetBool("Summoning", isSummoning);
            weaponAttack.SetBool("Attacking", isAttacking);
            weaponAttack.SetBool("Summoning", isSummoning);
            if (distanceFromPlayer.magnitude > runDistance && isAttacking == false && isSummoning == false)
            {
                isRunning = false;
                //Debug.Log("Chasing");
                agent.speed = moveSpeed;
                agent.SetDestination(target.position);
            }
            if(distanceFromPlayer.magnitude < runDistance && isAttacking == false && isSummoning == false)
            {
                isRunning = true;
                agent.speed = moveSpeed + 4;
                agent.SetDestination(-target.position);
            }
            if (distanceFromPlayer.magnitude < attackDistance && cooldown == false && isSummoning == false && isAttacking == false)
            {
                agent.speed = 0;
                if(fireballsTillSummon > 0 || maxSummons == currentSummons)
                {
                    isAttacking = true;
                    fireballsTillSummon--;
                    
                } else if(maxSummons != currentSummons)
                {
                    isSummoning = true;
                    currentSummons++;
                    fireballsTillSummon = 2;
                }
            }
        }
    }

}
