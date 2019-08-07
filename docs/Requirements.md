# Space Game Requirements

You and your pair programming teammate have been hired by a firm to provide a console-based prototype of a space game. Based on product owner requirements, spend the next few days implementing a space game.

## Requirements

The goal of this project is to build a space-trading game with the following characteristics:

### MVP

* Console-/text-based
* Goal: Trade any goods/services between planets for profit
* Compelling Story, including a "good ending"
* Bad ending: 60 years old or assets with total value <= 0
* Starting conditions: 18 year old character with a ship and goods or means to acquire a ship and goods
* Minimum of 3 planets: Earth, Proxima Centauri 1 (use the actual distance to Proxima Centauri), and one other of your choosing
* Distance/time relation based on Star Trek TNG warp equation (provided below)
* 2-D grid system with Earth as the origin
* Value of goods vary per-planet
* One universal currency
* Minimum of 5 items of trade

### Stretch goals

* "Character builder" with race/gender/etc.
* Space piracy/battles
* Illness
* Fuel usage
* Fuel requirements based on speed/load carried
* Ship load limits/upgrades
* Fluctuating economy
* Intelligence (paid or based on affinity with planets) or Scuttlebutt (overheard or based on affinity with NPCs), particularly regarding cost of items in other locations
* Additional means of acquiring goods
* Warp Equation
* Given Warp speed (W) with non-inclusive bounds of 0 and 10, velocity in multiples of the speed of light = W(10/3)  + (10 − W)(-11/3).  Thus, if you want to travel to a location 1 light year away in one day, you need a warp factor which equates to a velocity of 365.25 times the speed of light.

### Directory Structure

Your directory structure should be laid out as follows. Files listed represent a minimum set of included files; you will have more that aren't listed. Your submission should be a single ZIP archive created with git archive or Github's ZIP download.

.
|- code/
|  |- PROJECT.sln
|
|- docs/
|  |- requirements.md
|
|- README.md
