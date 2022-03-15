using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    public float speed;
    private float verticalInput;
    public GameObject focalPoint;
    public bool isPowerUpActive;
    public float powerupStrength;
    public GameObject powerupIndicator;
    

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        powerupIndicator.transform.position = transform.position;


    }
    private void FixedUpdate()
    {
        playerRB.AddForce(focalPoint.transform.forward * speed*verticalInput);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            isPowerUpActive = true;
            powerupIndicator.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutline());
            
        }
    }

    private IEnumerator PowerupCountdownRoutline()
    {
        yield return new WaitForSeconds(5);
        isPowerUpActive = false;
        powerupIndicator.SetActive(false);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && isPowerUpActive)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();

            Vector3 awayFromPlayer = (collision.transform.position - transform.position).normalized;

            enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);

        }
    }
}
