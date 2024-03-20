using UnityEngine;

public class Ground : MonoBehaviour
{

    private Game _game;
    // Start is called before the first frame update
    void Start()
    {
        _game = FindObjectOfType<Game>();
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other);
        if (other.gameObject.name == "Bird")
        {
            _game.UpdateState(GameState.Ended);
        }
    }
}
