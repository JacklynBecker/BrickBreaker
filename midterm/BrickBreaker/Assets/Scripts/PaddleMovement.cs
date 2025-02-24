using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public string inputAxis;

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis(inputAxis) * moveSpeed * Time.deltaTime;
    
        transform.Translate(move,0,0);

        float clampedX = Mathf.Clamp(transform.position.x, -2.5f, 2.5f);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);

    }
}
