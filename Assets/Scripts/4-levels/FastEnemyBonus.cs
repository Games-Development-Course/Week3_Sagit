using UnityEngine;

public class FastEnemyBonus : MonoBehaviour
{
    [SerializeField] int bonusPoints = 2;
    
    private void Start() 
    {
        DestroyOnTrigger2D destroyer = GetComponent<DestroyOnTrigger2D>();
        if (destroyer) 
        {
            destroyer.onHit += GiveBonus; // onHit expects Action<Collider2D>
        }
    }
    
    // Match the delegate signature: receive the Collider2D hit
    private void GiveBonus(Collider2D other) 
    {
        if (ScoreManager.instance == null) return;
        ScoreManager.instance.AddScore(bonusPoints);
        if (NumberField.instance) 
        {
            NumberField.instance.SetNumber(ScoreManager.instance.GetScore());
        }
    }
}
