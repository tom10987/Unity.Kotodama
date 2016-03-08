
using UnityEngine;
using UnityEngine.UI;


public class CommandWindow : MonoBehaviour {

  [SerializeField]
  Text _message = null;
  public Text message { get { return _message; } }

  [SerializeField]
  CanvasGroup _group = null;
  public CanvasGroup group { get { return _group; } }

  [SerializeField]
  Button _yes = null;
  public Button yes { get { return _yes; } }

  [SerializeField]
  Button _no = null;
  public Button no { get { return _no; } }
}
