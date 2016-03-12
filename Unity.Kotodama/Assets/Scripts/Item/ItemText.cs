
using UnityEngine;
using UnityEngine.UI;

public class ItemText : SingletonBehaviour<ItemText> {

  [SerializeField]
  Text _itemName = null;
  public new Text name { get { return _itemName; } }

  [SerializeField]
  Text _itemInfo = null;
  public Text info { get { return _itemInfo; } }

  void Start() { gameObject.SetActive(false); }

  public void Activate() { gameObject.SetActive(true); }
}
