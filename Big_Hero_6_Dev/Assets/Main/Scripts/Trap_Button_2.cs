using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_Button_2 : MonoBehaviour
{
    public GameObject targetObject; // 检测碰撞的目标对象
    private bool isTouching = false; // 是否正在接触
    private float touchTime = 0.0f; // 触碰时间
    private float requiredTouchTime = 0.0f; // 需要的触碰时间，例如2秒
    private bool hasChangedHeight = false; // 是否已改变宽度
    private Vector3 originalScale; // 原始尺寸
    private Vector3 originalPosition; // 原始位置

    private void Start()
    {
        originalScale = targetObject.transform.localScale; // 在开始时保存原始尺寸
        originalPosition = targetObject.transform.position; // 在开始时保存原始位置
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        // 检查是否是特定的对象
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
        // 检查是否是特定的对象
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
                targetObject.transform.localScale = originalScale; // 还原原始尺寸
                targetObject.transform.position = originalPosition; // 还原原始位置
                hasChangedHeight = false; // 重置高度改变标志
                Debug.Log("Target object height has been restored.");
            }
            Debug.Log("Object has stopped touching with the target object.");
        }
    }

    private void Update()
    {
        if (isTouching)
        {
            touchTime += Time.deltaTime; // 累加触碰时间

            // 检查是否达到了改变宽度的条件
            // 检查是否达到了改变高度的条件
            if (touchTime >= requiredTouchTime && !hasChangedHeight)
            {
                hasChangedHeight = true; // 标记为已改变高度
                Vector3 scale = targetObject.transform.localScale;
                Vector3 position = targetObject.transform.position;

                float originalHeight = originalScale.y; // 使用保存的原始高度
                float heightReduction = 0.2f; // 高度减少的百分比（减少80%）
                float newHeight = originalHeight * heightReduction; // 计算新的高度

                scale.y = newHeight; // 更新高度
                position.y -= (originalHeight - newHeight) / 2; // 向上移动以保持底部位置不变

                targetObject.transform.localScale = scale;
                targetObject.transform.position = position;

                Debug.Log("Target object height has been reduced from the top.");
            }
        }
    }
}
