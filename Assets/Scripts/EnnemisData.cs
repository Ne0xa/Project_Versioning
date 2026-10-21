using UnityEngine;

public enum Type
{
    Blinde,
    Normal
}
[CreateAssetMenu(fileName = "EnnemisData", menuName = "Scriptable Objects/EnnemisData")]
public class EnnemisData : ScriptableObject
{
    [SerializeField] private Type _typeEnemis;
    [SerializeField] private int _life;
    [SerializeField] private float _speed;
    [SerializeField] private float _distanceToMove = 2f;
    [SerializeField] private int _attack;
    [SerializeField] private SpriteRenderer _spriterenderer;
    public int Life => _life;
    public float Speed => _speed;
    public float DistanceToMove => _distanceToMove;
    public int Attack => _attack;
    public SpriteRenderer Spriterenderer => _spriterenderer; 
    public Type TypeEnemis => _typeEnemis;

    private void Reset()
    {

        _life = 10;
        _speed = 5.0f;
        _attack = 1;
        _typeEnemis = Type.Normal;
    }
}
