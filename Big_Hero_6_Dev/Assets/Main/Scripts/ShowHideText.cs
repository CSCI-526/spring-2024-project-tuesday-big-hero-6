using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowHideText : MonoBehaviour
{
    public TextMeshProUGUI instructionText;

    private void Start()
    {
        instructionText.gameObject.SetActive(true);
        Invoke("HideText", 2f);
    }

    void HideText()
    {
        instructionText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            instructionText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            instructionText.gameObject.SetActive(false);
        }
    }
}
