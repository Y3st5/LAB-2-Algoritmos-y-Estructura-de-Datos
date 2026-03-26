using UnityEngine;

[CreateAssetMenu(fileName = "Skill", 
    menuName = "LeagueOfLegends/Skill")]
public class Skill : ScriptableObject
{
   [SerializeField] private string skillName;
   [SerializeField] private string skillDescription;

   [SerializeField] private int cost;
   [SerializeField] private float cooldown;
   [SerializeField] private float damage;
 
   [SerializeField] private int levelRestriction;

    public string SkillName => skillName;
    public string SkillDescription => skillDescription;
    public int Cost => cost;
    public float Cooldown => cooldown;
    public float Damage => damage;

    public int LevelRestriction => levelRestriction;
}
