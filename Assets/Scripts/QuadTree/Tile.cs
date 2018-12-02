using UnityEngine;

public delegate void OnTileChange (object sender, Collision collision, Tile tile);

public class Tile : MonoBehaviour {

    public OnTileChange OnTileEnter;
    public OnTileChange OnTileExit;

    private BoxCollider2D collider;

    private BoxCollider2D Collider
    {
        get
        {
            if (collider == null)
            {
                collider = GetComponent<BoxCollider2D>();
            }
            return collider;
        }
    }

    public Vector2 Position
    {
        get; set;
    }

    public Vector2 Dimensions
    {
        get
        {
            return new Vector2(Collider.size.x, Collider.size.y);
        }
    }

    private void OnCollisionEnter( Collision collision )
    {
        OnTileEnter.Invoke(this, collision, this);
    }

    private void OnCollisionExit( Collision collision )
    {
        OnTileExit.Invoke(this, collision, this);
    }

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
