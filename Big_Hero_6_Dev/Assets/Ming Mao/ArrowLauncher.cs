using UnityEngine;
using System.Collections;

public class ArrowLauncher : MonoBehaviour
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
            statusIndicator.color = Color.red;
        }
    }

    private void SetIndicatorReloading()
    {
        if (statusIndicator != null)
        {
            statusIndicator.color = Color.green;
        }
    }
}


