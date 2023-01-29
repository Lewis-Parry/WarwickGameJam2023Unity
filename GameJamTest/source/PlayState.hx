package;

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

class PlayState extends LevelState /*extends LevelState.hx from the level we made */
{
	override public function create()
	{
		FlxG.resizeWindow(650, 500);
		super.create();
		createLevel("StageTest", {x: 50, y: 300}); /*loadedbefore the player so is behind it (see LevelState.hx)*/
	}
}
