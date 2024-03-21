using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingGel : MonoBehaviour
{
    public GameObject objectToShoot;
    public float shootForce = 1000f;
    public Transform shootPointForward;
    public Transform shootPointBackward;
    public Transform shootPointUpside;
    public Transform shootPointDownside;
    private float horizontalInput;
    private float verticalInput;
    private int shootNum = 1;
    
    
    void Update()
    {
        
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        Debug.Log(horizontalInput);
        Debug.Log(verticalInput);
        
        if (Input.GetKeyDown(KeyCode.K))
        {
            Shoot();
        }
    }
    IEnumerator setGelNumBack()
    {
        yield return new WaitForSeconds(5);
        shootNum = 1;
    }

    void Shoot()
    {
        if (shootNum == 1)
        {
            if (horizontalInput >= 0 && verticalInput == 0)
            {
                GameObject shotObject =
                    Instantiate(objectToShoot, shootPointForward.position, shootPointForward.rotation);
                shootNum = 0;
                if (shotObject.TryGetComponent<Rigidbody>(out Rigidbody rb))
                {
                    rb.AddForce(shootPointForward.forward * shootForce);
                }

                Destroy(shotObject, 5f);
                StartCoroutine(setGelNumBack());
            }
            else if (horizontalInput < 0)
            {
                GameObject shotObject =
                    Instantiate(objectToShoot, shootPointBackward.position, shootPointBackward.rotation);
                shootNum = 0;
                if (shotObject.TryGetComponent<Rigidbody>(out Rigidbody rb))
                {
                    rb.AddForce(shootPointBackward.forward * shootForce);
                }

                Destroy(shotObject, 5f);
                StartCoroutine(setGelNumBack());
            }
            else if (verticalInput > 0)
            {
                GameObject shotObject =
                    Instantiate(objectToShoot, shootPointUpside.position, shootPointUpside.rotation);
                shootNum = 0;
                if (shotObject.TryGetComponent<Rigidbody>(out Rigidbody rb))
                {
                    rb.AddForce(shootPointUpside.forward * shootForce);
                }

                Destroy(shotObject, 5f);
                StartCoroutine(setGelNumBack());
            }
            else if (verticalInput < 0)
            {
                GameObject shotObject =
                    Instantiate(objectToShoot, shootPointDownside.position, shootPointDownside.rotation);
                shootNum = 0;
                if (shotObject.TryGetComponent<Rigidbody>(out Rigidbody rb))
                {
                    rb.AddForce(shootPointDownside.forward * shootForce);
                }

                Destroy(shotObject, 5f);
                StartCoroutine(setGelNumBack());
            }
        }
    }
}
