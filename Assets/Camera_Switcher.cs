using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    // 在 Inspector 中把兩個 Controller 拖曳到這裡
    public GameObject fpsController;
    public GameObject tpsController;
    public GameObject tpsCameraRig; // 第三人稱的跟隨攝影機

    private bool isFirstPerson = true;

    void Start()
    {
        // 遊戲開始時，預設開啟第一人稱，關閉第三人稱
        EnableFirstPerson();
    }

    void Update()
    {
        // 按下鍵盤 V 鍵進行切換
        if (Input.GetKeyDown(KeyCode.V))
        {
            isFirstPerson = !isFirstPerson;

            if (isFirstPerson)
                EnableFirstPerson();
            else
                EnableThirdPerson();
        }
    }

    void EnableFirstPerson()
    {
        fpsController.SetActive(true);
        tpsController.SetActive(false);
        if (tpsCameraRig != null) tpsCameraRig.SetActive(false);
    }

    void EnableThirdPerson()
    {
        fpsController.SetActive(false);
        tpsController.SetActive(true);
        if (tpsCameraRig != null) tpsCameraRig.SetActive(true);
    }
}
