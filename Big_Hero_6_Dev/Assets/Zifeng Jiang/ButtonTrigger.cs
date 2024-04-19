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
    private BoxCollider2D boxCollider;

    private void Awake()
    {
        // 获取BoxCollider2D组件
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision Detected");

        if (boxCollider != null)
        {
            boxCollider.enabled = false;
            StartCoroutine(ReenableColliderAfterDelay(1.0f)); // 3秒后重新启用碰撞器
        }

        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player has collided with the button");

            // 触发目标组件的Trigger方法，如果存在
            ITriggerable triggerableComponent = target.GetComponent<ITriggerable>();
            if (triggerableComponent != null)
            {
                triggerableComponent.Trigger();
            }

            // 在第一次碰撞后禁用BoxCollider2D

        }
    }

    private IEnumerator ReenableColliderAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // 等待指定的延迟时间
        if (boxCollider != null)
        {
            boxCollider.enabled = true; // 重新启用BoxCollider2D
        }
    }
}
