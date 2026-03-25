using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public GameObject menuUI;
    public CameraFollow cameraFollow;

    void Update()
    {
        if (Input.anyKeyDown || AnyMouseDown())
        {
            StartGame();
        }
    }

    bool AnyMouseDown()
    {
        return Input.GetMouseButtonDown(0) || // 좌클릭
               Input.GetMouseButtonDown(1) || // 우클릭
               Input.GetMouseButtonDown(2);   // 휠 클릭
    }

    void StartGame()
    {
        menuUI.SetActive(false);
        cameraFollow.isActive = true;
        enabled = false;
    }
}