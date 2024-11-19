using Mandatory2DGameFramework;
using Mandatory2DGameFramework.model.attack;
using Mandatory2DGameFramework.model.Cretures;
using Mandatory2DGameFramework.model.Cretures.Mandatory2DGameFramework.model.Creatures;
using Mandatory2DGameFramework.worlds;
using System.Xml;

MyLogger myLogger = MyLogger.Instance();
myLogger.Start();

XmlDocument configDoc = new XmlDocument();
configDoc.Load("C:/Users/Panta/OneDrive/Skrivebord/4. semester/ASWC/Mandatory2DGameFramework/GameApp/App.xml");

if (configDoc.DocumentElement == null)
{
    Console.WriteLine("Not found");
    return;
}

XmlNodeList creatures = configDoc.DocumentElement.SelectNodes("creatures/creature");
XmlNodeList attackItem = configDoc.DocumentElement.SelectNodes("attackitem");
XmlNodeList defenceItem = configDoc.DocumentElement.SelectNodes("defenceitem");
XmlNodeList worldObject = configDoc.DocumentElement.SelectNodes("worldobject/worldobject");


World world = new World(100, 100);


foreach (XmlNode node in creatures)
{
   
    Creature creature = new Creature(node["name"].InnerText, int.Parse(node["hp"].InnerText));
    Console.WriteLine(creature.ToString());
    
    
}

ICreature monster = new Creature("Monster", 100);
ICreature armoredMonster = new ArmorDecorator(monster, 10);

Console.WriteLine(armoredMonster.ToString());
armoredMonster.ReceiveHit(20);
Console.WriteLine(armoredMonster.ToString());

//Creature creature1 = new Creature("Werewolf");
//Creature creature2 = new Creature("Vampire");
//Creature creature3 = new Creature("Fairy");

//world.InsertCreature(20, 10, creature1);
//world.InsertCreature(20, 20, creature2);
//world.InsertCreature(20, 20, creature3);

//Console.WriteLine(creature1.ToString());
//Console.WriteLine(creature2.ToString());

//creature1.Hit(creature2);
//Console.WriteLine(creature2.ToString());

//creature2.ReceiveHit(200);
//Console.WriteLine(creature2.ToString());
//creature2.Hit(creature1);
//Console.WriteLine(creature1.ToString());

//AttackItem attack = new AttackItem("Sword", 10);
//world.InsertWorldObject(10, 5, attack);