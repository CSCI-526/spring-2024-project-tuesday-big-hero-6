using UnityEngine;

public class FloorDisappear : MonoBehaviour
{
    public GameObject pauseText;
    private float delay = 0.7f; 
    private float timer = 0; 
    private bool isTriggered = false;

    private void Update()
    {

        // wait for few seconds
        if (isTriggered)
        {


            timer += Time.deltaTime;

            if (timer >= delay)
            {
                Destroy(gameObject);
                Time.timeScale = 0; // pause game
                pauseText.SetActive(true); // give tips

                isTriggered = false;
                timer = 0;
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetComponent<Renderer>().enabled = false;
            isTriggered = true;
            DevPlayerMovement_Tutorial.couldJump = true;
        }
    }
}
