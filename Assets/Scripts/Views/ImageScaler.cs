using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[RequireComponent(typeof(RectTransform))]
public class ImageScaler : MonoBehaviour
{
    public Transform zoomTrigger; // Объект ZoomTrigger
    public float maxScale = 1.2f; // Максимальный масштаб при минимальном расстоянии
    public float minScale = 1.0f; // Исходный масштаб при максимальном расстоянии
    public float maxDistance = 500f; // Максимальное расстояние для вычисления масштаба (можно настроить по необходимости)

    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        UpdateScale();
    }

    void UpdateScale()
    {
        if (zoomTrigger == null)
        {
            return;
        }

        // Вычисляем расстояние до ZoomTrigger
        float distance = Vector3.Distance(rectTransform.position, zoomTrigger.position);

        // Нормализуем расстояние
        float normalizedDistance = Mathf.Clamp01(distance / maxDistance);

        // Интерполируем масштаб
        float scale = Mathf.Lerp(minScale, maxScale, 1 - normalizedDistance);

        // Применяем масштаб
        rectTransform.localScale = new Vector3(scale, scale, 1);
    }
}