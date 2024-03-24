using UnityEngine;

public class But1_Detector : MonoBehaviour
{
    
    public GameObject targetObject; // 您希望检测碰撞的目标对象

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 检查是否是特定的对象
        if (other.gameObject == targetObject)
        {
            Global_Button.part1_button = true; // 设置为true表示物体正在接触
            Debug.Log("Object has started touching with the target object.");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // 检查是否是特定的对象
        if (other.gameObject == targetObject)
        {
            Global_Button.part1_button = false; // 设置为false表示物体不再接触
            Debug.Log("Object has stopped touching with the target object.");
        }
    }
}
