using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject damageEffect;
    public GameObject explosion;
    public PlayerHealthBarScript playerHealthBar;
    public CoinCount coinCountScript;
    public GameController gameController;
    public float speed = 10f;
    public float padding = 0.8f;    
    float minX;
    float maxX;
    float miny;
    float maxY;
    
    public AudioSource audioSource;
    public AudioClip damageSound;   
    public AudioClip explosionSound;
    public AudioClip coinSound;

    public float health = 20f;
    float barFillAmount = 1f;
    float damage = 0;

    void Start()
    {
        FindBoundaries();
        damage = barFillAmount / health;
    }

    void FindBoundaries()
    {
        Camera gameCamera = Camera.main;
        minX = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        maxX = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        miny = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;   
        maxY = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;   
    }
    void Update()
    {
        // 1. Calculate movement
        //    float deltaX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        //  float deltaY = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        // 2. Apply movement to current position
        //    float newXPos = Mathf.Clamp(transform.position.x + deltaX, minX,maxX);
        //    float newYPos = Mathf.Clamp(transform.position.y + deltaY, miny,maxY);

        // 3. IMPORTANT: Use Vector3 to keep the original Z position so the ship doesn't vanish
        //   transform.position = new Vector3(newXPos, newYPos, transform.position.z);
        if (Input.GetMouseButton(0))
        {   
           Vector2 newPos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y)); 
            transform.position = Vector2.Lerp(transform.position, newPos, 10 * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "EnemyBullet")
        {
            audioSource.PlayOneShot(damageSound,0.5f);
            DamagePlayerHealthBar();
            Destroy(collision.gameObject);
            GameObject damageVFX = Instantiate(damageEffect, collision.transform.position, Quaternion.identity);
            Destroy(damageVFX, 0.05f);
            if (health <= 0)
            {

                AudioSource.PlayClipAtPoint(explosionSound, Camera.main.transform.position, 0.5f);
                gameController.GameOver();
                Destroy(this.gameObject);
                GameObject blast = Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(blast, 2f);

            }
        }
        if (collision.gameObject.tag == "Coin")
        {
            audioSource.PlayOneShot(coinSound, 0.5f);
            Destroy(collision.gameObject);
            coinCountScript.AddCount();
        }
    }
    void DamagePlayerHealthBar()
    {
        if(health > 0)
        {
            health -= 1;
            barFillAmount = barFillAmount - damage;
            playerHealthBar.SetAmount(barFillAmount);

        }
    }
}
