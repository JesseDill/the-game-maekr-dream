
using UnityEngine;

public class Key : MonoBehaviour
{
   [SerializeField] private KeyType keyType;

   public enum KeyType
    {
        Square,
        Circle,
        Triangle
    }

    public KeyType GetKeyType()
    {
        return keyType;
    }
}
