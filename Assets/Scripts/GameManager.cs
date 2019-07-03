using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public GameObject playerPrefab;
    public Color[] playerColors;
    public GameObject gameOverPanel;
    public Text winnerText;
    public Transform spawnPointContainer;
    List<Vector2> spawnPoints = new List<Vector2>();

    int playerCount = 2;

    List<GameObject> players = new List<GameObject>();
    List<int> playersLeft = new List<int>();
	
    void Start () {
        gameOverPanel.SetActive(false);
        SetupSpawnPoints();
        SpawnPlayers();
	}

    void SpawnPlayers () {
        for (int i = 0; i < playerCount; i++) {
            GameObject newPlayer = Instantiate(playerPrefab, spawnPoints[i], Quaternion.identity);

            players.Add(newPlayer);
            playersLeft.Add(i);
        }
    }

    void SetupSpawnPoints () {
        for (int i = 0; i < spawnPointContainer.childCount; i++) {
            Transform curPoint = spawnPointContainer.GetChild(i);
            spawnPoints.Add((Vector2)curPoint.position);
        }
    }

    public void PlayerDied (int playerIndex) {
        playersLeft.Remove(playerIndex);
        if (playersLeft.Count == 1) {
            PlayerWon(playersLeft[0]);
        }
    }

    void PlayerWon (int playerIndex) {
        print("Player " + playerIndex + " won!");
        gameOverPanel.SetActive(true);
        winnerText.text = "Player " + playerIndex + " won!";
        winnerText.color = playerColors[playerIndex];

        ReloadGame();
    }

    void ReloadGame () {
        StartCoroutine(LoadScene(0, 2f));
    }

    IEnumerator LoadScene (int sceneIndex, float delay) {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneIndex);
    }

}
