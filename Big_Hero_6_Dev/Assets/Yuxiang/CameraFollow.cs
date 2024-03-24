using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // 目标GameObject的Transform
    public float smoothSpeed = 0.125f; // 摄像机跟随的平滑速度
    public Vector3 offset; // 摄像机与目标GameObject之间的偏移量

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset; // 计算摄像机的目标位置
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); // 平滑过渡到目标位置
        smoothedPosition.z = transform.position.z; // 保持摄像机的原始Z坐标不变

        transform.position = smoothedPosition; // 更新摄像机的位置
    }
}
