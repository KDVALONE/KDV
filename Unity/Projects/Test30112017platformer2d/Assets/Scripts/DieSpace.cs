﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieSpace : MonoBehaviour {

    public GameObject respawn;
    void DieTrigerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.transform.position = respawn.transform.position;
        }

    }

		
	}
