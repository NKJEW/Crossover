using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {
    public PlayerInputs[] inputs;

    List<ShootingController> shootControllers = new List<ShootingController>();
    List<MovementController> moveControllers = new List<MovementController>();

	void Start () {
        List<GameObject> players = GameManager.instance.GetPlayers();
        for (int i = 0; i < players.Count; i++) {
            shootControllers.Add(players[i].GetComponent<ShootingController>());
            moveControllers.Add(players[i].GetComponent<MovementController>());
        }
    }

    void Update () {
        for (int i = 0; i < shootControllers.Count; i++) {
            if (Input.GetKeyDown(inputs[i].shootKey))
                shootControllers[i].AttemptShoot();

            //if (Input.GetKeyDown(inputs[i].jumpKey))
                //moveControllers[i].();
        }
    }

    [System.Serializable]
    public struct PlayerInputs {
        public string shootKey;
        public string jumpKey;
    }
}
