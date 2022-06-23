using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float speed = 500.0f;
    private Rigidbody enemyRb;
    public GameObject player;
    private float yDestroy = -10.0f;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // Set enemy direction towards player and move there
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed * Time.deltaTime);
        if (transform.position.y < yDestroy)
        {
            Destroy(gameObject);
        }
    }
}
