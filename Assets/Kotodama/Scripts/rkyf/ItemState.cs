
using UnityEngine;


public class ItemState : MonoBehaviour {

  ItemManager manager { get { return ItemManager.instance; } }

  [SerializeField]
  Sprite _sprite = null;
  public Sprite sprite { get { return _sprite; } }

  [SerializeField]
  ItemName _itemName = ItemName.Empty;
  public ItemName itemName { get { return _itemName; } }

  [SerializeField]
  [Multiline(2)]
  string _itemInfo = string.Empty;
  public string itemInfo { get { return _itemInfo; } }

  public bool hasItem { get; private set; }


  void Start() {
    hasItem = false;
    manager.items.Add(_itemName, this);
  }
}
