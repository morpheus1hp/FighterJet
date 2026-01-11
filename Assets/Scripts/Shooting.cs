using System.Collections;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject Playerbullet;
    public Transform SpawnPoint1;
    public Transform SpawnPoint2;
    public float bulletSpawnTime = 0.5f;
    public GameObject flash;
    public AudioSource audioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        flash.SetActive(false);
        StartCoroutine(Shoot());    
    }

    // Update is called once per frame
    void Update()
    {
        
           
        
    }
    private void Fire()
    {
        Instantiate(Playerbullet, SpawnPoint1.position, Quaternion.identity);
        Instantiate(Playerbullet, SpawnPoint2.position, Quaternion.identity);

    }
    IEnumerator Shoot()
    {
        while (true)
        {
            
            yield return new WaitForSeconds(bulletSpawnTime);
            Fire();
            audioSource.Play();
            flash.SetActive(true);
            yield return new WaitForSeconds(0.04f);  
            flash.SetActive(false);
        }
    }
}

