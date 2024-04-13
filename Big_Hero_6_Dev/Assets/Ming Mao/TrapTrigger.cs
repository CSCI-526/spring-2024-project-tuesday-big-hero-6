using UnityEngine;

public class TrapTrigger : MonoBehaviour
{
    public ArrowLauncher[] arrowLaunchers;
    public VerticalArrowLauncher[] verticalLaunchers;

    private void OnTriggerEnter2D(Collider2D other)
    {

        foreach (var launcher in arrowLaunchers)
         {
                launcher.TryLaunchArrow();
        }

        foreach (var launcher in verticalLaunchers)
        {
            launcher.TryLaunchArrow();
        }
    }
}

