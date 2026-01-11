using System.Collections;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Transform []gunPoint;
    
    public GameObject enemyBullet;
    public GameObject enemyFlash;
    public GameObject enemyExplosionPrefab;
    public HealthBar healthBar;
    public GameObject damageEffect;
    public GameObject CoinPrefab;

    public AudioClip bulletSound;
    public AudioClip damageSound;
    public AudioClip explosionSound;
    public AudioSource audioSource;

    public float health = 10f;
    float barSize = 1f;
    float damage = 0;
    public float enemyBulletSpawnTime = 0.5f;
    public float speed = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyFlash.SetActive(false);
        StartCoroutine(EnemyShoot());
        damage = barSize / health;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * speed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag =="PlayerBullet")
        {
            audioSource.PlayOneShot(damageSound);
            DamageHealthBar();
           Destroy(collision.gameObject);
           GameObject damageVFX =  Instantiate(damageEffect, collision.transform.position, Quaternion.identity);
            Destroy(damageVFX, 0.05f);
            if (health<=0)
           {
                AudioSource.PlayClipAtPoint(explosionSound, Camera.main.transform.position);
                Instantiate(CoinPrefab, transform.position, Quaternion.identity);
                Destroy(gameObject);
                GameObject enemyExplosion = Instantiate(enemyExplosionPrefab, transform.position, Quaternion.identity);
                Destroy(enemyExplosion, 0.4f);
           }

           
        }
    }
    void DamageHealthBar()
    {
        if (health > 0)
        {
            health -= 1;
            barSize = barSize - damage;
            healthBar.SetSize(barSize);
        }
    }
    void EnemyFire()
    {
        for (int i = 0; i < gunPoint.Length; i++)
        {
            Instantiate(enemyBullet, gunPoint[i].position, Quaternion.identity);
        }
        //  Instantiate(enemyBullet, gunPoint1.position, Quaternion.identity);
        //  Instantiate(enemyBullet, gunPoint2.position, Quaternion.identity);
    }
    IEnumerator EnemyShoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(enemyBulletSpawnTime);
            EnemyFire();
            audioSource.PlayOneShot(bulletSound,0.5f);
            enemyFlash.SetActive(true);
            yield return new WaitForSeconds(0.04f);
            enemyFlash.SetActive(false);
        }
    }
}
