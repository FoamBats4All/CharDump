# CharDump
Quick utility for dumping useful information from a Neverwinter Nights 2 .bic file.


# Usage
```
CharDump.exe <path to .bic file>
```

# Features
The current data is supported:

* Character basics:
	* Name
	* Skill ranks, formatted `<skill id>`:`ranks`
	* Feat list.
* Level up history:
	* Class leveled up in.
	* Ability bonus chosen.
	* Skill rank allocation.
	* Feats gained.
	* Spells learned.

# Output
The application creates an output that looks like:
```
Name: Bob
Abilities: 13 STR, 18 DEX, 10 CON, 14 INT, 12 WIS, 12 CHA
Saves: 11 FORT, 17 REFL, 7 WILL
Feats: 3 10 27 32 40 42 45 46 50 199 206 258 275 285 289 382 1103 1116 1387 1721 1730 1731 1732 1773 1774 1857 2137 2141
 3500 3501 3569 3618 3668 3740

Level Ups:
  Level 1:
    Class: 8
    Skills: 0:2 2:4 5:4 6:2 8:4 9:4 13:2 17:2 20:4 21:4 23:4 32:1 36:1 37:4 59:4
    Feats: 3 46 50 258 382 1721 1773 1774 1857 3501 3569
  Level 2:
    Class: 7
    Skills: 5:1 8:1 21:1 29:2 33:1 42:2 64:1
    Feats: 32 45 275 1116
  Level 3:
    Class: 7
    Skills: 6:1 7:1 20:1 38:1 40:1 41:1 46:1 50:1 55:1 59:1
    Feats: 27 1730 1731 3618
  Level 4:
    Class: 59
    Ability: 1
    Skills: 5:2 19:2 23:1 48:1 52:1
    Feats: 42 3618
  Level 5:
    Class: 7
    Skills: 5:1 8:2 16:1 19:2 29:2 58:1
    Feats: 40 3618
  Level 6:
    Class: 8
    Skills: 2:1 5:1 8:2 9:1 13:1 34:1 36:1 43:1 52:1 56:1
    Feats: 206 3618
  Level 7:
    Class: 7
    Skills: 5:1 8:1 21:5 23:1 47:1
    Feats: 199 3618 3668
  Level 8:
    Class: 59
    Ability: 4
    Skills: 17:3 42:3 44:1
    Feats: 2137 3618
  Level 9:
    Class: 59
    Skills: 9:5 23:1 50:1
    Feats: 10 2141 3618
  Level 10:
    Class: 8
    Skills: 11:4 29:5 46:4 48:1 52:1
    Feats: 1387 3618
  Level 11:
    Class: 7
    Skills: 5:1 8:4 9:2 11:251 52:2
    Feats: 285 3618 3740
  Level 12:
    Class: 7
    Ability: 4
    Skills: 5:3 8:1 23:3 52:2
    Feats: 289 1103 1732 3500 3618
```