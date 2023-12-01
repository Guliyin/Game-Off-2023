using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

[System.Serializable]
public class PlayerInfo
{
    public string Name;
    public float Scale;

    public PlayerInfo(string name, float scale)
    {
        Name = name;
        Scale = scale;
    }
}

public class MenuBall : MonoBehaviour
{
    [SerializeField] TMP_InputField inputField;
    [SerializeField] Transform image;
    [SerializeField] Slider slider;
    [SerializeField] TMP_Text scaleText;
    [SerializeField] TMP_Text otherText;

    [Header("StartBtn")]
    [SerializeField] Button btn;

    float scale;
    string displayName;
    private void Start()
    {
        slider.onValueChanged.AddListener(SliderValueChange);
        inputField.onValueChanged.AddListener(NameInput);

        string path = Application.persistentDataPath + "/Json/PlayerInfo.json";
        if (File.Exists(path))
        {
            string sr = File.ReadAllText(path);
            PlayerInfo info = JsonUtility.FromJson<PlayerInfo>(sr);

            slider.value = info.Scale;
            inputField.text = info.Name;
        }
        else
        {
            SliderValueChange(1);
        }
    }
    void SliderValueChange(float f)
    {
        scale = f;
        image.localScale = new Vector3(f, f, 1f);
        scaleText.text = "Scale: " + scale.ToString("0.00");

        otherText.text = "Spring force: " + (Mathf.Pow(scale, 1.90f) * 40).ToString("0.00") +
            "\nMass: " + (scale / 2 * scale / 2 * Mathf.PI).ToString("0.00") +
            "\nDrag: " + (0.15f * scale).ToString("0.00");
    }
    void NameInput(string s)
    {
        displayName = s;
        btn.interactable = s.Length >= 3;
    }
    public void SavePlayrProfile()
    {
        PlayerInfo info = new PlayerInfo(displayName, scale);
        string path = Application.persistentDataPath + "/Json/PlayerInfo.json";
        string s = JsonUtility.ToJson(info, true);
        File.WriteAllText(path, s);
    }
}
