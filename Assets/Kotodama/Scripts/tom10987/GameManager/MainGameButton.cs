
using UnityEngine;
using UnityEngine.SceneManagement;


public interface MenuAction : GoTitleAction {
  void Back(GameObject instance);
}


public interface OpenAction {
  void MenuOpen(GameObject instance);
}


public interface GameOverAction : GoTitleAction {
  void Retry(GameObject instance);
  void Quit(GameObject instance);
}


public interface GoTitleAction {
  void GoTitle(GameObject instance);
}


public class MainGameButton : SingletonBehaviour<MainGameButton>,
  MenuAction, OpenAction, GameOverAction {

  public void Back(GameObject instance) {
    Destroy(instance);
    GameManager.instance.ReStart();
  }

  public void Retry(GameObject instance) {
    Destroy(instance);
    SceneSequencer.instance.SceneFinish(SceneManager.GetActiveScene().name);
  }

  public void Quit(GameObject instance) {
    Destroy(instance);
    Application.Quit();
  }

  public void GoTitle(GameObject instance) {
    Destroy(instance);
    SceneSequencer.instance.SceneFinish(SceneTag.Title.ToString());
  }

  public void MenuOpen(GameObject instance) {
    Instantiate(instance);
    PlayerState.instance.Stop();
    GameManager.instance.Pause();
  }
}
