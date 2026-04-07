using UnityEngine;
using UnityEngine.Video; // 必須引入影片函式庫

public class VideoSwitcher : MonoBehaviour
{
    [Header("把 Quad 上的 Video Player 拖到這裡")]
    public VideoPlayer videoPlayer;

    [Header("放入你的 3 支影片")]
    public VideoClip[] playlist;

    private int currentIndex = 0;

    void Update()
    {
        // 偵測按下 C 鍵
        if (Input.GetKeyDown(KeyCode.C))
        {
            SwitchToNextVideo();
        }
    }

    void SwitchToNextVideo()
    {
        // 防呆：如果沒放影片就跳出
        if (playlist.Length == 0) return;

        // 計算下一支影片的索引 (0, 1, 2 然後回到 0)
        currentIndex = (currentIndex + 1) % playlist.Length;

        // 停止目前的播放並更換影片來源
        videoPlayer.Stop();
        videoPlayer.clip = playlist[currentIndex];

        // 開始播放新影片
        videoPlayer.Play();

        Debug.Log("現在正在播放第 " + (currentIndex + 1) + " 支影片：" + playlist[currentIndex].name);
    }
}