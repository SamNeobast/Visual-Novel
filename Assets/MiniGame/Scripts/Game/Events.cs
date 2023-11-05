using System;

public static class Events
{
    public static Action OnDeadedPlayer;
    public static Action OnKilledEnemy;

    public static Action<float> OnHealthChanged;
    
}
