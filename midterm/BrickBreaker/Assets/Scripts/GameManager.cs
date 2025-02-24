using UnityEngine;

public class GameManager : MonoBehaviour
{

    //Single reference static variables
    public static GameManager Instance {get; private set;}

    //ground hit variables
    private int groundHit=0;
    private int BricksHit=0;

    //Ball variables
    public Rigidbody2D ballRigidBody;
    public float ballSpeed = 5f;
    private Vector2 currentVelocity;

    //lose Score Condition 
    public int loseScore = 3;

    public int winScore=8;

    //unity function
    private void Awake()
    {
        //Ensure that there is only one instance of gameManager
        if (Instance == null)
        {
            Instance = this;
            //Intermediate Unity tip and trick 
            DontDestroyOnLoad(this.gameObject);
        }
        else{
            Destroy(this.gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        resetBall();
    }

    void resetBall(){
        ballRigidBody.transform.position = new  Vector2(0f,-4f);
        //randomly choose direction for ball to move horizontally
        //generate random number 0 or 1. if 0 return -1 if not 0 return 1
        float randX = -1f;
        //add slight vertical variation
        float randY = 1f;

        //set the balls velocity
        Vector2 direction = new Vector2(randX,randY).normalized;

        ballRigidBody.linearVelocity = direction * ballSpeed;

        SetCurrentVelocity(ballRigidBody.linearVelocity);
        
    }

    public void addScore()
    {
        groundHit++;
        if(groundHit >= loseScore)
        {
            //Display lose message
            Debug.Log($"You Lose!");
            StopGame();
        }
        resetBall();
    }

    public void addScoreBrick()
    {
        BricksHit++;
        Debug.Log($"Block Gone!");
        if(BricksHit >= winScore)
        {
            //Display lose message
            Debug.Log($"You Win!");
            StopGame();
        }
    }

    public Vector2 GetCurrentVelocity()
    {
        return currentVelocity;
    }

    public void SetCurrentVelocity(Vector2 velocity)
    {
        currentVelocity = velocity;
        ballRigidBody.linearVelocity=currentVelocity;
    }

    private void StopGame()
    {
        Time.timeScale = 0;
    }


}
