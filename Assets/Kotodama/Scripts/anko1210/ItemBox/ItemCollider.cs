
using UnityEngine;


public class ItemCollider : MonoBehaviour {

  PopUpCanvas popupCanvas { get { return PopUpCanvas.instance; } }

  void OnCollisionEnter(Collision other) {
    if (other.gameObject.tag != ObjectTag.player) { return; }
    /// 中身
    var itemState = gameObject.GetComponent<ItemState>();
    var effect = gameObject.GetComponent<ParticleSystem>();
    var collider = gameObject.GetComponent<Collider>();
    itemState.UpdateState(true);
    popupCanvas.CreatePopUpWindowVerItem(ItemData.ToString(itemState.itemName));
    collider.isTrigger = true;
    effect.loop = false;
  }

  void OnCollisionExit() {
    popupCanvas._count = 1f;
    popupCanvas.IsCancel();
  }
}
