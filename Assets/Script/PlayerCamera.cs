using UnityEngine;
using DG.Tweening;
using Cinemachine;

public class PlayerCamera : MonoBehaviour
{
    CinemachineVirtualCamera virtualCamera;
    [SerializeField] float maxDistance;

    PlayerGrip player;
    Rigidbody2D rb;

    private void OnEnable()
    {
        EventCenter.AddListener(FunctionType.StartBulletTime, StartBulletTime);
        EventCenter.AddListener(FunctionType.EndBulletTime, EndBulletTime);
    }
    void Start()
    {
        virtualCamera = Camera.main.GetComponentInChildren<CinemachineVirtualCamera>();

        player = GetComponentInParent<PlayerGrip>();
        rb = GetComponentInParent<Rigidbody2D>();
    }

    void Update()
    {
        float speed = Mathf.Clamp(rb.velocity.magnitude, 0, 40);
        Vector2 followPos = player.transform.position + (Vector3)rb.velocity.normalized * speed * (maxDistance / 40);
        transform.position = Vector2.MoveTowards(transform.position, followPos, Time.deltaTime * 10);

        if (!player.isBulletTime)
        {
            float size = 10 + (speed * 0.1f);
            virtualCamera.m_Lens.OrthographicSize = Mathf.MoveTowards(virtualCamera.m_Lens.OrthographicSize, size, Time.deltaTime * 5);
        }
    }
    void StartBulletTime()
    {
        float size = virtualCamera.m_Lens.OrthographicSize;

        DOTween.To(() => virtualCamera.m_Lens.OrthographicSize, x => virtualCamera.m_Lens.OrthographicSize = x, size - 2, 0.2f);
    }
    void EndBulletTime()
    {
        float size = virtualCamera.m_Lens.OrthographicSize;

        DOTween.To(() => virtualCamera.m_Lens.OrthographicSize, x => virtualCamera.m_Lens.OrthographicSize = x, size + 2, 0.2f);
    }
    private void OnDisable()
    {
        EventCenter.RemoveListener(FunctionType.StartBulletTime, StartBulletTime);
        EventCenter.RemoveListener(FunctionType.EndBulletTime, EndBulletTime);
    }
}
