using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ListPlayer {

	public List<Player> players;

	public ListPlayer() {
		players = new List<Player> ();
	}
}
