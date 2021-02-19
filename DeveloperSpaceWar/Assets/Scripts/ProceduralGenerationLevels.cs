using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralGenerationLevels : MonoBehaviour
{
    private const float PLAYER_DISTANCE_SPAWN_LEVEL_PART = 200f;

    [SerializeField] private Transform levelPart_Start;
    [SerializeField] private List<Transform> levelPartList;
    [SerializeField] private Player player;

    private Vector3 lastEndPosition;


    void Awake() 
    {
        
        lastEndPosition = levelPart_Start.Find("EndPoint").transform.TransformPoint(Vector3.right * 2);
        Debug.Log(lastEndPosition.x);
        int startGenerationLevel = 5;
        for(int i = 0; i < startGenerationLevel; i++)
        {
            SpawnLevelPart();
        }    
    }

    void Update() 
    {
        if(player == null)
            return;
        if(Vector3.Distance(player.transform.position, lastEndPosition) < PLAYER_DISTANCE_SPAWN_LEVEL_PART)
        {
            SpawnLevelPart();
        }    
    }

    private void SpawnLevelPart()
    {
        Transform chosenLevelPart = levelPartList[Random.Range(0, levelPartList.Count)];
        Transform lastLevelPartTransform = SpawnLevelPart(chosenLevelPart, lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("EndPoint").transform.TransformPoint(Vector2.right * 2);
        Debug.Log(lastEndPosition.x);
    }

    private Transform SpawnLevelPart(Transform levelPart ,Vector3 spawnPosition)
    {
        Transform lastSpawnLevel = Instantiate(levelPart, spawnPosition, Quaternion.identity);
        return lastSpawnLevel;
    }
}
