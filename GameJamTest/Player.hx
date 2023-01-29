package;

import flixel.FlxBasic;
import flixel.FlxG;
import flixel.FlxObject;
import flixel.FlxSprite;

class Player extends FlxSprite
{
	final SPEED:Int = 300; /*integer constant*/
	final GRAVITY:Int = 600;

	final public function new(xPos:Int = 10, yPos:Int = 10)
	{
		super(xPos, yPos);
		loadGraphic("assets/images/Blockpl1.png", true, 50, 50);
		drag.x = SPEED * 1.5; /*higher values means the sprite stops quicker*/

		acceleration.y = GRAVITY;
	}

	function movement()
	{
		final left = FlxG.keys.anyPressed([LEFT, A]);
		final right = FlxG.keys.anyPressed([RIGHT, D]);

		if (right && left)
		{
			scale.x = 1;
			velocity.x = 0;
		}
		else if (right)
		{
			velocity.x = SPEED;
			scale.x = 0.8;
		}
		else if (left)
		{
			velocity.x = -SPEED;
			scale.x = 0.8;
		}
		else
		{
			scale.x = 1 - 1 / (SPEED - Math.abs(velocity.x)) / SPEED;
		}
	}

	function jumping()
	{
		final jump = FlxG.keys.anyPressed([UP, SPACE, W]);
		if (jump && isTouching(FLOOR))
		{
			velocity.y = -GRAVITY / 1.5;
		}
	}

	override function update(elapsed:Float)
		/*overrides the refresh update in playState.hx*/
	{
		jumping(); /*called before the update so isTouching flag isnt reset*/
		super.update(elapsed);
		movement();
	}
}
