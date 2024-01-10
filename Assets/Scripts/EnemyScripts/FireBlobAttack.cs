using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBlobAttack : MonoBehaviour
{
    SkeletonBossProjectile skeletonBossProjectile;
    public GameObject fireBlob;
    public GameObject projectile;
    public Transform enemyPosition;
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        skeletonBossProjectile = projectile.GetComponent<SkeletonBossProjectile>();

    }

    // Update is called once per frame
    void Update()
    {
      
    }
    
    public void Death()
    {
        skeletonBossProjectile.projectileNumber = 1;
        Instantiate(projectile, new Vector3(enemyPosition.position.x, enemyPosition.position.y + 0.75f), Quaternion.identity);
        skeletonBossProjectile.projectileNumber = 2;
        Instantiate(projectile, new Vector3(enemyPosition.position.x, enemyPosition.position.y - 0.5f), Quaternion.identity);
        skeletonBossProjectile.projectileNumber = 3;
        Instantiate(projectile, new Vector3(enemyPosition.position.x + 1, enemyPosition.position.y - 0.25f), Quaternion.identity);
        skeletonBossProjectile.projectileNumber = 4;
        Instantiate(projectile, new Vector3(enemyPosition.position.x - 1, enemyPosition.position.y - 0.25f), Quaternion.identity);
        Debug.Log("erm what the griddy");
    }
    
    private void OnCollisionEnter2D(Collision2D col)
    {
     
        if (col.gameObject.tag == "Player")
        {
            Health health;
            health = col.gameObject.GetComponent<Health>();
            health.GetHit(damage, fireBlob);
        }
    }
}
