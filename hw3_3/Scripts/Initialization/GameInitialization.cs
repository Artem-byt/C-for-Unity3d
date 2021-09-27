using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitialization
{
    public GameInitialization(Controllers controllers, int numberoflvl)
    {
        Camera camera = Camera.main;
        var inputinitialization = new InputKeyboardInitialization();
        var inputmouseinitialization = new InputMouseInitialization();
        var playerfactory = new PlayerFactory(Resources.Load<LevelInfo>("PlayerAndEnemy").playerPrefab);
        var playerinitialization = new PlayerInitialization(playerfactory, Resources.Load<LevelInfo>("PlayerAndEnemy").playerPrefab.transform.position, camera);
        var enemyfactory = new EnemyFactory(Resources.Load<LevelInfo>("PlayerAndEnemy").enemyPrefab);
        var enemyinitialization = new EnemyInitialization(enemyfactory);
        var lvlfactory = new LevelFactory(Resources.Load<LevelInfo>("PlayerAndEnemy").lvl);
        var lvlinitialization = new LevelInitialization(lvlfactory, Resources.Load<LevelInfo>("PlayerAndEnemy").lvl[numberoflvl].transform.position);
        var bonusfactory = new BonusFactory("BonusInfo");
        var bonusinitialization = new BonusInitialization(bonusfactory);
        var leveldestroyinitialization = new LevelDestoyerInitialization(playerinitialization.GetPlayer(), enemyinitialization.GetEnemy(), lvlinitialization.GetLvl(), bonusinitialization.GetBonuses());
        controllers.Add(inputinitialization);
        controllers.Add(playerinitialization);
        controllers.Add(lvlinitialization);
        controllers.Add(enemyinitialization);
        controllers.Add(inputmouseinitialization);
        controllers.Add(bonusinitialization);
        controllers.Add(new InputController(inputinitialization.GetInput()));
        controllers.Add(new InputMouseController(inputmouseinitialization.GetMouseInput()));
        controllers.Add(new CameraController(inputmouseinitialization.GetMouseInput(), playerinitialization.GetCameraMoves()));
        controllers.Add(new PlayerMoveController(inputinitialization.GetInput(), playerinitialization.GetPlayerMoves()));
        controllers.Add(new EnemyMoveController(enemyinitialization.MoveEnemy()));
        controllers.Add(new PlayerCatchedController(playerinitialization, enemyinitialization));
        controllers.Add(new PositiveBonusController(bonusinitialization.GetBonuses(), playerinitialization.GetPlayer(), playerinitialization.GetAndSetSpeed()));
        controllers.Add(new NegativeBonusController(bonusinitialization.GetBonuses(), playerinitialization.GetPlayer(), playerinitialization.GetAndSetSpeed()));
        controllers.Add(new RequiredBonusController(bonusinitialization.GetBonuses(), playerinitialization.GetPlayer()));
        controllers.Add(new EndLvlController(playerinitialization.GetPlayer().transform, Resources.Load<PointsInfo>("StartAndEndPoints").points[1], controllers, leveldestroyinitialization));

    }
}
