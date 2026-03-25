using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 baseOffset = new Vector3(0, 20, 0);

    PlayerEat player;
    public bool isActive = false; // 추가

    void Start()
    {
        player = target.GetComponent<PlayerEat>();
    }

    void LateUpdate()
    {
        if (!isActive) return; // 시작 전엔 작동 X

        float size = player.size;

        Vector3 dynamicOffset = baseOffset * (0.7f + size * 0.3f);
        dynamicOffset.y = Mathf.Clamp(dynamicOffset.y, 0f, 190f);

        transform.position = target.position + dynamicOffset;
        transform.rotation = Quaternion.Euler(90f, 0f, 0f);
    }
}