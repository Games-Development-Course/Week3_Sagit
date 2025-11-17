using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClickScoreAdder : MonoBehaviour
{
    [SerializeField] protected InputAction addAction = new InputAction(type: InputActionType.Button);
    [SerializeField] protected int scoreToAdd;

    void OnEnable()    {        addAction.Enable();    }
    void OnDisable()    {        addAction.Disable();    }

    private void Start()   {
        ScoreManager.instance.ResetScore();
        if (NumberField.instance)
            NumberField.instance.SetNumber(0);
    }

    private void Update() {
        if (addAction.WasPressedThisFrame()) {
            ScoreManager.instance.AddScore(scoreToAdd);
            if (NumberField.instance)
                NumberField.instance.SetNumber(ScoreManager.instance.GetScore());
        }
    }
}
