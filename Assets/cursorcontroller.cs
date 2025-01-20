using UnityEngine;

namespace Christina.CustomCursor
{
    public class CursorController : MonoBehaviour
    {
        [SerializeField] public Texture2D cursorTextureDefault;

        [SerializeField] private Vector2 clickPosition = Vector2.zero;
        
        void Start()
        {
            Cursor.SetCursor(cursorTextureDefault, clickPosition, CursorMode.Auto);
        }
    }
}