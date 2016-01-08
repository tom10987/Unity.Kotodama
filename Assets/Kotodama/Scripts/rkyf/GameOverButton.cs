
using UnityEngine;


public class GameOverButton : MonoBehaviour {

  GameOverAction button { get { return MainGameButton.instance; } }

  public void OnRetry() { button.Retry(gameObject); }
  public void OnGoTitle() { button.GoTitle(gameObject); }
  public void OnQuit() { button.Quit(gameObject); }
}
