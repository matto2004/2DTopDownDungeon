﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void Start()
    {

	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("SpawnPoint")) 
		{
			Destroy(other.gameObject);
		}

	}
}