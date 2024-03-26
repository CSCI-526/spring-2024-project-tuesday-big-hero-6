using UnityEngine;

public class L_SmoothRotate : MonoBehaviour
{
    public float rotationSpeed = 90.0f; // 每秒旋转速度
    private float totalRotation = 0.0f; // 已经旋转的总角度
    private Vector3 pivot; // 旋转中心点
    private bool hasRotated = false; // 是否已经旋转到目标位置
    public float reverseInterval = 5.0f;
    void Start()
    {
        // 计算旋转中心点，即最左侧边的中点
        float width = transform.localScale.x; // 获取游戏对象的宽度
        pivot = transform.position + new Vector3(width / 2, 0, 0);
    }

    void Update()
    {
        if (Global_Button.part1_button || Global_Button.part3_button)
        {
            if (totalRotation < 90.0f)
            {
                // 计算这一帧要旋转的角度
                float rotationThisFrame = 2*rotationSpeed * Time.deltaTime;
                transform.RotateAround(pivot, Vector3.forward, rotationThisFrame);
                totalRotation += rotationThisFrame;
                hasRotated = true;
            }
        }
        else
        {
            if (hasRotated && totalRotation > 0.0f)
            {
                // 旋转回初始位置
                float rotationThisFrame = rotationSpeed * Time.deltaTime/reverseInterval;
                transform.RotateAround(pivot, Vector3.forward, -rotationThisFrame);
                totalRotation -= rotationThisFrame;
                if (totalRotation <= 0.0f)
                {
                    hasRotated = false;
                    totalRotation = 0.0f; // 确保总旋转不会变成负数
                }
            }
        }
    }
}
