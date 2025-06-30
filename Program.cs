// See https://aka.ms/new-console-template for more information


using FemmeFataleCode;

static void Main(string[] args)
{
    PlayableCharacters Cobalt = new PlayableCharacters();
    PlayableCharacters Hallia = new PlayableCharacters();
    PlayableCharacters Ovior = new PlayableCharacters();
   PlayableCharacters Trarko =  new PlayableCharacters();

   Cobalt.name = "Cobalt";
   Cobalt.role = "Druid";
   Cobalt.power = "Animal Morphism";
   Console.WriteLine("Name: " + Cobalt.name);
   Console.WriteLine("Role:" + Cobalt.role);
   Console.WriteLine("Power:" + Cobalt.power);
   Console.WriteLine("Power Description: Can morph into a snake to slip through cracks or kangaroo to jump higher"); 
   Cobalt.speed = 5f;

Hallia.name = "Hallia";
   Hallia.role = "Rogue";
   Hallia.power = "Stealth";
   Console.WriteLine("Name: " + Hallia.name);
   Console.WriteLine("Role:" + Hallia.role);
   Console.WriteLine("Power:" + Hallia.power);
   Console.WriteLine("Power Description: Will not notify enemies and can sneak attack");
   Hallia.speed = 5f;

   Ovior.name = "Ovior";
   Ovior.role = "Wizard";
   Ovior.power = "Spellcast";
   Console.WriteLine("Name: " + Ovior.name);
   Console.WriteLine("Role:" + Ovior.role);
   Console.WriteLine("Power:" + Ovior.power );
   Console.WriteLine("Power Description: Carries 2x Healing Potions and 2x Damage Potions at the start of each level");
   Ovior.speed = 5f;

   Trarko.name = "Trarko";
   Trarko.role = "Barbarian";
   Trarko.power = "Destruction";
   Console.WriteLine("Name: " + Trarko.name);
   Console.WriteLine("Role: " + Trarko.role);
   Console.WriteLine("Power:" + Trarko.power);
   Console.WriteLine("Power Description: Can easily break any wall and one hit enemies");
   Trarko.speed = 5f;



}