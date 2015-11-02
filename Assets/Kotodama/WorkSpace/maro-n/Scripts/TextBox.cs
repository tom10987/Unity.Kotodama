using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class TextBox : MonoBehaviour {

    public int MAX_TEXT = 4;

    const string RESOURCE_PATH = "/Kotodama/WorkSpace/maro-n/Resource/JSON/";

    [SerializeField]
    string JSON_PATH = "";

    private string[] _text;
    public int _current_text;
    public Text _textBox;

    void Awake()
    {
        _text = new string[MAX_TEXT];
    }

    void Start()
    {
        var text = File.ReadAllText(Application.dataPath + RESOURCE_PATH + JSON_PATH);

        JsonNode json = JsonNode.Parse(text);

        _current_text = 0;

        for (int i = 0; i < MAX_TEXT; ++i) {
            var temp_text = json["Texts"][i].Get<string>();

            _text[i] = temp_text;
            Debug.Log(_text[i]);
        }

        _textBox.text = _text[_current_text];
    }

    void TextUpdate()
    {
        var activeCanvas = GameObject.FindObjectOfType<CanvasActive>();

        if (activeCanvas.EventStart())
        {
            _textBox.text = _text[_current_text];

            if (Input.GetMouseButtonDown(0))
            {
                _current_text++;
            }
        }
    }

    void Update()
    {
        TextUpdate();
    }
}
