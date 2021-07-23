using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityMachine : MonoBehaviour
{
    [SerializeField] GravityDirection direction;
    [SerializeField] bool globalGravityOption = false;
    [SerializeField] float switchDelay = .2f;
    public enum GravityDirection
    {
        Up, 
        Down, 
        Left, 
        Right
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Untagged") return;
        var switcher = other.GetComponent<GravitySwitcher>();
        if (switcher != null && switcher.GetGravityDirection() != direction.ToString())
        {
            print(direction.ToString());
            StartCoroutine(ShiftGravityWithDelay(switcher, direction.ToString()));
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Untagged") return;
        if (globalGravityOption) return;
        var switcher = collision.GetComponent<GravitySwitcher>();
        if (switcher == null) return;
        if (switcher.GetGravityDirection() == direction.ToString())
        {
            print("down");
            StartCoroutine(ShiftGravityWithDelay(switcher, "Down"));
        }
    }
    IEnumerator ShiftGravityWithDelay(GravitySwitcher switcher, string direction)
    {
        yield return new WaitForSeconds(switchDelay);
        switcher.ShiftGravity(direction);
    }
}
