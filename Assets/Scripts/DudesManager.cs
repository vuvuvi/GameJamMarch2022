using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DudesManager : MonoBehaviour
{
    public Transform[] RegionsPositions => regionsPositions;

    [SerializeField] private int clansCount;
    [SerializeField] private int dudesCountByClan;
    [SerializeField] private Transform[] regionsPositions;
    [SerializeField] private float initialSpreadRadius;
    [SerializeField] private Dude dudePrefab;
    [SerializeField] private Collider2D board;



    private void Awake()
    {
        GenerateDudes();
    }

    private void GenerateDudes()
    {
        if (regionsPositions.Length < clansCount) return;

        List<Transform> usedRegionsPosition = new List<Transform>();
        for (int i = 0; i < clansCount; i++)
        {
            Transform regionPosition;
            do
            {
                regionPosition = regionsPositions[Random.Range(0, regionsPositions.Length)];
            } while (usedRegionsPosition.Contains(regionPosition));
            usedRegionsPosition.Add(regionPosition);

            for (int j = 0; j < dudesCountByClan; j++)
            {
                Vector3 position = new Vector3(regionPosition.position.x + Random.Range(-initialSpreadRadius,initialSpreadRadius), regionPosition.position.y + Random.Range(-initialSpreadRadius,initialSpreadRadius), 0);
                Dude dude = Instantiate(dudePrefab, position, Quaternion.identity);
                // Vector4 boardBounds = new Vector4(
                // board.bounds.max.y,
                // board.bounds.max.x,
                // board.bounds.min.y,
                // board.bounds.min.x
                // );
                dude.Init((Culture) i, board, this);
            }
        }
    }
}
