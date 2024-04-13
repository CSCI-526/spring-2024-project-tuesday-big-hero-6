using UnityEngine;
using System.Collections;

public class VerticalArrowLauncher : MonoBehaviour
{
    public GameObject arrowPrefab;
    public Transform launchPoint;
    public SpriteRenderer statusIndicator;
    public float reloadTime = 5f;
    private bool isLoaded = true;

    private void Start()
    {
        SetIndicatorLoaded();
    }

    public void TryLaunchArrow()
    {
        if (isLoaded)
        {
            LaunchArrow();
            StartCoroutine(Reload());
        }
    }

    private void LaunchArrow()
    {
        Debug.Log("Launching arrow from: " + launchPoint.position);
        Instantiate(arrowPrefab, launchPoint.position, Quaternion.identity);
        isLoaded = false;
    }

    private IEnumerator Reload()
    {
        SetIndicatorReloading();
        yield return new WaitForSeconds(reloadTime);
        isLoaded = true;
        SetIndicatorLoaded();
    }

    private void SetIndicatorLoaded()
    {
        if (statusIndicator != null)
        {
            statusIndicator.color = Color.red; // Loaded
        }
    }

    private void SetIndicatorReloading()
    {
        if (statusIndicator != null)
        {
            statusIndicator.color = Color.green; // Reloading
        }
    }
}

