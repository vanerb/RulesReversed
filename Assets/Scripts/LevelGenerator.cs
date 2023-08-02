using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public List<GameObject> roomPrefabs; // Lista de prefabs de habitaciones
    public Transform character1;
    public Transform character2;
    public float roomWidth = 10f;        // Ancho de la habitación
    public int maxRoomsOnScreen = 5;     // Número máximo de habitaciones visibles en pantalla
    public PlayerSwitch playerSwitch;
    public int initialRoomIndex = 0;

    private List<GameObject> spawnedRooms = new List<GameObject>();

    private void Start()
    {
        // Generar la habitación inicial y establecerla en la posición inicial
        GameObject initialRoom = Instantiate(roomPrefabs[initialRoomIndex], transform);
        initialRoom.transform.position = Vector3.zero;
        spawnedRooms.Add(initialRoom);

        // Generar las habitaciones adicionales
        for (int i = 1; i < maxRoomsOnScreen; i++)
        {
            SpawnRoom();
        }
    }

    private void Update()
    {
        // Generar nuevas habitaciones si el personaje ha avanzado lo suficiente

        if (playerSwitch.isActive)
        {
            if (character1.position.x > spawnedRooms[0].transform.position.x + roomWidth)
            {
                Destroy(spawnedRooms[0]);
                spawnedRooms.RemoveAt(0);
                SpawnRoom();
            }
        }
        else
        {
            if (character2.position.x > spawnedRooms[0].transform.position.x + roomWidth)
            {
                Destroy(spawnedRooms[0]);
                spawnedRooms.RemoveAt(0);
                SpawnRoom();
            }
        }

       
    }

    private void SpawnRoom()
    {
        // Seleccionar una habitación aleatoria de la lista
        int randomIndex = Random.Range(1, roomPrefabs.Count);
        GameObject newRoom = Instantiate(roomPrefabs[randomIndex], transform);

        // Posicionar la nueva habitación a continuación de la última generada
        Vector3 spawnPosition = Vector3.zero;
        if (spawnedRooms.Count > 0)
        {
            spawnPosition = spawnedRooms[spawnedRooms.Count - 1].transform.position + new Vector3(roomWidth, 0f, 0f);
        }
        newRoom.transform.position = spawnPosition;

        // Agregar la nueva habitación a la lista de habitaciones generadas
        spawnedRooms.Add(newRoom);
    }
}
