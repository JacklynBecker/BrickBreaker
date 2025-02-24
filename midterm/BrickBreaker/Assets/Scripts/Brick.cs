using UnityEngine;

public class Brick : MonoBehaviour
{
    private const string BallTag="ball";

    public int health=3;


    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag(BallTag))
        {
            if(health == 1){
                HandlePlayerCollision(other);
                Destroy(gameObject);
                GameManager.Instance.addScoreBrick();
            }
            else{
                health--;
                HandlePlayerCollision(other);
                updateBrickColour();
            }
        }
        else{
            return;
        }
        
    }

    private void updateBrickColour(){
        if (health == 2){
            GetComponent<SpriteRenderer>().color=Color.green;
        }
        else if (health == 1){
            GetComponent<SpriteRenderer>().color=Color.white;
        }
    }

    private void HandlePlayerCollision(Collision2D other)
    {
        Vector2 currentVelocity = GameManager.Instance.GetCurrentVelocity();
        //currentVelocity = new Vector2(currentVelocity.x * -1, currentVelocity.y);
        float y = CalculateBounceAngle(transform.position, other.transform.position, other.collider.bounds.size.y);
        currentVelocity = new Vector2(currentVelocity.x * -1, y).normalized * GameManager.Instance.ballSpeed;
        GameManager.Instance.SetCurrentVelocity(currentVelocity);
    }

        private float CalculateBounceAngle(Vector2 ballpos, Vector2 paddlepos, float paddleHeight)
    {
        return (ballpos.y - paddlepos.y) / paddleHeight * 3f;
    }
}
