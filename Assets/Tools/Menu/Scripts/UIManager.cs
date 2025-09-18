using UnityEngine;
using UnityEngine.UI;

namespace Extensions
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private string _url;
        
        private void Awake()
        {
            GetComponent<Button>().onClick.AddListener(OpenWebView);
        }

        public void OpenWebView()
        {
            Application.OpenURL(_url);
        }
    }
}
