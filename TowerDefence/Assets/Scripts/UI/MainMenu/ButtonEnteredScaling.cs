using UnityEngine;
using UnityEngine.EventSystems;

namespace UI.MainMenu
{
    public class ButtonEnteredScaling : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private Vector3 _newScale = new(1.2f,1.2f,1.2f);
        [SerializeField] private float _duration = 0.5f;
        
        public void OnPointerEnter(PointerEventData eventData)
        {
            LeanTween.scale(gameObject, _newScale,_duration).setEaseOutExpo();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            LeanTween.scale(gameObject, new Vector3(1f,1f,1f), _duration).setEaseOutExpo();
        }
    }
}