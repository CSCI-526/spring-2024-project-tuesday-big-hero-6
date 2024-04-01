using UnityEngine;
using UnityEngine.UI; // 引入UI命名空间

public class ProgressBar : MonoBehaviour
{
    public Slider progressBar; // 引用UI中的Slider
    private float fillSpeed = 0.2f; // 进度条填充速度，决定了填充整个进度条需要的时间
    private float targetProgress = 0; // 目标进度值

    private void Start()
    {
        progressBar.value = 1; // 初始化进度条值为0
    }

    private void Update()
    {
        if (progressBar.value < targetProgress) // 如果当前进度小于目标进度，则逐渐填充
        {
            progressBar.value += fillSpeed * Time.deltaTime; // 根据填充速度更新进度条
        }
    }

    // 外部调用此方法以重置进度条并开始填充
    public void ResetAndFillProgressBar()
    {
        progressBar.value = 0; // 重置进度条值为0
        targetProgress = 1; // 设置目标进度为满值
    }
    
    public void SaveBackProgressBar()
    {
        progressBar.value = 1; // 重置进度条值为0
        targetProgress = 0; // 设置目标进度为满值
    }
}
