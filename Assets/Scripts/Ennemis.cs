using UnityEngine;

[CreateAssetMenu(fileName = "Ennemis", menuName = "Scriptable Objects/Ennemis")]
public class Ennemis : ScriptableObject
{
    [SerializeField] private int _life;
    [SerializeField] private float _speed;
    [SerializeField] private int _attack;
    [SerializeField] private Sprite _sprite;
    public int Life => _life;
    public float Speed => _speed;
    public int Attack => _attack;

    private void Reset()
    {
        _life = 10;
        _speed = 5.0f;
        _attack = 1;
    }
}
