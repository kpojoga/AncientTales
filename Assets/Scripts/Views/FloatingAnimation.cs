using UnityEngine;
using DG.Tweening;

public class FloatingAnimation : MonoBehaviour
{
    public float floatDistance = 20f; // Расстояние парения вверх и вниз
    public float duration = 2f; // Время для одного цикла (вверх и вниз)

    private void Start()
    {
        StartFloating();
    }

    private void StartFloating()
    {
        // Запуск анимации парения вверх
        transform.DOMoveY(transform.position.y + floatDistance, duration)
            .SetEase(Ease.InOutSine) // Используем синусоидальную кривую для плавности
            .SetLoops(-1, LoopType.Yoyo); // Бесконечный цикл вверх-вниз
    }
}