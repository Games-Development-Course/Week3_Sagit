using UnityEngine;

public class ScoreManager : MonoBehaviour {
    public static ScoreManager instance;
    private int score;

    private void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    public int GetScore() {
        return score;
    }

    // Call with the amount to add (e.g. ScoreManager.instance.AddScore(1);)
    public void AddScore(int points) {
        score += points;
        Debug.Log("Score: " + score);
    }

    public void ResetScore() {
        score = 0;
    }
}