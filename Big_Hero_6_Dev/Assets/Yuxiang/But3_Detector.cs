using UnityEngine;

public class But3_Detector : MonoBehaviour
{

    public GameObject targetObject; // 您希望检测碰撞的目标对象
    public GameObject visibleFloor;
    public GameObject[] traps;
    private void OnTriggerEnter2D(Collider2D other)
    {
        // 检查是否是特定的对象
        Debug.Log("Attached1");
        if (other.gameObject == targetObject)
        {
            visibleFloor.SetActive(false);
            Debug.Log("Attached2");
            Global_Button.part3_button = true; // 设置为true表示物体正在接触
            Debug.Log("Object has started touching with the target object.");
            foreach (var trap in traps)
            {
                trap.SetActive(true);
            }

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // 检查是否是特定的对象
        if (other.gameObject == targetObject)
        {
            /*visibleFloor.SetActive(true);*/
            Global_Button.part3_button = false; // 设置为false表示物体不再接触
            Debug.Log("Object has stopped touching with the target object.");
        }
    }
}
