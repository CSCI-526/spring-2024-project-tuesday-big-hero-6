using UnityEngine;

public class PauseGameOnEnter : MonoBehaviour
{
    public GameObject winGameObject;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && Global.yellowKey && Global.redKey)
        {
            Debug.Log("Game Pause");
            Time.timeScale = 0;
            winGameObject.SetActive(true);
        }
    }
}
