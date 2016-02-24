Unity Hello Game
================

An example project for Unity3d with multiple scenes and a context that instantiates from any scene.
The game itself is very simple, what is showing off here is the way robotlegs can work in your project for you.

The project also uses a number of re-usable extensions. So the code inside the 'hellogame' namespace is actually very small.

## Extensions
#### Sound

A simple extension for managing all 2d sounds split into 2 channels, music and sound effects. Sound effects and music channels can have their volumes changed for easy muting.

#### Score

Has an event to add/set score, and has the ability to reset the score.
It also has built in text views for displaying score which get updated.

#### Highscore

Ties into the score events to save into PlayerPrefs.
It also has text views which get updated.

#### SceneCommand

Dispatches events when scenes are changed (as long as the context view doesn't destroy on load)

#### Language

Adds language data via XML, sets default language to Application.systemLanguage unless the user has changed language and will set the language to a model.
Comes with text view's to use, and buttons to change language.

## External assets

Thanks to [Kenny.nl](http://kenney.nl/) for the sound icons.
[DOTween](http://dotween.demigiant.com/) is a great tweening engine.
[BFXR](http://www.bfxr.net/) a great simple tool for generating computer game sound effects.
[woo, tangent](http://wootangent.net/music/) for suppling his music track 'Frozen Summer' under the CC license for use in the game.
[GoSquared](http://www.gosquared.com/) for suppying the entire set of world icons for us to use