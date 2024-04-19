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
        // ��ȡBoxCollider2D���
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision Detected");

        if (boxCollider != null)
        {
            boxCollider.enabled = false;
            StartCoroutine(ReenableColliderAfterDelay(1.0f)); // 3�������������ײ��
        }

        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player has collided with the button");

            // ����Ŀ�������Trigger�������������
            ITriggerable triggerableComponent = target.GetComponent<ITriggerable>();
            if (triggerableComponent != null)
            {
                triggerableComponent.Trigger();
            }

            // �ڵ�һ����ײ�����BoxCollider2D

        }
    }

    private IEnumerator ReenableColliderAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // �ȴ�ָ�����ӳ�ʱ��
        if (boxCollider != null)
        {
            boxCollider.enabled = true; // ��������BoxCollider2D
        }
    }
}
