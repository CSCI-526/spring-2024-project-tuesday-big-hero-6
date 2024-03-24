using UnityEngine;

public class TrapTrigger : MonoBehaviour
{
    public ArrowLauncher[] arrowLaunchers;

    private void OnTriggerEnter2D(Collider2D other)
    {

        foreach (var launcher in arrowLaunchers)
         {
                launcher.TryLaunchArrow();
        }
        
    }
}

