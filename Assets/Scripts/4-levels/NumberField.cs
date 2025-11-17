using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
/**
 * This component should be attached to a TextMeshPro object.
 * It allows to feed an integer number to the text field.
 */
[RequireComponent(typeof(TextMeshProUGUI))]
public class NumberField : MonoBehaviour {
    public static NumberField instance;
    private int number;

    private void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    public int GetNumber() {
        return number;
    }

    public void SetNumber(int newNumber) {
        number = newNumber;
        GetComponent<TextMeshProUGUI>().text = number.ToString();
    }

    public void AddNumber(int toAdd) {
        SetNumber(number + toAdd);
    }
}