using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject[] anPrefabs;
    private Rigidbody playerRigidbody;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float downForce = 1f;
    public bool gameOver;
    public ParticleSystem explosionParticleSystem;
    public ParticleSystem moneyParticleSystem;

    public AudioClip bombExplosion;
    public AudioClip coinRecolect;
    public AudioClip playerJump;

    private AudioSource playerAudioSource;
    private AudioSource cameraAudioSource;

    private int coins = 0;  //variable per contador
    private float yRange = 14f; //variable per limit superior

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerAudioSource = GetComponent<AudioSource>();
        cameraAudioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        cameraAudioSource.volume = 0.05f;
    }


    void Update()
    {
        if (transform.position.y >= yRange)
        {
            playerRigidbody.AddForce(Vector3.down, ForceMode.Impulse);  //aplicar impuls cap abaix
            
        }

        if (Input.GetKeyDown(KeyCode.Space) && gameOver == false)
        {

            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);  // aplicar impuls cap a dalt
            playerAudioSource.PlayOneShot(playerJump, 1);
           

        }

        
    }

    private void OnCollisionEnter(Collision otherCollider)
    {
        if (!gameOver)
        {
            if (otherCollider.gameObject.CompareTag("Bomb"))
            {
                Destroy(otherCollider.gameObject);
                explosionParticleSystem.Play();
                playerAudioSource.PlayOneShot(bombExplosion, 1);
                Gameover();
            }

            if (otherCollider.gameObject.CompareTag("Money"))
            {
                Destroy(otherCollider.gameObject);
                playerAudioSource.PlayOneShot(coinRecolect, 1);
                moneyParticleSystem.Play();
                coins = coins + 1;
                Debug.Log($"Has recogido {coins}");
            }

            if (otherCollider.gameObject.CompareTag("Ground"))
            {
                Gameover();
                playerAudioSource.Stop();
                Time.timeScale = 0;
            }






        }
    }

    private void Gameover()
    {
        gameOver = true;
        cameraAudioSource.Stop();  //per aturar audio
    }
}
