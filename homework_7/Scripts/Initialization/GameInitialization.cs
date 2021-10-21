using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitialization
{
    public GameInitialization(Controllers controllers, int numberoflvl)
    {
        NumberofRequiredBonusUnits numberofRequiredBonusUnits = new NumberofRequiredBonusUnits();
        Camera camera = Camera.main;
        var inputinitialization = new InputKeyboardInitialization();
        var inputmouseinitialization = new InputMouseInitialization();
        var lvlfactory = new LevelFactory(Resources.Load<LevelInfo>("PlayerAndEnemy").lvl);
        var lvlinitialization = new LevelInitialization(lvlfactory, Resources.Load<LevelInfo>("PlayerAndEnemy").lvl[numberoflvl].transform.position, new SaveAndLoadData());
        var navmeshinitialization = new NavigationMapInitialization(lvlinitialization.GetNavMeshSurface());
        var enemyfactory = new EnemyFactory(Resources.Load<LevelInfo>("PlayerAndEnemy").enemyPrefab);
        var enemyinitialization = new EnemyInitialization(enemyfactory);
        var bonusfactory = new BonusFactory("BonusInfo");
        var bonusinitialization = new BonusInitialization(bonusfactory);
        var playerfactory = new PlayerFactory(Resources.Load<LevelInfo>("PlayerAndEnemy").playerPrefab);
        var playerinitialization = new PlayerInitialization(playerfactory, Resources.Load<LevelInfo>("PlayerAndEnemy").playerPrefab.transform.position, camera);
        var canvasfactory = new CanvasFactory(Resources.Load<CanvasInfo>("Canvas").CanvasPrefab);
        var canvasinitialization = new CanvasInitialization(canvasfactory);
        var leveldestroyinitialization = new LevelDestoyerInitialization(playerinitialization.GetPlayer(), enemyinitialization.GetEnemy(), lvlinitialization.GetLvl(), bonusinitialization.GetBonuses(), canvasinitialization.GetCanvas());
        controllers.Add(inputinitialization);
        controllers.Add(playerinitialization);
        controllers.Add(lvlinitialization);
        controllers.Add(enemyinitialization);
        controllers.Add(inputmouseinitialization);
        controllers.Add(bonusinitialization);
        controllers.Add(navmeshinitialization);
        controllers.Add(canvasinitialization);
        controllers.Add(new InputController(inputinitialization.GetInput()));
        controllers.Add(new InputMouseController(inputmouseinitialization.GetMouseInput()));
        controllers.Add(new CameraController(inputmouseinitialization.GetMouseInput(), playerinitialization.GetCameraMoves()));
        controllers.Add(new PlayerMoveController(inputinitialization.GetInput(), playerinitialization.GetPlayerMoves()));
        controllers.Add(new EnemyMoveController(enemyinitialization.MoveEnemy()));
        controllers.Add(new PlayerCatchedController(playerinitialization, enemyinitialization));
        controllers.Add(new PositiveBonusController(bonusinitialization.GetBonuses(), playerinitialization.GetPlayer(), playerinitialization.GetAndSetSpeed()));
        controllers.Add(new NegativeBonusController(bonusinitialization.GetBonuses(), playerinitialization.GetPlayer(), playerinitialization.GetAndSetSpeed()));
        controllers.Add(new RequiredBonusController(bonusinitialization.GetBonuses(), playerinitialization.GetPlayer(), numberofRequiredBonusUnits, bonusinitialization));
        controllers.Add(new CoinController(new ModelCoin(0), canvasinitialization.GetCoinViewComponent(), bonusinitialization));
        controllers.Add(new EndLvlController(playerinitialization.GetPlayer().transform, Resources.Load<PointsInfo>("StartAndEndPoints").points[1], controllers, leveldestroyinitialization, numberofRequiredBonusUnits));

    }
}
