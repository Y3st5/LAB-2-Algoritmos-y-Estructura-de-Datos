using UnityEngine;
using UnityEngine.UI;

public class SkillUI : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private SkillManager skillManager;
    [SerializeField] private Transform availableSkillsContainer;
    [SerializeField] private Transform learnedSkillsContainer;
    [SerializeField] private GameObject skillButtonPrefab;

    private void Start()
    {
        PopulateAvailableSkills();
        PopulateLearnedSkills();
    }

    private void PopulateAvailableSkills()
    {
        foreach (var skill in skillManager.SkillList)
        {
            var button = Instantiate(skillButtonPrefab, availableSkillsContainer);
            button.GetComponentInChildren<Text>().text = skill.SkillName;
            button.GetComponent<Button>().onClick.AddListener(() => AttemptToLearnSkill(skill));
        }
    }

    private void PopulateLearnedSkills()
    {
        foreach (Transform child in learnedSkillsContainer)
        {
            Destroy(child.gameObject);
        }

        foreach (var skill in player.LearndSkills)
        {
            var button = Instantiate(skillButtonPrefab, learnedSkillsContainer);
            button.GetComponentInChildren<Text>().text = skill.SkillName;
        }
    }

    private void AttemptToLearnSkill(Skill skill)
    {
        player.TryToLearnSkill(skill);
        PopulateLearnedSkills();
    }
}