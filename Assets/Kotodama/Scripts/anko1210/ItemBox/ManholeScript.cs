using UnityEngine;

public class ManholeGimmick: MonoBehaviour {

    PlayerStatus state { get { return PlayerStatus.instance; } }
    PopUpCanvas popupCanvas { get { return PopUpCanvas.instance; } }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag.Equals(ObjectTag.player))
        {
            Ray ray = Camera.main.ScreenPointToRay(TouchController.GetTouchScreenPosition());
            RaycastHit hit;
            float maxDistance = 150f;

            if (Physics.Raycast(ray, out hit, maxDistance))
            {
                if (TouchController.IsTouchBegan())
                {
                    state.MoveStop();
                    popupCanvas.CreatePopUpWindowVerGimmick("文字", Test);
                }
            }
            else { popupCanvas.CreatePopUpWindow("判定が失敗してます"); }
        }
    }

    public void Test()
    {
    }
}
