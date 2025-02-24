using TMPro.EditorUtilities;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    //Const Strings
    private const string PlayerTag="player";
    private const string WallTag="wall";
    private const string GoalTag="goal";

     //Private variables
    private Rigidbody2D rBody;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag(PlayerTag))
        {
            //bounce off player paddle
            HandlePlayerCollision(other);
        }
        else if(other.gameObject.CompareTag(WallTag)){
            //bounce off walls
            HandleWallCollision();
        }
        else if(other.gameObject.CompareTag(GoalTag)){
            //update lose score
            HandleGoalCollision();
        }
        else{
            //bounce off ceiling
            HandleCeilingCollision();
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

    private void HandleCeilingCollision()
    {
        Vector2 currentVelocity = GameManager.Instance.GetCurrentVelocity();
        currentVelocity = new Vector2(currentVelocity.x , currentVelocity.y * -1);
        GameManager.Instance.SetCurrentVelocity(currentVelocity);
    }


    private void HandleWallCollision()
    {
        Vector2 currentVelocity = GameManager.Instance.GetCurrentVelocity();
        currentVelocity = new Vector2(currentVelocity.x  * -1, currentVelocity.y );
        GameManager.Instance.SetCurrentVelocity(currentVelocity);
    }

    private void HandleGoalCollision()
    {
        GameManager.Instance.addScore();
    }

    private float CalculateBounceAngle(Vector2 ballpos, Vector2 paddlepos, float paddleHeight)
    {
        return (ballpos.y - paddlepos.y) / paddleHeight * 3f;
    }
}
