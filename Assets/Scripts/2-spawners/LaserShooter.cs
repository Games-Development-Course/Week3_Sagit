using UnityEngine;

/**
 * This component spawns the given laser-prefab whenever the player clicks a given key.
 * It also updates the score when the laser hits its target.
 */
public class LaserShooter: ClickSpawner {
    [SerializeField]
    [Tooltip("Default points if the hit object does not provide its own value")]
    int pointsToAdd = 1;

    private void HandleHit(Collider2D other) {
        if (ScoreManager.instance == null) {
            Debug.LogWarning("ScoreManager not found!");
            return;
        }

        int award = pointsToAdd;
        if (other != null) {
            var ep = other.GetComponent<EnemyPoints>();
            if (ep != null) award = ep.Points;
        }

        ScoreManager.instance.AddScore(award);
        if (NumberField.instance) NumberField.instance.SetNumber(ScoreManager.instance.GetScore());
    }

    protected override GameObject spawnObject() {
        GameObject newObject = base.spawnObject();
        DestroyOnTrigger2D newObjectDestroyer = newObject.GetComponent<DestroyOnTrigger2D>();
        if (newObjectDestroyer)
            newObjectDestroyer.onHit += HandleHit; // now receives Collider2D
        return newObject;
    }
}