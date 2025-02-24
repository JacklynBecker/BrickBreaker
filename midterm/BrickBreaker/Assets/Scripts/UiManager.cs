using UnityEngine;

public class UiManager : MonoBehaviour
{
    public static UiManager Instance {get; private set;}


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

}
