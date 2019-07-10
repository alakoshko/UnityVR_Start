

public interface IDamageable
{

    float MaxHealth { get; }
    float CurrentHealth { get; }

    void ApplyDamage(float damage);

}