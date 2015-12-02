using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections.Generic;

public class Adventure : MonoBehaviour
{

    public int MAX_TEXT = 4;

    const string RESOURCE_PATH = "/Kotodama/Resources/JSON/";

    [SerializeField]
    string JSON_PATH = "";

    //private string[] _text;
    public int _current_text;
    public Text _textBox;
    private List<string> _texts;
    private List<string> _speakers;

    void Awake()
    {
        _current_text = 0;
        //_text = new string[MAX_TEXT];
        _texts = new List<string>();
        _speakers = new List<string>();
    }

    void Start()
    {
        var text = File.ReadAllText(Application.dataPath + RESOURCE_PATH + JSON_PATH);

        JsonNode json = JsonNode.Parse(text);

        for (int i = 0; i < MAX_TEXT; ++i)
        {
            _speakers.Add(json["Texts"][i]["speaker"].Get<string>());
            Debug.Log(_speakers[i]);
            _texts.Add(json["Texts"][i]["text"].Get<string>());
            Debug.Log(_texts[i]);

            if (_speakers[i] != "")
            {
                _speakers[i] += "\n";
            }
            _texts[i] = _speakers[i] + _texts[i];
        }
    }

    void TextUpdate()
    {
        var activeCanvas = FindObjectOfType<CanvasActive>();

        if (activeCanvas.EventStart())
        {
            _textBox.text = _texts[_current_text];

            if (_current_text < MAX_TEXT - 1 && Input.GetMouseButtonDown(0))
            {
                _current_text++;
            }
        }
    }

    void KotodamaDestroy()
    {
        var kotodama_ = GameObject.Find("Kotodama");

        Destroy(kotodama_);
    }

    void HeroineDestroy()
    {
        var heroine_ = GameObject.Find("Heroine");

        Destroy(heroine_);
    }

    void CharacterDestroy()
    {
        HeroineDestroy();
        KotodamaDestroy();
    }

    void TextBoxDestroy()
    {
        GameObject textBox_ = GameObject.Find("TextBox");
        GameObject text_ = GameObject.Find("Text");
        textBox_.GetComponent<Image>().enabled = false;
        text_.GetComponent<Text>().enabled = false;
    }

    void Destroy()
    {
        CharacterDestroy();
        TextBoxDestroy();
    }

    void Update()
    {
        TextUpdate();
        //Destroy();
    }
}
