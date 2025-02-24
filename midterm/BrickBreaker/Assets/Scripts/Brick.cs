using UnityEngine;

public class Brick : MonoBehaviour
{
    private const string BallTag="ball";
    private SpriteRenderer brick;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        brick = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag(BallTag))
        {
            if(brick.material.color == Color.white){
                HandlePlayerCollision(other);
                brick.material.color= Color.blue;
            }
            else if(brick.material.color==Color.blue){
                HandlePlayerCollision(other);
                brick.material.color=Color.green;
            }
            else if(brick.material.color==Color.green){
                HandlePlayerCollision(other);
                Destroy(gameObject);
            }
        }
        else{
            return;
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
