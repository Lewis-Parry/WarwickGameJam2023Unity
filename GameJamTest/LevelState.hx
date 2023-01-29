import flixel.FlxBasic;
import flixel.FlxG;
import flixel.FlxSprite;
import flixel.FlxState;
import flixel.addons.editors.tiled.TiledMap;
import flixel.addons.editors.tiled.TiledObjectLayer;
import flixel.group.FlxGroup.FlxTypedGroup;
import flixel.group.FlxGroup;
import flixel.text.FlxText;
import flixel.util.FlxCollision;
import flixel.util.FlxColor;

class LevelState extends FlxState /*loading the tile map into the HaxeFlixel game */
{
	var levelBounds:FlxGroup; // Level bound for borders of the screen
	var platformsGroup:FlxTypedGroup<FlxSprite>;
	var player:Player;

	override public function create()
	{
		bgColor = 0xffd4d4d4; /* WARNING< MAKE USRE ITS 8 HEX VALUES, IT CAN ACCEPT A DIFFFERENT NO' SO WILL APPEAR AS BLACK*/
	}

	function createLevel(levelName:String, playerPos:{x:Int, y:Int})
	{
		final map = new TiledMap('assets/data/$levelName.tmx');
		final platformsLayer:TiledObjectLayer = cast(map.getLayer("Platforms"));
		/*IMPORTANT< MAKE SURE THAT "Platforms" HAS THE SAME SPELLING AND CASE AS THE CORRESPONSDING TILES LAYER"*/
		platformsGroup = new FlxTypedGroup<FlxSprite>(); /*loops over every object in map layer and turns it into a pixel sprite, helps with collision mapping" */

		for (platform in platformsLayer.objects)
		{
			final platformSprt = new FlxSprite(platform.x, platform.y);
			platformSprt.loadGraphic("assets/images/StoneplatformTile.jpg", false, 50, 50);
			platformSprt.immovable = true; // immovable attribute applied to every individual tile, set this to false so that the blocks move when you collide with them!
			platformsGroup.add(platformSprt);
		}

		add(platformsGroup);
		player = new Player(playerPos.x, playerPos.y);
		add(player);

		levelBounds = FlxCollision.createCameraWall(FlxG.camera, true, 1); /*sets the edge of the screens to the boundaries as well */
	}

	override public function update(elapsed:Float)
	{
		super.update(elapsed);
		FlxG.collide(player, levelBounds);
		FlxG.collide(player, platformsGroup);
	}
}
