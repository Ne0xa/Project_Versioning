using UnityEngine;

[CreateAssetMenu(fileName = "Ennemis", menuName = "Scriptable Objects/Ennemis")]
public class Ennemis : ScriptableObject
{
    [SerializeField] private int _life;
    [SerializeField] private float _speed;
    [SerializeField] private int _attack;
    [SerializeField] private Sprite _sprite;
    public int Life => _life;
    public int Speed => _speed;
    public int Attack => _attack;
}
