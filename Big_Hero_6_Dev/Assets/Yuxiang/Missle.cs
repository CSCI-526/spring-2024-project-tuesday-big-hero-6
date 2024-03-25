using UnityEngine;

public class RepeatMoveLeft : MonoBehaviour
{
    public float speed = 14.0f; // 控制移动速度
    private float totalDistance = 7.0f; // 总共需要移动的距离
    private Vector3 startPosition; // 起始位置
    private float movedDistance = 0.0f; // 已经移动的距离

    void Start()
    {
        startPosition = transform.position; // 记录起始位置
    }

    void Update()
    {
        if (movedDistance < totalDistance)
        {
            float step = speed * Time.deltaTime; // 计算这一帧要移动的距离
            transform.position += Vector3.left * step; // 更新位置
            movedDistance += step; // 更新已经移动的距离
        }
        else
        {
            // 达到或超过总移动距离，重置位置和已移动距离
            transform.position = startPosition;
            movedDistance = 0.0f;
        }
    }
}
