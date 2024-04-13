using UnityEngine;

public class FloorDisappear : MonoBehaviour
{
    public GameObject pauseText1;
    public GameObject pauseText2;
    public GameObject pauseImg;
    private float delay = 0.7f; 
    private float timer = 0; 
    public static bool isTriggered = false;
    public static int a = 1;

    private void Update()
    {

        // wait for few seconds
        if (isTriggered)
        {
            Debug.Log("Flooe Disappear");
            Destroy(gameObject);
            Time.timeScale = 0; // pause game
            pauseText1.SetActive(true); // give tips
            pauseText2.SetActive(true); 
            pauseImg.SetActive(true);
            isTriggered = false;
            timer = 0;

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
