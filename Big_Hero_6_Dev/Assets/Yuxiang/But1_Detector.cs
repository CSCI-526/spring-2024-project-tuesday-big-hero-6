using UnityEngine;

public class But1_Detector : MonoBehaviour
{
    
    public GameObject targetObject; // 检测碰撞的目标对象
    private bool isTouching = false; // 是否正在接触
    private float touchTime = 0.0f; // 触碰时间
    private float requiredTouchTime = 0.0f; // 需要的触碰时间，例如2秒
    private bool hasChangedWidth = false; // 是否已改变宽度
    private Vector3 originalScale; // 原始尺寸

    private void Start()
    {
        originalScale = targetObject.transform.localScale; // 在开始时保存原始尺寸
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        // 检查是否是特定的对象
        if (other.gameObject == targetObject)
        {
            Global_Button.part1_button = true; // 设置为true表示物体正在接触
            isTouching = true;
            Debug.Log("Object has started touching with the target object.");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // 检查是否是特定的对象
        if (other.gameObject == targetObject)
        {
            Global_Button.part1_button = false; // 设置为false表示物体不再接触
            isTouching = false;
            if (hasChangedWidth)
            {
                targetObject.transform.localScale = originalScale; // 还原原始尺寸
                hasChangedWidth = false; // 重置宽度改变标志
                Debug.Log("Target object width has been restored.");
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
            if (touchTime >= requiredTouchTime && !hasChangedWidth)
            {
                hasChangedWidth = true; // 标记为已改变宽度
                Vector3 scale = targetObject.transform.localScale;
                scale.x *= 0.5f; // 减少50%的宽度
                targetObject.transform.localScale = scale;
                Debug.Log("Target object width has been reduced.");
            }
        }
    }
}
