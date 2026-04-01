using System;

public static class GameUtils
{
    // Método genérico para transformar habilidades
    public static TResult TransformSkill<T, TResult>(T skill, Func<T, TResult> transformer) where T : Skill
    {
        return transformer(skill);
    }
}