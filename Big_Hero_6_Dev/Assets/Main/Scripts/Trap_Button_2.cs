using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_Button_2 : MonoBehaviour
{
    public GameObject targetObject; // �����ײ��Ŀ�����
    private bool isTouching = false; // �Ƿ����ڽӴ�
    private float touchTime = 0.0f; // ����ʱ��
    private float requiredTouchTime = 0.0f; // ��Ҫ�Ĵ���ʱ�䣬����2��
    private bool hasChangedHeight = false; // �Ƿ��Ѹı���
    private Vector3 originalScale; // ԭʼ�ߴ�
    private Vector3 originalPosition; // ԭʼλ��

    private void Start()
    {
        originalScale = targetObject.transform.localScale; // �ڿ�ʼʱ����ԭʼ�ߴ�
        originalPosition = targetObject.transform.position; // �ڿ�ʼʱ����ԭʼλ��
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        // ����Ƿ����ض��Ķ���
        if (other.gameObject == targetObject)
        {
            isTouching = true;
            SpriteRenderer spriteRenderer = targetObject.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.color = Color.green;
            }
            Debug.Log("Object has stopped touching with the target object.");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // ����Ƿ����ض��Ķ���
        if (other.gameObject == targetObject)
        {
            SpriteRenderer spriteRenderer = targetObject.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.color = Color.red;
            }

            isTouching = false;
            if (hasChangedHeight)
            {
                targetObject.transform.localScale = originalScale; // ��ԭԭʼ�ߴ�
                targetObject.transform.position = originalPosition; // ��ԭԭʼλ��
                hasChangedHeight = false; // ���ø߶ȸı��־
                Debug.Log("Target object height has been restored.");
            }
            Debug.Log("Object has stopped touching with the target object.");
        }
    }

    private void Update()
    {
        if (isTouching)
        {
            touchTime += Time.deltaTime; // �ۼӴ���ʱ��

            // ����Ƿ�ﵽ�˸ı��ȵ�����
            // ����Ƿ�ﵽ�˸ı�߶ȵ�����
            if (touchTime >= requiredTouchTime && !hasChangedHeight)
            {
                hasChangedHeight = true; // ���Ϊ�Ѹı�߶�
                Vector3 scale = targetObject.transform.localScale;
                Vector3 position = targetObject.transform.position;

                float originalHeight = originalScale.y; // ʹ�ñ����ԭʼ�߶�
                float heightReduction = 0.2f; // �߶ȼ��ٵİٷֱȣ�����80%��
                float newHeight = originalHeight * heightReduction; // �����µĸ߶�

                scale.y = newHeight; // ���¸߶�
                position.y -= (originalHeight - newHeight) / 2; // �����ƶ��Ա��ֵײ�λ�ò���

                targetObject.transform.localScale = scale;
                targetObject.transform.position = position;

                Debug.Log("Target object height has been reduced from the top.");
            }
        }
    }
}
