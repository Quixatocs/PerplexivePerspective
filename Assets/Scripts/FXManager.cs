using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXManager : MonoBehaviour {

    public GameObject CheckpointFXPrefab;

    void OnEnable()
    {
        EventManager.updateCheckpoint += SpawnCheckpointFX;
    }

    void OnDisable()
    {
        EventManager.updateCheckpoint -= SpawnCheckpointFX;
    }

    void SpawnCheckpointFX(Vector3 spawnPosition)
    {
        GameObject momentaryEffect = Instantiate(CheckpointFXPrefab, spawnPosition, Quaternion.identity, transform);
        Destroy(momentaryEffect, 6f);
    }


}
