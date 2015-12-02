using UnityEngine;

public class CanvasActive : MonoBehaviour {

    // 使用するキャンバスとその生存確認
    public GameObject _adventureCanvas;
    public bool _activeCanvas = false;

    void Update()
    {
        if (EventStart())
        {
            // キャンバスを反映する
            _activeCanvas = true;
        }

        if (EventEnd())
        {
            //　キャンバスを反映させない
            _activeCanvas = false;
        }

        //　キャンバスの生死を_activeCanvasにゆだねる
        _adventureCanvas.GetComponent<Canvas>().enabled = _activeCanvas;
    }

    public bool EventStart()
    {
        // もし、アドベンチャーパートがスタートしたら　という条件に変えてください
        if (Input.GetMouseButton(1))
        {
            return true;
        }
        return false;
    }

    public bool EventEnd()
    {
        var text = FindObjectOfType<Adventure>();
       
        // その会話が最後だったら ※MAX_TEXT - 1 なのは　TEXTS　の中にENDフラグを入れてるから
        if (text._current_text == text.MAX_TEXT - 1)
        {
            Debug.Log("EventEnd()" + text._current_text);
            return true;
        }

        return false;
    }

}


