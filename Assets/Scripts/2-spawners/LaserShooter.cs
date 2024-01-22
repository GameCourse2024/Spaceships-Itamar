using UnityEngine;

/**
 * This component spawns the given laser-prefab whenever the player clicks a given key.
 * It also updates the "scoreText" field of the new laser.
 */
public class LaserShooter: ClickSpawner {
    [SerializeField] NumberField scoreField;
    [SerializeField] float cooldownShoot = 0.5f; // cooldown between shots;
    private float lastShootTime = -1; // makes the player shoot at the start without cooldown

    protected override GameObject spawnObject()
     {
        // checking if the cooldown is over or if its the first shot
        if(Time.time - lastShootTime >= cooldownShoot || lastShootTime < 0f)
        { 
            GameObject newObject = base.spawnObject();  // base = super

            // Modify the text field of the new object.
            ScoreAdder newObjectScoreAdder = newObject.GetComponent<ScoreAdder>();
            if (newObjectScoreAdder)
                newObjectScoreAdder.SetScoreField(scoreField);

            // indicate the last shoot time to start the cooldown
            lastShootTime = Time.time;

            return newObject;
        }
        else return null;
    }
}
