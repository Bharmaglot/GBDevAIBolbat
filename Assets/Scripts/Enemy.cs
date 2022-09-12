using UnityEngine;

public class Enemy : IEnemy
{
    private const int KCoins = 5;
    private const float KPower = 1.5f;
    private const int MaxHelthPlayer = 20;
    private const int Greed = 10;


    private string _name;
    private int _moneyPlayer;
    private int _healthPlayer;
    private int _powerPlayer;
    

    public Enemy(string name)
    {
        _name = name;
    }

    public void Update(DataPlayer dataPlayer, DataType dataType)
    {
        switch (dataType)
        {
            case DataType.Health:
                _healthPlayer = dataPlayer.CountHealth;
                break;

            case DataType.Money:
                _moneyPlayer = dataPlayer.CountMoney;
                break;

            case DataType.Power:
                _powerPlayer = dataPlayer.CountPower;
                break;
        }

        Debug.Log($"Update {_name}, change {dataType}");
    }

    public int Power
    {
        get
        {
            var kHealth = _healthPlayer > MaxHelthPlayer ? 100 : 5;
            var power = (int)(_moneyPlayer / KCoins + kHealth + _powerPlayer / KPower);
            
            
            return power;

        }
    }
}
