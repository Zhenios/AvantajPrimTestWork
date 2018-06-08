using UnityEngine;
using UnityEngine.EventSystems;

public class ChangePlatformColor : MonoBehaviour, IPointerClickHandler {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ChangeColor();
    }

    #region Input Handler

    public void OnPointerClick(PointerEventData eventData)
    {
        ChangeColor();
    }

    #endregion

    public void ChangeColor()
    {
        float r;
        float g;
        float b;

        r = Random.Range(0f, 1f);
        g = Random.Range(0f, 1f);
        b = Random.Range(0f, 1f);

        gameObject.GetComponent<SpriteRenderer>().color = new Color(r, g, b); //set random color for platform

    }

}
