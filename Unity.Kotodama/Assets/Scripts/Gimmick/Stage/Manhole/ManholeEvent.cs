
using UnityEngine;

public class ManholeEvent : MonoBehaviour {

  [SerializeField]
  ItemType _keyItem = ItemType.Empty;
  public ItemType keyItem { get { return _keyItem; } }
  public bool existKeyItem { get { return _keyItem != ItemType.Empty; } }
}
