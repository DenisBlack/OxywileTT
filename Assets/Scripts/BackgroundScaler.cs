using UnityEngine;
using Utils;
using Zenject;

public class BackgroundScaler : MonoBehaviour
{
    private LevelBorders _levelBorders;
 
    public float scrollSpeed = 0.1f;

    private SpriteRenderer _spriteRenderer;
    private Renderer _renderer;
    
    [Inject]
    public void Construct(LevelBorders levelBorders)
    {
        _levelBorders = levelBorders;
    }
    
    void Start()
    {
        _renderer = GetComponent<Renderer>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
       
        if (_spriteRenderer == null)
            return;

        float screenHeight = _levelBorders.GetScreenHeight();
        float screenWidth = _levelBorders.GetScreenWidth();
        
        float spriteWidth = _spriteRenderer.sprite.bounds.size.x;
        float spriteHeight = _spriteRenderer.sprite.bounds.size.y;

        Vector3 newScale = transform.localScale;
        newScale.x = screenWidth / spriteWidth;
        newScale.y = screenHeight / spriteHeight;

        transform.localScale = newScale;
    }
    
    private void Update()
    {
        float offsetY = Time.time * scrollSpeed;
        _renderer.material.mainTextureOffset = new Vector2(1, offsetY);
    }
}