using UnityEngine;

public class PauseGameOnEnter_Tutorial : MonoBehaviour
{
    public GameObject winGameObject;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Game Pause");
            Time.timeScale = 0;
            winGameObject.SetActive(true);
        }
    }
}
