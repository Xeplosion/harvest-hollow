# Using the Weather Effects:

This asset includes several sprite sheets.
The title of each one describes what's in it, with the numbers at the end denoting how the sheet should be sliced.
Below please find some notes to help you utilize each component as intended, though don't feel bound by my suggestions.


weather effects, cloud cover autotile 16x16.png
	The cloud shadows are an auto-tile you'll want to paint on with a terrain brush. It will look best if it moves slowly across your map.
	It should be on top of everything except maybe some other weather stuff, like the lightning bolts, the light rain, or light snow.

weather effects, snow cover autotile 16x16.png
	The snow cover is an autotile you can use with a terrain brush to cover the ground on your map.
	It should be under the tree tops, character sprites, and other weather effects.

weather effects, lightning full 32x128.png
weather effects, lightning repeatable 32x80.png
weather effects, lightning impact 32x48.png
	The top 5 tiles of the full lightning bolts are repeatable and interchangeable, so you can make your bolt as high/long as it needs to be if you use the repeatable sheets.
	I would just flash one or the other on-screen very breifly while it's raining. Maybe with a full screen white flash for one frame, then a slow fade out.
	You can alternate both bolts rapidly on top of one another to simulate a continuous flow of lightning.

weather effects, rain light anim 32x128.png
weather effects, rain heavy anim 32x128
	These are 8-frame animations, and the sprite is 32x128 pixels (2 tiles wide, 8 tiles high).
	You can overlap the light and heavy versions to make a pouring rain animation, but make sure you put the heavy rain animation on the lower layer.
	The two rain animations should be run at different speeds. I like 50ms for the light rain, and 100ms for the heavy rain.

weather effects, snow light anim 32x128.png
weather effects, snow heavy anim 32x128.png
	The snowfall animations are the exact same size and frame count as the rain animations.
	And again like the rainfall, you can overlap these, but put the heavy one behind the light one.
	And yet again, the light and heavy snow should run at different speeds. I like 175ms for light snow, and 100ms for heavy snow.

weather effects, rain impact anim 16x16.png
weather effects, snow impact anim 16x16.png
	The rain and snow drops are one-tile 8-frame animations. These are best sprinkled about in places where the drops would visibly impact.
	That means not on tree tops or under any overhangs/bridges. And I wouldn't put snow drops on a snow-covered floor.
	The rain and snow drops should run at different speeds. I like 75ms for rain drops, and 150ms for snow.
