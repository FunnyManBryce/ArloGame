using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaBoss : MonoBehaviour
{
    public bool isTeleporting;
    public bool isAttacking;
    public bool isSpawning;

    public GameObject Fireball;
    public GameObject Wave;
    public GameObject Pyromancer;
    public GameObject Player;
    public GameObject Gerald;

    public Transform bossPosition;
    public Transform playerPosition;

    public Vector3[] teleportLocations;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        playerPosition = Player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Teleporting", isTeleporting);
    }
    
    public void Teleport()
    {
        Gerald.transform.position = teleportLocations[Random.Range(0, teleportLocations.Length)];
    }

    public void Attack()
    {

    }

    public void Summon()
    {

    }
}
