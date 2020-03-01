using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
	bool Now =false;

	void Update()
	{
		if (!Now)
		{
			if (Input.GetKeyDown(KeyCode.A))
			{
				Vector3 pos = transform.position;
				if (pos.x >= -2) StartCoroutine(move("A"));
			}
			if (Input.GetKeyDown(KeyCode.D))
			{
				Vector3 pos = transform.position;
				if(pos.x <= 2) StartCoroutine(move("D"));
			}
		}
		
	}

	private IEnumerator move(string key)
	{
		Now = true;
		Vector3 pos = transform.position;
		if (key == "A")
		{
			transform.Rotate(new Vector3(0, -90, 0));
				for (int i=0;i <10;i++)
				{
					pos.x -= 0.1f;
					transform.position = pos;
					yield return null;
				}
			transform.Rotate(new Vector3(0, 90, 0));

		}
		else if (key == "D")
		{
			transform.Rotate(new Vector3(0, 90, 0));
				for (int i = 0; i < 10; i++)
				{
					pos.x += 0.1f;
					transform.position = pos;
					yield return null;
				}
			transform.Rotate(new Vector3(0, -90, 0));
		}
		transform.position = pos;
		Now = false;
	}
	public void NowBool()
	{
		Now = true;
	}
}
