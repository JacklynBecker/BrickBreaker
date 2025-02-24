using UnityEngine;

public class PowerUp : MonoBehaviour
{

    private const string GoalTag="goal";

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag(GoalTag))
        {
            //destroy powerup if missed
            Destroy(gameObject);
        }
        
    }
}
