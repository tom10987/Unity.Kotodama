
using UnityEngine;


public class ManholeGimmick : MonoBehaviour {

  PlayerState state { get { return PlayerState.instance; } }
  PopUpCanvas popupCanvas { get { return PopUpCanvas.instance; } }

  void OnTriggerStay(Collider other) {
    if (other.gameObject.tag != ObjectTag.Player.ToString()) { return; }

    Ray ray = Camera.main.ScreenPointToRay(TouchController.GetTouchScreenPosition());
    RaycastHit hit;
    float maxDistance = 150f;

    if (Physics.Raycast(ray, out hit, maxDistance)) {
      if (TouchController.IsTouchBegan()) {
        state.Stop();
        popupCanvas.CreatePopUpWindowVerGimmick("文字", Test);
      }
    }
    else { popupCanvas.CreatePopUpWindow("判定が失敗してます"); }
  }

  public void Test() { }
}
