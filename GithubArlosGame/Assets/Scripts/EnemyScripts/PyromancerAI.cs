using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PyromancerAI : Enemy
{
    public bool isRunning;
    public float runDistance;
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
            weaponAttack.SetBool("Attacking", isAttacking);
            if (distanceFromPlayer.magnitude > attackDistance && isAttacking == false)
            {
                //Debug.Log("Chasing");
                agent.speed = moveSpeed;
                agent.SetDestination(target.position);
            }
            if (distanceFromPlayer.magnitude < attackDistance && cooldown == false)
            {
                //Debug.Log("Attacking");
                agent.speed = 0;
                isAttacking = true;
            }
        }
    }
}
