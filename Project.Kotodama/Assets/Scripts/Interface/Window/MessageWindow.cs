
using UnityEngine;
using UnityEngine.UI;

public class MessageWindow : MonoBehaviour, IWindow {

  [SerializeField]
  Text _message = null;
  public Text message { get { return _message; } }

  [SerializeField]
  CanvasGroup _group = null;
  public CanvasGroup group { get { return _group; } }

  public GameObject instance { get { return gameObject; } }
}
