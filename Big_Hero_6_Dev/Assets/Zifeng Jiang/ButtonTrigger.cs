using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface ITriggerable
{
    void Trigger();
}


public class ButtonTrigger : MonoBehaviour
{
    public GameObject target;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision Detected");
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player has collided with the button");
            ITriggerable triggerableComponent = target.GetComponent<ITriggerable>();
            if (triggerableComponent != null)
            {
                triggerableComponent.Trigger();
            }
        }
    }
}




