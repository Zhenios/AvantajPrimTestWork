using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public GamePlayController playController;
    public PointerEventData pointerEventData;


    void FixedUpdate()
    {
        if (playController.tuchIsTrue)
        {
            playController.mousePosition.x = TransformPosition(pointerEventData).x; // transform mouse position to local position

            if (playController.playerRigidbody2D.position.x < playController.mousePosition.x) //if we touch the right side of the ball
            {
                playController.playerRigidbody2D.AddForce(new Vector2(playController.force, Physics2D.gravity.y)); 
            }
            else if (playController.playerRigidbody2D.position.x > playController.mousePosition.x) // if we touch the left side of the ball
            {
                playController.playerRigidbody2D.AddForce(new Vector2(-playController.force, Physics2D.gravity.y)); 
            }
        }
    }

    #region Input Handler

    public Vector2 TransformPosition(PointerEventData eventData)
    {
        Vector2 position = Vector2.zero;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(playController.touchAreaPatel, eventData.position, eventData.pressEventCamera, out position);

        position = playController.touchAreaPatel.TransformPoint(position);

        return position;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        pointerEventData = eventData;
        playController.tuchIsTrue = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        pointerEventData = eventData;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pointerEventData = eventData;
        playController.tuchIsTrue = false;
    }

    #endregion
}
