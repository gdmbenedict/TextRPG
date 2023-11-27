# TextRPG
Text Based RPG Game in the style like Rogue, NetHack, or Moria. This is a project started for my game programming class at NSCC.

## Objects
One of the goals of this project is to make a RPG with an object oriented approach. this section will document what objects are implemented in the game and what thier methods and attributes are. For a broader overview of how objects interact with eachother you can check out this [UML diagram](https://lucid.app/lucidchart/77fd08c7-c823-40c0-83aa-9dac7418b2a6/edit?viewport_loc=-4145%2C-1670%2C5132%2C2545%2CHWEp-vi-RSFO&invitationId=inv_d677de9a-a347-41c5-9889-32853bd3508d) made using LucidChart.

### Tile
This object represents a basic tile on the map. 
#### Attributes
The object stores variables representing the properties of the tile. The properties are as follows.
- **Name:** The name of the type of tile. This attribute is stored in a string variable.
- **Symbol:** The graphical representation of the tile. This object is stored as a char variable.
- **Color:** The color of the graphical representation of the tile. This attribute is stored as the ConsoleColor enum variable provided in the systems namespace.
- **Impassable:** Whether or not the tile is one that entities can move through. This attribute is stored as a boolean variable.
- **Dangerous:** Whether or not the tile deals damage to entities standing on it. This attribute is stored as a boolean variable.
- **Damage:** The amount of damage dealt by the tile to entities standing on it. This attribute is stored as an int variable.
- **Damage Type:** The type of damage dealt by the tile to entities standing on it. This attributte is stored as a DamageType enum defined in the Tile class.

#### Methods
Methods associated with the Tile object are listed below.
- **Tile(char tileType):** Constructor method for a Tile object. The method changes a representative tile type into a tile.
- **SetName(string name):** Method that sets the name of the Tile.
- **GetName():** Method that gets the name of the Tile
- **SetSybmol(char symbol):** Method that sets the Tile symbol.
- **GetSymbol():** Method that returns the symbol of the Tile.
- **SetColor(ConsoleColor color):** Method that sets the color of Tile's symbol.
- **GetColor():** Method that returns the color of the Tile's symbol.
- **SetImpassable(bool impassable):** Method that sets the ability to move through the Tile to input boolean.
- **GetImpassable():** Method that returns the ability to move through the Tile as a boolean.
- **SetDangerous(bool dangerous):** Method that sets the ability for Tile to damage entities that walk through it.
- **GetDangerous():** Method that returns the Tile's ability to damage entities that walk through it.
- **SetDamage(int damage):** Method that sets the damage done by the Tile to entities that walk through it.
- **SetDamageType(DamageType damageType):** Method that sets the type of damage done by the Tile to entities that walk through it.
- **DealDamage():** Method that returns damage and damage type done by a Tile to entities that walk through it. 
