using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal; // 注意：如果你是使用 HDRP，請改成 .HighDefinition

public class PartyVolume : MonoBehaviour
{
    [Header("拖曳你的 Local Volume 到這裡")]
    public Volume myVolume;

    [Header("設定派對顏色")]
    public Color[] colors = new Color[5]; // 預設 5 個顏色

    [Header("顏色切換速度")]
    public float changeSpeed = 2f;

    private ColorAdjustments colorAdjustments;
    private int currentIndex = 0;
    private float transitionProgress = 0f;

    void Start()
    {
        // 嘗試從 Volume 的 Profile 中抓取 Color Adjustments 元件
        if (myVolume.profile.TryGet(out colorAdjustments))
        {
            // 確保腳本有權限覆寫 Color Filter
            colorAdjustments.colorFilter.overrideState = true;
        }
    }

    void Update()
    {
        // 防呆機制：如果沒有抓到效果，或顏色不到兩個，就不執行
        if (colorAdjustments == null || colors.Length < 2) return;

        // 計算下一個顏色的索引 (使用 % 確保會在陣列內無限循環)
        int nextIndex = (currentIndex + 1) % colors.Length;

        // 隨時間推移增加進度
        transitionProgress += Time.deltaTime * changeSpeed;

        // 使用 Lerp (線性插值) 讓顏色平滑過渡
        colorAdjustments.colorFilter.value = Color.Lerp(colors[currentIndex], colors[nextIndex], transitionProgress);

        // 當一個顏色過渡完成 (進度 >= 1) 時，切換到下一組
        if (transitionProgress >= 1f)
        {
            transitionProgress = 0f;
            currentIndex = nextIndex;
        }
    }
}