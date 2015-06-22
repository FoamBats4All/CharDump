using System;
using OEIShared.IO.GFF;

namespace CharDump
{
    class Program
    {
        static void Main(string[] args)
        {
            if ( args.Length != 1 )
            {
                Console.WriteLine("Usage: CharDump.exe <bic file path>");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                return;
            }

            try
            {
                GFFFile bic = new GFFFile(args[0]);
                GFFStruct top = bic.TopLevelStruct;

                // Print general character information.
                Console.WriteLine("Name: " + top.GetExoLocStringSafe("FirstName").GetSafeString(OEIShared.Utils.BWLanguages.BWLanguage.English) + " " + top.GetExoLocStringSafe("LastName").GetSafeString(OEIShared.Utils.BWLanguages.BWLanguage.English));
                Console.WriteLine("Abilities: "
                    + top.GetIntSafe("Str", -1) + " STR, "
                    + top.GetIntSafe("Dex", -1) + " DEX, "
                    + top.GetIntSafe("Con", -1) + " CON, "
                    + top.GetIntSafe("Int", -1) + " INT, "
                    + top.GetIntSafe("Wis", -1) + " WIS, "
                    + top.GetIntSafe("Cha", -1) + " CHA");
                Console.WriteLine("Saves: "
                    + top.GetIntSafe("FortSaveThrow", -1) + " FORT, "
                    + top.GetIntSafe("RefSaveThrow", -1) + " REFL, "
                    + top.GetIntSafe("WillSaveThrow", -1) + " WILL");

                Console.Write("Feats: ");
                foreach (GFFStruct featStruct in top.GetListSafe("FeatList").StructList)
                {
                    Console.Write(featStruct.GetWordSafe("Feat", 0) + " ");
                }
                Console.WriteLine();
                Console.WriteLine();

                // Levelup log.
                Console.WriteLine("Level Ups:");
                GFFStructCollection levelUpList = top.GetListSafe("LvlStatList").StructList;
                foreach (GFFStruct levelUp in levelUpList)
                {
                    Console.WriteLine("  Level " + (levelUpList.IndexOf(levelUp) + 1) + ":");
                    Console.WriteLine("    Class: " + levelUp.GetByteSafe("LvlStatClass", 0xFF));

                    if (levelUp.Contains("LvlStatAbility"))
                    {
                        Console.WriteLine("    Ability: " + levelUp.GetByteSafe("LvlStatAbility", 0xFF));
                    }

                    Console.Write("    Skills: ");
                    GFFStructCollection skillList = levelUp.GetListSafe("SkillList").StructList;
                    foreach (GFFStruct skill in skillList)
                    {
                        int rank = skill.GetWordSafe("Rank", 0);
                        if (rank != 0)
                        {
                            Console.Write(skillList.IndexOf(skill) + ":" + rank + " ");
                        }
                    }
                    Console.WriteLine();

                    Console.Write("    Feats: ");
                    foreach (GFFStruct feat in levelUp.GetListSafe("FeatList").StructList)
                    {
                        Console.Write(feat.GetWordSafe("Feat", 0) + " ");
                    }
                    Console.WriteLine();

                    for (int i = 0; i < 10; i++)
                    {
                        string field = "KnownList" + i;
                        if (levelUp.Contains(field))
                        {
                            Console.Write("    Spells " + i + ": ");
                            foreach (GFFStruct spell in levelUp.GetListSafe(field).StructList)
                            {
                                Console.Write(spell.GetWordSafe("Spell", 0) + " ");
                            }
                            Console.WriteLine();
                        }
                    }
                }
            }
            catch( Exception e )
            {
                Console.WriteLine("There was an error while reading the bic file:");
                Console.WriteLine("\t" + e.Message);
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            return;
        }
    }
}