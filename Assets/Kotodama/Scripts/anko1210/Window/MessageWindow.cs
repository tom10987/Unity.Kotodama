
using UnityEngine;
using UnityEngine.UI;


public class MessageWindow : MonoBehaviour {

  [SerializeField]
  Text _message = null;
  public Text message { get { return _message; } }

  [SerializeField]
  CanvasGroup _group = null;
  public CanvasGroup group { get { return _group; } }

  public string text { get; set; }

  /// <summary> アイテム取得用：テキストを連結して出力する </summary>
  public string ItemMessage(string text) { return text + " を手に入れました"; }
}
