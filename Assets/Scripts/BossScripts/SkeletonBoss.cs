using UnityEngine;

public class SkeletonBoss : MonoBehaviour
{
    public GameObject player;
    public GameObject projectile;
    public GameObject boss;
    public GameObject summon;

    public SkeletonBossProjectile skeletonBossProjectile;

    public Health health;

    public int damage = 1;
    public int shotsFiredPerPhase = 4;
    int currentShotsFired = 0;
    int currentPhase = 1;

    float currentTimeBetweenShots;
    public float maxTimeBetweenShots = 3;
    float attackDelay = 0.75f;
    public float attackDelayStart = 0.75f;
    public float moveSpeed = 5;
    public float ramSpeed = 0.1f;
    float currentStunLength = 3f;
    public float totalStunLength = 3f;

    public Transform bossTarget;
    public Transform playerTarget;
    public Transform summonPositionOne;
    public Transform summonPositionTwo;

    bool bossStarted = false;
    bool movingStart = false;
    bool moving = false;
    bool ramming = false;
    bool shooting = false;
    bool doneFiring = false;
    bool summoning = true;
    bool stunned = false;

    Vector2 bossPosition;
    Vector2 playerPosition;
    Vector2 distanceFromPlayer;

    private Vector2 randomDir;

    // Start is called before the first frame update
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerTarget = player.transform;
        skeletonBossProjectile = projectile.GetComponent<SkeletonBossProjectile>();
        bossStarted = true;
    }

    // Update is called once per frame
    private void Update()
    {
        if (player != null)
        {
            if (ramming == false)
            {
                bossPosition = new Vector2(bossTarget.position.x, bossTarget.position.y);
                playerPosition = new Vector2(playerTarget.position.x, playerTarget.position.y);
                distanceFromPlayer = new Vector2(bossPosition.x - playerPosition.x, bossPosition.y - playerPosition.y);
            }
            if (health.currentHealth <= 100)
            {
                currentPhase = 2;
            }
            if (movingStart == true)
            {
                randomDir = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
                moving = true;
                movingStart = false;
            }
            if (bossStarted == true)
            {
                if (currentTimeBetweenShots > 0 && ramming == false && summoning == false && stunned == false)
                {
                    currentTimeBetweenShots -= Time.deltaTime;
                }
                else if (currentTimeBetweenShots < 0)
                {
                    currentTimeBetweenShots = maxTimeBetweenShots;
                    shooting = true;
                }
                if (moving == true)
                {
                    transform.Translate(randomDir * Time.deltaTime * moveSpeed);
                }
                if (shooting == true)
                {
                    if (attackDelay > 0.25)
                    {
                        moveSpeed = 0f;
                        attackDelay -= Time.deltaTime;
                    }
                    else if (attackDelay > 0)
                    {
                        if (doneFiring == false)
                        {
                            Debug.Log("firing");
                            skeletonBossProjectile.projectileNumber = 1;
                            Instantiate(projectile, new Vector3(bossTarget.position.x, bossTarget.position.y + 0.75f), Quaternion.identity);
                            skeletonBossProjectile.projectileNumber = 2;
                            Instantiate(projectile, new Vector3(bossTarget.position.x, bossTarget.position.y - 0.5f), Quaternion.identity);
                            skeletonBossProjectile.projectileNumber = 3;
                            Instantiate(projectile, new Vector3(bossTarget.position.x + 1, bossTarget.position.y - 0.25f), Quaternion.identity);
                            skeletonBossProjectile.projectileNumber = 4;
                            Instantiate(projectile, new Vector3(bossTarget.position.x - 1, bossTarget.position.y - 0.25f), Quaternion.identity);
                            if (currentPhase == 2)
                            {
                                skeletonBossProjectile.projectileNumber = 5;
                                Instantiate(projectile, new Vector3(bossTarget.position.x + 0.75f, bossTarget.position.y + 0.75f), Quaternion.identity);
                                skeletonBossProjectile.projectileNumber = 6;
                                Instantiate(projectile, new Vector3(bossTarget.position.x + 0.75f, bossTarget.position.y - 0.5f), Quaternion.identity);
                                skeletonBossProjectile.projectileNumber = 7;
                                Instantiate(projectile, new Vector3(bossTarget.position.x - 0.75f, bossTarget.position.y + 0.75f), Quaternion.identity);
                                skeletonBossProjectile.projectileNumber = 8;
                                Instantiate(projectile, new Vector3(bossTarget.position.x - 0.75f, bossTarget.position.y - 0.5f), Quaternion.identity);
                            }
                            doneFiring = true;
                        }
                        attackDelay -= Time.deltaTime;
                    }
                    else if (attackDelay < 0)
                    {
                        shooting = false;
                        attackDelay = attackDelayStart;
                        currentTimeBetweenShots = maxTimeBetweenShots;
                        if (currentPhase == 1)
                        {
                            moveSpeed = 5;
                        }
                        else if (currentPhase == 2)
                        {
                            moveSpeed = 7;
                        }
                        currentShotsFired++;
                        doneFiring = false;
                        if (currentShotsFired == shotsFiredPerPhase)
                        {
                            currentShotsFired = 0;
                            rammingStart();
                        }
                    }
                }
                if (ramming == true)
                {
                    transform.Translate(-distanceFromPlayer * Time.deltaTime * ramSpeed);
                }
                if (stunned == true)
                {
                    if (currentStunLength > 0)
                    {
                        currentStunLength -= Time.deltaTime;
                    }
                    else if (currentStunLength <= 0)
                    {
                        currentStunLength = totalStunLength;
                        stunned = false;
                        summoning = true;
                    }
                }
                if (summoning == true)
                {
                    if (attackDelay > 0.25)
                    {
                        moveSpeed = 0f;
                        attackDelay -= Time.deltaTime;
                    }
                    else if (attackDelay > 0)
                    {
                        if (doneFiring == false)
                        {
                            Instantiate(summon, new Vector3(summonPositionOne.position.x, summonPositionOne.position.y), Quaternion.identity);
                            if (currentPhase == 2)
                            {
                                Instantiate(summon, new Vector3(summonPositionTwo.position.x, summonPositionTwo.position.y), Quaternion.identity);
                            }
                            doneFiring = true;
                        }
                        attackDelay -= Time.deltaTime;
                    }
                    else if (attackDelay < 0)
                    {
                        summoning = false;
                        attackDelay = attackDelayStart;
                        currentTimeBetweenShots = maxTimeBetweenShots;
                        if (currentPhase == 1)
                        {
                            moveSpeed = 5;
                        }
                        else if (currentPhase == 2)
                        {
                            moveSpeed = 7;
                        }
                        doneFiring = false;
                        movingStart = true;
                    }
                }
            }
        }
    }

    private void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Wall")
        {
            randomDir = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            if (ramming == true)
            {
                stunned = true;
                ramming = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Wall")
        {
            randomDir = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        }
        if (col.gameObject.tag == "Player")
        {
            Health health;
            health = col.gameObject.GetComponent<Health>();
            health.GetHit(damage, boss);
        }
    }
    private void rammingStart()
    {
        moving = false;
        ramming = true;
    }
}