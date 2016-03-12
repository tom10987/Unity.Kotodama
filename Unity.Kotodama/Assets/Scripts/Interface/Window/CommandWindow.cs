
using UnityEngine;
using UnityEngine.UI;

public class CommandWindow : MessageWindow {
  
  [SerializeField]
  Button _yes = null;
  public Button yes { get { return _yes; } }

  [SerializeField]
  Button _no = null;
  public Button no { get { return _no; } }
}
