using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BotthonFuntion : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject targetObject; 

    public Animator animator;

    private void Start()
    {
        animator = targetObject.GetComponent<Animator>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        animator.SetBool("Cheer", true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        animator.SetBool("Cheer", false);
    }
}
