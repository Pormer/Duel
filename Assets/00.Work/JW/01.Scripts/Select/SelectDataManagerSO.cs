using DataType;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "SO/Manager/Select")]
public class SelectDataManagerSO : ScriptableObject
{
    [field: SerializeField] public CharacterType LeftCharType { get; private set; }
    [field: SerializeField] public GunType LeftGunType { get; private set; }
    [field: SerializeField] public CharacterType RightCharType { get; private set; }
    [field: SerializeField] public GunType RightGunType { get; private set; }
    
    [SerializeField] private SelectItem selectItemObj;
    [SerializeField] private int spawnCount = 5;
    [SerializeField] private Vector2 startSpawnPos;

    public void SelectCharacter(bool isRight, CharacterType type)
    {
        if (isRight)
            RightCharType = type;
        else
        {
            LeftCharType = type;
        }
    }

    public void SelectGun(bool isRight, GunType type)
    {
        if (isRight)
            LeftGunType = type;
        else
        {
            RightGunType = type;
        }
    }

    public void SpawnSelectCharItem(Transform parent)
    {
        for (int i = 0; i < spawnCount; i++)
        {
            SelectItem item = Instantiate(selectItemObj, startSpawnPos, Quaternion.identity, parent);
            item.Initialize((CharacterType)Random.Range(0, 12));
            startSpawnPos += Vector2.up;
        }
    }
    
    public void SpawnSelectGunItem(Transform parent)
    {
        for (int i = 0; i < spawnCount; i++)
        {
            SelectItem item = Instantiate(selectItemObj, startSpawnPos, Quaternion.identity, parent);
            item.Initialize((CharacterType)Random.Range(0, 12));
            startSpawnPos += Vector2.up;
        }
    }

    public void NextStep()
    {
        SceneManager.LoadScene(3);
    }
}