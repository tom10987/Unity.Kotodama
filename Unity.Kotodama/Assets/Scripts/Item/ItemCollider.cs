
using UnityEngine;


public class ItemCollider : MonoBehaviour {

  WindowManager window { get { return WindowManager.instance; } }

  new Collider collider { get { return GetComponent<Collider>(); } }
  ParticleSystem effect { get { return GetComponent<ParticleSystem>(); } }
  ItemState itemState { get { return GetComponent<ItemState>(); } }

  void OnTriggerEnter(Collider other) {
    if (other.tag != ObjectTag.Player.ToString()) { return; }

    effect.loop = false;
    collider.enabled = false;

    var item = itemState;
    item.hasItem = true;
    window.CreateMessageWindow(ItemData.ToString(item.itemName), true);
  }
}
