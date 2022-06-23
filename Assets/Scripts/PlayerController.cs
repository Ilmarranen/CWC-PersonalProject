using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Player
    public float speed = 500.0f;
    private Rigidbody playerRb;
    public GameObject focalPoint;
 
    //Powerup
    public bool hasPowerup = false;
    public float powerupStrength = 10;
    public GameObject powerupIndicator;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            powerupIndicator.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
            enemyRb.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
        }
    }

    //Routine for active powerup
    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicator.SetActive(false);
    }

    //Move player based on input
    void MovePlayer()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float boostInput = Input.GetAxis("Jump");

        playerRb.AddForce(focalPoint.transform.forward * speed * verticalInput * (1 + boostInput) * Time.deltaTime);
        
        //Powerup indicator follows player around
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }

}
