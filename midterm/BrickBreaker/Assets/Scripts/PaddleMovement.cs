using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public string inputAxis;

    private const string PowerUpTag="boost";

    private const string BallTag="ball";

    private int powerUpHealth=0;

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis(inputAxis) * moveSpeed * Time.deltaTime;
    
        transform.Translate(move,0,0);

        float clampedX = Mathf.Clamp(transform.position.x, -2.5f, 2.5f);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag(PowerUpTag))
        {
            //destroy powerup and increase paddle size
            Destroy(other.gameObject);
            transform.localScale = new Vector3(2f,0.2f,0f);
            powerUpHealth=3;
        }
        else if(other.gameObject.CompareTag(BallTag))
        {
            //destroy powerup and increase paddle size
            powerUpHealth--;
            checkHealth();
        }
        
    }

    private void checkHealth(){
        if(powerUpHealth==0){
            transform.localScale = new Vector3(1f,0.2f,0f);
        }
    }
}
