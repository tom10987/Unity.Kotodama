
using UnityEngine;

//------------------------------------------------------------
// TIPS:
// メニュー画面を表示するときに取得済みアイテムをウィンドウに登録する
// ItemIcon が Start() で scale の調整を行うため、Awake() で初期化を行う
//
//------------------------------------------------------------

public class ItemIconViewer : MonoBehaviour {

  void Awake() {
    foreach (var item in ItemManager.instance.items) {
      var instance = Instantiate(item.data);
      instance.transform.SetParent(transform);
      instance.state.interactable = !item.useItem;
    }
  }
}
