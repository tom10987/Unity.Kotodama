
using UnityEngine;

public class ShrineEvent : MonoBehaviour {

  PlayerState player { get { return PlayerState.instance; } }

  [System.Serializable]
  class Event {
    public ItemType _keyAmulet = ItemType.Empty;
    public ItemIcon _keyItem = null;
  }

  [SerializeField]
  Event[] _events = null;

  void OnTriggerEnter(Collider other) {
    if (!ObjectTag.Player.EqualTo(other.tag)) { return; }

    foreach (var @event in _events) {
      var find = ItemManager.instance.GetItem(@event._keyAmulet);
      if (find != null) { ItemManager.instance.Add(@event._keyItem); }
    }
  }
}
