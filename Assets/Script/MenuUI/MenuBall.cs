using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
    string name;
    private void Start()
    {
        slider.onValueChanged.AddListener(SliderValueChange);
        inputField.onValueChanged.AddListener(NameInput);
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
        name = s;
        btn.interactable = s != "";
    }

}
