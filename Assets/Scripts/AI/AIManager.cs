using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(0)]
public class AIManager : MonoBehaviour
{
    private static AIManager _instance;
    public static AIManager Instance { get { return _instance; } private set { _instance = value; } }

    private List<AIUnit> _units = new();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            return;
        }
    }

    public void MakeAgentsCircleTarget(Transform target, AIUnit unit)
    {
        Vector3 pos = new Vector3(
                target.position.x + Random.insideUnitCircle.x * 2 * _units.IndexOf(unit),
                target.position.y,
                target.position.z + Random.insideUnitCircle.y * 2 * _units.IndexOf(unit)
                );

        unit.MoveTo(pos);
    }

    public void AddUnit(AIUnit unit) => _units.Add(unit);

    public void RemoveUnit(AIUnit unit) => _units.Remove(unit);
}
