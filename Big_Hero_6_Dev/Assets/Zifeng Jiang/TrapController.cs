using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : MonoBehaviour, ITriggerable
{
    public float moveDistance = 0.18f; // 移动距离
    public float moveSpeed = 1f; // 移动速度
    private Vector3 originalPosition; // 原始位置
    private Vector3 targetPosition; // 目标位置
    private bool isOpening = false; // 是否正在打开

    void Start()
    {
        originalPosition = transform.position; // 保存原始位置
        targetPosition = originalPosition + new Vector3(0, moveDistance, 0); // 计算目标位置
    }

    IEnumerator ResetPosition()
    {
        yield return new WaitForSeconds(5);
        transform.position = originalPosition;
        isOpening = false;
    }
    
    void Update()
    {
        if (isOpening)
        {
            // 移动门到目标位置
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            StartCoroutine(ResetPosition());
        }
    }

    public void Trigger()
    {
        Debug.Log("Door trigger called.");
        isOpening = true; // 触发打开门
    }
}
