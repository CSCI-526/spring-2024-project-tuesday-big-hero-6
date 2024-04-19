using UnityEngine;
using System.Collections;

public class But3_Detector : MonoBehaviour
{

    public GameObject targetObject; // 您希望检测碰撞的目标对象
    public GameObject visibleFloor;
    public GameObject[] traps;

    private bool isTouching = false; // 是否正在接触
    private float touchTime = 0.0f; // 触碰时间
    private float requiredTouchTime = 0.0f; // 需要的触碰时间，例如2秒
    private bool hasChangedWidth = false; // 是否已改变宽度
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
        Debug.Log("Attached1");
        if (other.gameObject == targetObject)
        {
            SpriteRenderer spriteRenderer = targetObject.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.color = Color.green; 
            }
            visibleFloor.SetActive(false);
            Debug.Log("Attached2");
            Global_Button.part3_button = true; // 设置为true表示物体正在接触
            isTouching = true;
            Debug.Log("Object has started touching with the target object.");
            foreach (var trap in traps)
            {
                trap.SetActive(true);
            }
        }
    }

    public static void changeBack()
    {

    }


    private void OnTriggerExit2D(Collider2D other)
   {
       if (other.gameObject == targetObject)
       {
           SpriteRenderer spriteRenderer = targetObject.GetComponent<SpriteRenderer>();
           if (spriteRenderer != null)
           {
               spriteRenderer.color = Color.red;
           }

           Global_Button.part3_button = false;
           isTouching = false;

           if (hasChangedWidth)
           {
               targetObject.transform.localScale = originalScale; // 还原原始尺寸
               targetObject.transform.position = originalPosition; // 还原原始位置
               hasChangedWidth = false;
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
            if (touchTime >= requiredTouchTime && !hasChangedWidth)
            {
                hasChangedWidth = true; // 标记为已改变宽度
                Vector3 scale = targetObject.transform.localScale;
                Vector3 position = targetObject.transform.position;

                float originalWidth = originalScale.x; // 使用保存的原始宽度
                float widthReduction = 0.7f; // 高宽度减少的百分比（减少80%）
                float newWidth = originalWidth * widthReduction; // 计算新的宽度

                scale.x = newWidth; // 更新宽度
                position.x += (originalWidth - newWidth) / 2; // 向上移动以保持底部位置不变
                
                targetObject.transform.localScale = scale;
                targetObject.transform.position = position; ;
                Debug.Log("Target object width has been reduced.");
            }
        }
    }
}
