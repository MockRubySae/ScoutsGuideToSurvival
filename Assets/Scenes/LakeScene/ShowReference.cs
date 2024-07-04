using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShowReference : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject puzzleRef;
    // Start is called before the first frame update
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (puzzleRef != null)
        {
            puzzleRef.SetActive(true);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (puzzleRef != null)
        {
            puzzleRef.SetActive(false);
        }
    }
}
