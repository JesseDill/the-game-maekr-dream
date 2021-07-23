using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class conveyorController : MonoBehaviour
{
	// We will need a list of items on the belt. Generic list collections work best for dynamically sizing arrays imo
	private List<GameObject> objsOnBelt;
	//you can adjust the speed using the float speed. If you want the belt to push right left use a negative number.
	public float speed;
	// Use this for initialization
	void Start()
	{
		//Best to initialize the list. I find that objects with scripts added dynamically through code don't always intalize lists
		objsOnBelt = new List<GameObject>();
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		if (objsOnBelt.Count != 0)
		{
			foreach (GameObject g in objsOnBelt)
			{
				g.transform.position += (transform.right * (speed * Time.deltaTime));
			}
		}
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		objsOnBelt.Add(col.gameObject);
	}
	void OnTriggerExit2D(Collider2D col)
	{
		objsOnBelt.Remove(col.gameObject);
	}
}