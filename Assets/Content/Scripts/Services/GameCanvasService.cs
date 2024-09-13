using UnityEngine;
namespace Content.Scripts.Services
{
    public class GameCanvasService : MonoBehaviour
    {
        public RectTransform Backpack => backpack;
        [SerializeField] private RectTransform backpack;
    }
}
