using UnityEngine;

public class Door_part2 : MonoBehaviour
{
    public float speed = 1.0f; // 控制移动速度
    private float distanceMoved = 0.0f; // 已经移动的距离
    private float totalDistance = 4.0f; // 总共需要移动的距离
    public bool hasMoved = false;

    void Update()
    {

        if (Global_Button.part2_button)
        {
            // 向左移动
            if (distanceMoved < totalDistance)
            {
                float step = 2*speed * Time.deltaTime;
                float distanceToMove = Mathf.Min(step, totalDistance - distanceMoved);
                transform.position += Vector3.left * distanceToMove;
                distanceMoved += distanceToMove;
                hasMoved = true;
            }
        }
        else if (hasMoved)
        {
            // 向右移动回到起始位置
            if (distanceMoved > 0.0f)
            {
                float step = speed * Time.deltaTime/2;
                // 确保不会超过起始位置
                float distanceToMove = Mathf.Min(step, distanceMoved);
                transform.position += Vector3.right * distanceToMove;
                distanceMoved -= distanceToMove;

                // 如果距离移动回到了起始点或更少，则重置hasMoved标志
                if (distanceMoved <= 0)
                {
                    hasMoved = false;
                    distanceMoved = 0;
                }
            }
        }

    }
}
