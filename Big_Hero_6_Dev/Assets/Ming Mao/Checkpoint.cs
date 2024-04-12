using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour
{
    public SpriteRenderer CheckpointIndicator;


    private void Start()
    {
        CheckpointIndicator.color = Color.yellow;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CheckpointIndicator.color = Color.green;
            SaveManager.Instance.UpdateCheckpoint(transform.position);
        }
    }
}
