using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class DropDownSettings : MonoBehaviour
{
    public RectTransform menuPanel; // Ссылка на RectTransform панели
    public Button settingsButton;   // Ссылка на кнопку "настройки"
    public float animationDuration = 0.5f; // Длительность анимации
    private Vector2 hiddenPosition; // Позиция, где меню спрятано
    private Vector2 visiblePosition; // Позиция, где меню видно
    private bool isMenuVisible = false; // Флаг для отслеживания видимости меню

    void Start()
    {
        // Убедитесь, что все ссылки установлены
        if (menuPanel == null)
        {
            Debug.LogError("Menu Panel is not assigned!");
            return;
        }
        
        if (settingsButton == null)
        {
            Debug.LogError("Settings Button is not assigned!");
            return;
        }

        settingsButton.onClick.AddListener(ToggleMenu);

        float panelHeight = menuPanel.rect.height;

        hiddenPosition = new Vector2(menuPanel.anchoredPosition.x, panelHeight);
        visiblePosition = new Vector2(menuPanel.anchoredPosition.x, -69f);
        
        menuPanel.anchoredPosition = hiddenPosition;
    }

    void ToggleMenu()
    {
        if (isMenuVisible)
        {
            menuPanel.DOAnchorPos(hiddenPosition, animationDuration).SetEase(Ease.InOutQuad);
        }
        else
        {
            menuPanel.DOAnchorPos(visiblePosition, animationDuration).SetEase(Ease.InOutQuad).SetEase(Ease.OutBounce,3f, 4f);
        }

        isMenuVisible = !isMenuVisible;
    }
}
