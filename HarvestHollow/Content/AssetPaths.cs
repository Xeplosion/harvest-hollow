using System.Collections.Generic;

namespace HarvestHollow.Content
{
    internal class AssetDictionary
    {
        protected static readonly Dictionary<AssetSection, List<(string, string)>> AssetPaths = new Dictionary<AssetSection, List<(string, string)>>
            {
                { 
                    // All SFX names and paths.
                    AssetSection.SFX, new List<(string, string)>
                    { 
                        // BassDrum SFX:
                        ("SFX_BassDrum_001", "Sound/SFX/BassDrum/Ogg/Bass Drum__001"),
                        ("SFX_BassDrum_002", "Sound/SFX/BassDrum/Ogg/Bass Drum__002"),
                        ("SFX_BassDrum_003", "Sound/SFX/BassDrum/Ogg/Bass Drum__003"),
                        ("SFX_BassDrum_004", "Sound/SFX/BassDrum/Ogg/Bass Drum__004"),
                        ("SFX_BassDrum_005", "Sound/SFX/BassDrum/Ogg/Bass Drum__005"),
                        ("SFX_BassDrum_006", "Sound/SFX/BassDrum/Ogg/Bass Drum__006"),
                        ("SFX_BassDrum_007", "Sound/SFX/BassDrum/Ogg/Bass Drum__007"),
                        ("SFX_BassDrum_008", "Sound/SFX/BassDrum/Ogg/Bass Drum__008"),
                        ("SFX_BassDrum_009", "Sound/SFX/BassDrum/Ogg/Bass Drum__009"),
                        ("SFX_BassDrum_010", "Sound/SFX/BassDrum/Ogg/Bass Drum__010"),

                        // Explosion SFX:
                        ("SFX_Explosion_001", "Sound/SFX/Explosion/Ogg/Explosion__001"),
                        ("SFX_Explosion_002", "Sound/SFX/Explosion/Ogg/Explosion__002"),
                        ("SFX_Explosion_003", "Sound/SFX/Explosion/Ogg/Explosion__003"),
                        ("SFX_Explosion_004", "Sound/SFX/Explosion/Ogg/Explosion__004"),
                        ("SFX_Explosion_005", "Sound/SFX/Explosion/Ogg/Explosion__005"),
                        ("SFX_Explosion_006", "Sound/SFX/Explosion/Ogg/Explosion__006"),
                        ("SFX_Explosion_007", "Sound/SFX/Explosion/Ogg/Explosion__007"),
                        ("SFX_Explosion_008", "Sound/SFX/Explosion/Ogg/Explosion__008"),
                        ("SFX_Explosion_009", "Sound/SFX/Explosion/Ogg/Explosion__009"),
                        ("SFX_Explosion_010", "Sound/SFX/Explosion/Ogg/Explosion__010"),

                        ("SFX_Explosion2_001", "Sound/SFX/Explosion2/Ogg/Explosion2__001"),
                        ("SFX_Explosion2_002", "Sound/SFX/Explosion2/Ogg/Explosion2__002"),
                        ("SFX_Explosion2_003", "Sound/SFX/Explosion2/Ogg/Explosion2__003"),
                        ("SFX_Explosion2_004", "Sound/SFX/Explosion2/Ogg/Explosion2__004"),
                        ("SFX_Explosion2_005", "Sound/SFX/Explosion2/Ogg/Explosion2__005"),
                        ("SFX_Explosion2_006", "Sound/SFX/Explosion2/Ogg/Explosion2__006"),
                        ("SFX_Explosion2_007", "Sound/SFX/Explosion2/Ogg/Explosion2__007"),
                        ("SFX_Explosion2_008", "Sound/SFX/Explosion2/Ogg/Explosion2__008"),
                        ("SFX_Explosion2_009", "Sound/SFX/Explosion2/Ogg/Explosion2__009"),
                        ("SFX_Explosion2_010", "Sound/SFX/Explosion2/Ogg/Explosion2__010"),

                        ("SFX_Explosion3_001", "Sound/SFX/Explosion3/Ogg/Explosion3__001"),
                        ("SFX_Explosion3_002", "Sound/SFX/Explosion3/Ogg/Explosion3__002"),
                        ("SFX_Explosion3_003", "Sound/SFX/Explosion3/Ogg/Explosion3__003"),
                        ("SFX_Explosion3_004", "Sound/SFX/Explosion3/Ogg/Explosion3__004"),
                        ("SFX_Explosion3_005", "Sound/SFX/Explosion3/Ogg/Explosion3__005"),
                        ("SFX_Explosion3_006", "Sound/SFX/Explosion3/Ogg/Explosion3__006"),
                        ("SFX_Explosion3_007", "Sound/SFX/Explosion3/Ogg/Explosion3__007"),
                        ("SFX_Explosion3_008", "Sound/SFX/Explosion3/Ogg/Explosion3__008"),
                        ("SFX_Explosion3_009", "Sound/SFX/Explosion3/Ogg/Explosion3__009"),
                        ("SFX_Explosion3_010", "Sound/SFX/Explosion3/Ogg/Explosion3__010"),

                        // Footstep SFX:
                        ("SFX_Footstep_001", "Sound/SFX/Footstep/Ogg/Footstep__001"),
                        ("SFX_Footstep_002", "Sound/SFX/Footstep/Ogg/Footstep__002"),
                        ("SFX_Footstep_003", "Sound/SFX/Footstep/Ogg/Footstep__003"),
                        ("SFX_Footstep_004", "Sound/SFX/Footstep/Ogg/Footstep__004"),
                        ("SFX_Footstep_005", "Sound/SFX/Footstep/Ogg/Footstep__005"),
                        ("SFX_Footstep_006", "Sound/SFX/Footstep/Ogg/Footstep__006"),
                        ("SFX_Footstep_007", "Sound/SFX/Footstep/Ogg/Footstep__007"),
                        ("SFX_Footstep_008", "Sound/SFX/Footstep/Ogg/Footstep__008"),
                        ("SFX_Footstep_009", "Sound/SFX/Footstep/Ogg/Footstep__009"),
                        ("SFX_Footstep_010", "Sound/SFX/Footstep/Ogg/Footstep__010"),

                        // HiHat SFX:
                        ("SFX_HiHat_001", "Sound/SFX/HiHat/Ogg/Hi-hat__001"),
                        ("SFX_HiHat_002", "Sound/SFX/HiHat/Ogg/Hi-hat__002"),
                        ("SFX_HiHat_003", "Sound/SFX/HiHat/Ogg/Hi-hat__003"),
                        ("SFX_HiHat_004", "Sound/SFX/HiHat/Ogg/Hi-hat__004"),
                        ("SFX_HiHat_005", "Sound/SFX/HiHat/Ogg/Hi-hat__005"),
                        ("SFX_HiHat_006", "Sound/SFX/HiHat/Ogg/Hi-hat__006"),
                        ("SFX_HiHat_007", "Sound/SFX/HiHat/Ogg/Hi-hat__007"),
                        ("SFX_HiHat_008", "Sound/SFX/HiHat/Ogg/Hi-hat__008"),
                        ("SFX_HiHat_009", "Sound/SFX/HiHat/Ogg/Hi-hat__009"),
                        ("SFX_HiHat_010", "Sound/SFX/HiHat/Ogg/Hi-hat__010"),

                        // Instrument SFX:
                        ("SFX_Instrument_001", "Sound/SFX/Instrument/Ogg/Instrument__001"),
                        ("SFX_Instrument_002", "Sound/SFX/Instrument/Ogg/Instrument__002"),
                        ("SFX_Instrument_003", "Sound/SFX/Instrument/Ogg/Instrument__003"),
                        ("SFX_Instrument_004", "Sound/SFX/Instrument/Ogg/Instrument__004"),
                        ("SFX_Instrument_005", "Sound/SFX/Instrument/Ogg/Instrument__005"),
                        ("SFX_Instrument_006", "Sound/SFX/Instrument/Ogg/Instrument__006"),
                        ("SFX_Instrument_007", "Sound/SFX/Instrument/Ogg/Instrument__007"),
                        ("SFX_Instrument_008", "Sound/SFX/Instrument/Ogg/Instrument__008"),
                        ("SFX_Instrument_009", "Sound/SFX/Instrument/Ogg/Instrument__009"),
                        ("SFX_Instrument_010", "Sound/SFX/Instrument/Ogg/Instrument__010"),

                        // Jump SFX:
                        ("SFX_Jump_001", "Sound/SFX/Jump/Ogg/Jump__001"),
                        ("SFX_Jump_002", "Sound/SFX/Jump/Ogg/Jump__002"),
                        ("SFX_Jump_003", "Sound/SFX/Jump/Ogg/Jump__003"),
                        ("SFX_Jump_004", "Sound/SFX/Jump/Ogg/Jump__004"),
                        ("SFX_Jump_005", "Sound/SFX/Jump/Ogg/Jump__005"),
                        ("SFX_Jump_006", "Sound/SFX/Jump/Ogg/Jump__006"),
                        ("SFX_Jump_007", "Sound/SFX/Jump/Ogg/Jump__007"),
                        ("SFX_Jump_008", "Sound/SFX/Jump/Ogg/Jump__008"),
                        ("SFX_Jump_009", "Sound/SFX/Jump/Ogg/Jump__009"),
                        ("SFX_Jump_010", "Sound/SFX/Jump/Ogg/Jump__010"),

                        // Menu SFX:
                        ("SFX_Menu_001", "Sound/SFX/Menu/Ogg/Menu__001"),
                        ("SFX_Menu_002", "Sound/SFX/Menu/Ogg/Menu__002"),
                        ("SFX_Menu_003", "Sound/SFX/Menu/Ogg/Menu__003"),
                        ("SFX_Menu_004", "Sound/SFX/Menu/Ogg/Menu__004"),
                        ("SFX_Menu_005", "Sound/SFX/Menu/Ogg/Menu__005"),
                        ("SFX_Menu_006", "Sound/SFX/Menu/Ogg/Menu__006"),
                        ("SFX_Menu_007", "Sound/SFX/Menu/Ogg/Menu__007"),
                        ("SFX_Menu_008", "Sound/SFX/Menu/Ogg/Menu__008"),
                        ("SFX_Menu_009", "Sound/SFX/Menu/Ogg/Menu__009"),
                        ("SFX_Menu_010", "Sound/SFX/Menu/Ogg/Menu__010"),

                        // Ouch SFX:
                        ("SFX_Ouch_001", "Sound/SFX/Ouch/Ogg/Ouch__001"),
                        ("SFX_Ouch_002", "Sound/SFX/Ouch/Ogg/Ouch__002"),
                        ("SFX_Ouch_003", "Sound/SFX/Ouch/Ogg/Ouch__003"),
                        ("SFX_Ouch_004", "Sound/SFX/Ouch/Ogg/Ouch__004"),
                        ("SFX_Ouch_005", "Sound/SFX/Ouch/Ogg/Ouch__005"),
                        ("SFX_Ouch_006", "Sound/SFX/Ouch/Ogg/Ouch__006"),
                        ("SFX_Ouch_007", "Sound/SFX/Ouch/Ogg/Ouch__007"),
                        ("SFX_Ouch_008", "Sound/SFX/Ouch/Ogg/Ouch__008"),
                        ("SFX_Ouch_009", "Sound/SFX/Ouch/Ogg/Ouch__009"),
                        ("SFX_Ouch_010", "Sound/SFX/Ouch/Ogg/Ouch__010"),

                        // Pew SFX:
                        ("SFX_Pew_001", "Sound/SFX/Pew/Ogg/Pew__001"),
                        ("SFX_Pew_002", "Sound/SFX/Pew/Ogg/Pew__002"),
                        ("SFX_Pew_003", "Sound/SFX/Pew/Ogg/Pew__003"),
                        ("SFX_Pew_004", "Sound/SFX/Pew/Ogg/Pew__004"),
                        ("SFX_Pew_005", "Sound/SFX/Pew/Ogg/Pew__005"),
                        ("SFX_Pew_006", "Sound/SFX/Pew/Ogg/Pew__006"),
                        ("SFX_Pew_007", "Sound/SFX/Pew/Ogg/Pew__007"),
                        ("SFX_Pew_008", "Sound/SFX/Pew/Ogg/Pew__008"),
                        ("SFX_Pew_009", "Sound/SFX/Pew/Ogg/Pew__009"),
                        ("SFX_Pew_010", "Sound/SFX/Pew/Ogg/Pew__010"),

                        // Pickup SFX:
                        ("SFX_Pickup_001", "Sound/SFX/Pickup/Ogg/Pickup__001"),
                        ("SFX_Pickup_002", "Sound/SFX/Pickup/Ogg/Pickup__002"),
                        ("SFX_Pickup_003", "Sound/SFX/Pickup/Ogg/Pickup__003"),
                        ("SFX_Pickup_004", "Sound/SFX/Pickup/Ogg/Pickup__004"),
                        ("SFX_Pickup_005", "Sound/SFX/Pickup/Ogg/Pickup__005"),
                        ("SFX_Pickup_006", "Sound/SFX/Pickup/Ogg/Pickup__006"),
                        ("SFX_Pickup_007", "Sound/SFX/Pickup/Ogg/Pickup__007"),
                        ("SFX_Pickup_008", "Sound/SFX/Pickup/Ogg/Pickup__008"),
                        ("SFX_Pickup_009", "Sound/SFX/Pickup/Ogg/Pickup__009"),
                        ("SFX_Pickup_010", "Sound/SFX/Pickup/Ogg/Pickup__010"),

                        // Powerup  SFX:
                        ("SFX_Powerup_001", "Sound/SFX/Powerup/Ogg/Powerup__001"),
                        ("SFX_Powerup_002", "Sound/SFX/Powerup/Ogg/Powerup__002"),
                        ("SFX_Powerup_003", "Sound/SFX/Powerup/Ogg/Powerup__003"),
                        ("SFX_Powerup_004", "Sound/SFX/Powerup/Ogg/Powerup__004"),
                        ("SFX_Powerup_005", "Sound/SFX/Powerup/Ogg/Powerup__005"),
                        ("SFX_Powerup_006", "Sound/SFX/Powerup/Ogg/Powerup__006"),
                        ("SFX_Powerup_007", "Sound/SFX/Powerup/Ogg/Powerup__007"),
                        ("SFX_Powerup_008", "Sound/SFX/Powerup/Ogg/Powerup__008"),
                        ("SFX_Powerup_009", "Sound/SFX/Powerup/Ogg/Powerup__009"),
                        ("SFX_Powerup_010", "Sound/SFX/Powerup/Ogg/Powerup__010"),

                        // Punch SFX:
                        ("SFX_Punch_001", "Sound/SFX/Punch/Ogg/Punch__001"),
                        ("SFX_Punch_002", "Sound/SFX/Punch/Ogg/Punch__002"),
                        ("SFX_Punch_003", "Sound/SFX/Punch/Ogg/Punch__003"),
                        ("SFX_Punch_004", "Sound/SFX/Punch/Ogg/Punch__004"),
                        ("SFX_Punch_005", "Sound/SFX/Punch/Ogg/Punch__005"),
                        ("SFX_Punch_006", "Sound/SFX/Punch/Ogg/Punch__006"),
                        ("SFX_Punch_007", "Sound/SFX/Punch/Ogg/Punch__007"),
                        ("SFX_Punch_008", "Sound/SFX/Punch/Ogg/Punch__008"),
                        ("SFX_Punch_009", "Sound/SFX/Punch/Ogg/Punch__009"),
                        ("SFX_Punch_010", "Sound/SFX/Punch/Ogg/Punch__010"),

                        ("SFX_Punch2_001", "Sound/SFX/Punch2/Ogg/Punch2__001"),
                        ("SFX_Punch2_002", "Sound/SFX/Punch2/Ogg/Punch2__002"),
                        ("SFX_Punch2_003", "Sound/SFX/Punch2/Ogg/Punch2__003"),
                        ("SFX_Punch2_004", "Sound/SFX/Punch2/Ogg/Punch2__004"),
                        ("SFX_Punch2_005", "Sound/SFX/Punch2/Ogg/Punch2__005"),
                        ("SFX_Punch2_006", "Sound/SFX/Punch2/Ogg/Punch2__006"),
                        ("SFX_Punch2_007", "Sound/SFX/Punch2/Ogg/Punch2__007"),
                        ("SFX_Punch2_008", "Sound/SFX/Punch2/Ogg/Punch2__008"),
                        ("SFX_Punch2_009", "Sound/SFX/Punch2/Ogg/Punch2__009"),
                        ("SFX_Punch2_010", "Sound/SFX/Punch2/Ogg/Punch2__010"),

                        // Roar SFX:
                        ("SFX_Roar_001", "Sound/SFX/Roar/Ogg/Roar__001"),
                        ("SFX_Roar_002", "Sound/SFX/Roar/Ogg/Roar__002"),
                        ("SFX_Roar_003", "Sound/SFX/Roar/Ogg/Roar__003"),
                        ("SFX_Roar_004", "Sound/SFX/Roar/Ogg/Roar__004"),
                        ("SFX_Roar_005", "Sound/SFX/Roar/Ogg/Roar__005"),
                        ("SFX_Roar_006", "Sound/SFX/Roar/Ogg/Roar__006"),
                        ("SFX_Roar_007", "Sound/SFX/Roar/Ogg/Roar__007"),
                        ("SFX_Roar_008", "Sound/SFX/Roar/Ogg/Roar__008"),
                        ("SFX_Roar_009", "Sound/SFX/Roar/Ogg/Roar__009"),
                        ("SFX_Roar_010", "Sound/SFX/Roar/Ogg/Roar__010"),

                        // Snare SFX:
                        ("SFX_Snare_001", "Sound/SFX/Snare/Ogg/Snare__001"),
                        ("SFX_Snare_002", "Sound/SFX/Snare/Ogg/Snare__002"),
                        ("SFX_Snare_003", "Sound/SFX/Snare/Ogg/Snare__003"),
                        ("SFX_Snare_004", "Sound/SFX/Snare/Ogg/Snare__004"),
                        ("SFX_Snare_005", "Sound/SFX/Snare/Ogg/Snare__005"),
                        ("SFX_Snare_006", "Sound/SFX/Snare/Ogg/Snare__006"),
                        ("SFX_Snare_007", "Sound/SFX/Snare/Ogg/Snare__007"),
                        ("SFX_Snare_008", "Sound/SFX/Snare/Ogg/Snare__008"),
                        ("SFX_Snare_009", "Sound/SFX/Snare/Ogg/Snare__009"),
                        ("SFX_Snare_010", "Sound/SFX/Snare/Ogg/Snare__010"),

                        // Space SFX:
                        ("SFX_Space_001", "Sound/SFX/Space/Ogg/Space__001"),
                        ("SFX_Space_002", "Sound/SFX/Space/Ogg/Space__002"),
                        ("SFX_Space_003", "Sound/SFX/Space/Ogg/Space__003"),
                        ("SFX_Space_004", "Sound/SFX/Space/Ogg/Space__004"),
                        ("SFX_Space_005", "Sound/SFX/Space/Ogg/Space__005"),
                        ("SFX_Space_006", "Sound/SFX/Space/Ogg/Space__006"),
                        ("SFX_Space_007", "Sound/SFX/Space/Ogg/Space__007"),
                        ("SFX_Space_008", "Sound/SFX/Space/Ogg/Space__008"),
                        ("SFX_Space_009", "Sound/SFX/Space/Ogg/Space__009"),
                        ("SFX_Space_010", "Sound/SFX/Space/Ogg/Space__010"),

                        // Starpower SFX:
                        ("SFX_Starpower_001", "Sound/SFX/Starpower/Ogg/Starpower__001"),
                        ("SFX_Starpower_002", "Sound/SFX/Starpower/Ogg/Starpower__002"),
                        ("SFX_Starpower_003", "Sound/SFX/Starpower/Ogg/Starpower__003"),
                        ("SFX_Starpower_004", "Sound/SFX/Starpower/Ogg/Starpower__004"),
                        ("SFX_Starpower_005", "Sound/SFX/Starpower/Ogg/Starpower__005"),
                        ("SFX_Starpower_006", "Sound/SFX/Starpower/Ogg/Starpower__006"),
                        ("SFX_Starpower_007", "Sound/SFX/Starpower/Ogg/Starpower__007"),
                        ("SFX_Starpower_008", "Sound/SFX/Starpower/Ogg/Starpower__008"),
                        ("SFX_Starpower_009", "Sound/SFX/Starpower/Ogg/Starpower__009"),
                        ("SFX_Starpower_010", "Sound/SFX/Starpower/Ogg/Starpower__010"),

                        // Teleport SFX:
                        ("SFX_Teleport_001", "Sound/SFX/Teleport/Ogg/Teleport__001"),
                        ("SFX_Teleport_002", "Sound/SFX/Teleport/Ogg/Teleport__002"),
                        ("SFX_Teleport_003", "Sound/SFX/Teleport/Ogg/Teleport__003"),
                        ("SFX_Teleport_004", "Sound/SFX/Teleport/Ogg/Teleport__004"),
                        ("SFX_Teleport_005", "Sound/SFX/Teleport/Ogg/Teleport__005"),
                        ("SFX_Teleport_006", "Sound/SFX/Teleport/Ogg/Teleport__006"),
                        ("SFX_Teleport_007", "Sound/SFX/Teleport/Ogg/Teleport__007"),
                        ("SFX_Teleport_008", "Sound/SFX/Teleport/Ogg/Teleport__008"),
                        ("SFX_Teleport_009", "Sound/SFX/Teleport/Ogg/Teleport__009"),
                        ("SFX_Teleport_010", "Sound/SFX/Teleport/Ogg/Teleport__010"),

                        ("SFX_Teleport2_001", "Sound/SFX/Teleport2/Ogg/Teleport2_001"),
                        ("SFX_Teleport2_002", "Sound/SFX/Teleport2/Ogg/Teleport2_002"),
                        ("SFX_Teleport2_003", "Sound/SFX/Teleport2/Ogg/Teleport2_003"),
                        ("SFX_Teleport2_004", "Sound/SFX/Teleport2/Ogg/Teleport2_004"),
                        ("SFX_Teleport2_005", "Sound/SFX/Teleport2/Ogg/Teleport2_005"),
                        ("SFX_Teleport2_006", "Sound/SFX/Teleport2/Ogg/Teleport2_006"),
                        ("SFX_Teleport2_007", "Sound/SFX/Teleport2/Ogg/Teleport2_007"),
                        ("SFX_Teleport2_008", "Sound/SFX/Teleport2/Ogg/Teleport2_008"),
                        ("SFX_Teleport2_009", "Sound/SFX/Teleport2/Ogg/Teleport2_009"),
                        ("SFX_Teleport2_010", "Sound/SFX/Teleport2/Ogg/Teleport2_010")
                    }
                },
                {
                    AssetSection.OST, new List<(string, string)>
                    { 
                        // SECTION I AUDIO:
                        ("OST_101", "Sound/OST/101-Landscape"),
                        ("OST_102", "Sound/OST/102-Revalation"),
                        ("OST_103", "Sound/OST/103-LivelyKnight"),
                        ("OST_104", "Sound/OST/104-"),
                        ("OST_105", "Sound/OST/105-ShoutOfVictory"),
                        ("OST_106", "Sound/OST/106-AttractiveLegend"),
                        ("OST_107", "Sound/OST/107-DivineProtection"),
                        ("OST_108", "Sound/OST/108-"),
                        ("OST_109", "Sound/OST/109-"),
                        ("OST_110", "Sound/OST/110-"),
                        ("OST_111", "Sound/OST/111-TroublesomeHero"),
                        ("OST_112", "Sound/OST/112-"),
                        ("OST_113", "Sound/OST/113-"),
                        ("OST_114", "Sound/OST/114-Kartia"),
                        ("OST_115", "Sound/OST/115-"),
                        ("OST_116", "Sound/OST/116-"),
                        ("OST_117", "Sound/OST/117-Saladinart"),
                        ("OST_118", "Sound/OST/118-ToxaTakeOff"),
                        ("OST_119", "Sound/OST/119-"),
                        ("OST_120", "Sound/OST/120-DanceOfWorlds"),
                        ("OST_121", "Sound/OST/121-ThemeOfToxaClassico"),
                        ("OST_122", "Sound/OST/122-KnightOfLibertyToxa"),
                        ("OST_123", "Sound/OST/123-ThanksToToxa"),
                        ("OST_124", "Sound/OST/124-Rebus"),
                        ("OST_125", "Sound/OST/125-"),
                        ("OST_126", "Sound/OST/126-FeelUneasy"),
                        ("OST_127", "Sound/OST/127-VigilanceCommittee"),
                        ("OST_128", "Sound/OST/128-"),
                        ("OST_129", "Sound/OST/129-"),
                        ("OST_130", "Sound/OST/130-Ominous"),
                        ("OST_131", "Sound/OST/131-"),
                        ("OST_132", "Sound/OST/132-TrueInvestigator"),
                        ("OST_133", "Sound/OST/133-"),
                        ("OST_134", "Sound/OST/134-"),
                        ("OST_135", "Sound/OST/135-"),
                        ("OST_136", "Sound/OST/136-LacrymaTakeOff"),
                        ("OST_137", "Sound/OST/137-TheFireSide"),
                        ("OST_138", "Sound/OST/138-"),
                        ("OST_139", "Sound/OST/139-VenerableTree"),
                        ("OST_140", "Sound/OST/140-"),
                        ("OST_141", "Sound/OST/141-ThemeOfLacrymaChristi"),
                        ("OST_142", "Sound/OST/142-ProcessionOfSaints"),
                        ("OST_143", "Sound/OST/143-ThanksToLacryma"),
                        ("OST_144", "Sound/OST/144-Portrait"),

                        // SECTION II AUDIO:
                        ("OST_201", "Sound/OST/201-DivineProtection"),
                        ("OST_202", "Sound/OST/202-Saladinart"),
                        ("OST_203", "Sound/OST/203-Toxa"),
                        ("OST_204", "Sound/OST/204-Lacryma"),
                        ("OST_205", "Sound/OST/205-PianoStringsSadSituation"),
                        ("OST_206", "Sound/OST/206-DecisiveBattle"),
                        ("OST_207", "Sound/OST/207-GuitarDanceOfWords"),
                        ("OST_208", "Sound/OST/208-StringsConversation"),
                        ("OST_209", "Sound/OST/209-PianoSilence"),
                        ("OST_210", "Sound/OST/210-OrchestratedRebus")
                    }
                },
                {
                    AssetSection.LDtk, new List<(string, string)>
                    {

                    }
                },
                {
                    AssetSection.CharacterSheets, new List<(string, string)>
                    {
                        // /* ---- CHARACTER SHEETS ---- */

                        // Character base.
                        ("demn_v01", "Images/SpriteSheets/Characters/CharacterBase/demn_v01"),
                        ("demn_v02", "Images/SpriteSheets/Characters/CharacterBase/demn_v02"),

                        ("gbln_v01", "Images/SpriteSheets/Characters/CharacterBase/gbln_v01"),

                        ("humn_v00", "Images/SpriteSheets/Characters/CharacterBase/humn_v00"),
                        ("humn_v01", "Images/SpriteSheets/Characters/CharacterBase/humn_v01"),
                        ("humn_v02", "Images/SpriteSheets/Characters/CharacterBase/humn_v02"),
                        ("humn_v03", "Images/SpriteSheets/Characters/CharacterBase/humn_v03"),
                        ("humn_v04", "Images/SpriteSheets/Characters/CharacterBase/humn_v04"),
                        ("humn_v05", "Images/SpriteSheets/Characters/CharacterBase/humn_v05"),
                        ("humn_v06", "Images/SpriteSheets/Characters/CharacterBase/humn_v06"),
                        ("humn_v07", "Images/SpriteSheets/Characters/CharacterBase/humn_v07"),
                        ("humn_v08", "Images/SpriteSheets/Characters/CharacterBase/humn_v08"),
                        ("humn_v09", "Images/SpriteSheets/Characters/CharacterBase/humn_v09"),
                        ("humn_v10", "Images/SpriteSheets/Characters/CharacterBase/humn_v10"),

                        // /* ---- FARMER SPRITE SYSTEM ---- */

                        // 00undr
                        ("fbas_00undr_cloakplain_00d", "Images/SpriteSheets/Characters/CharacterBase/FarmerSprite/00undr/fbas_00undr_cloakplain_00d"),
                        
                        // 01body
                        ("fbas_01body_human_00", "Images/SpriteSheets/Characters/CharacterBase/FarmerSprite/01body/fbas_01body_human_00"),

                        // 02sock
                        ("fbas_02sock_sockshigh_00a", "Images/SpriteSheets/Characters/CharacterBase/FarmerSprite/02sock/fbas_02sock_sockshigh_00a"),
                        ("fbas_02sock_sockslow_00a", "Images/SpriteSheets/Characters/CharacterBase/FarmerSprite/02sock/fbas_02sock_sockslow_00a"),
                        ("fbas_02sock_stockings_00a", "Images/SpriteSheets/Characters/CharacterBase/FarmerSprite/02sock/fbas_02sock_stockings_00a"),

                        // 03fot1
                        ("fbas_03fot1_boots_00a", "Images/SpriteSheets/Characters/CharacterBase/FarmerSprite/03fot1/fbas_03fot1_boots_00a"),
                        ("fbas_03fot1_sandals_00a", "Images/SpriteSheets/Characters/CharacterBase/FarmerSprite/03fot1/fbas_03fot1_sandals_00a"),
                        ("fbas_03fot1_shoes_00a", "Images/SpriteSheets/Characters/CharacterBase/FarmerSprite/03fot1/fbas_03fot1_shoes_00a"),

                        // 04lwr1
                        ("fbas_04lwr1_longpants_00a", "Images/SpriteSheets/Characters/CharacterBase/FarmerSprite/04lwr1/fbas_04lwr1_longpants_00a"),
                        ("fbas_04lwr1_onepiece_00a", "Images/SpriteSheets/Characters/CharacterBase/FarmerSprite/04lwr1/fbas_04lwr1_onepiece_00a"),
                        ("fbas_04lwr1_onepieceboobs_00a", "Images/SpriteSheets/Characters/CharacterBase/FarmerSprite/04lwr1/fbas_04lwr1_onepieceboobs_00a"),
                        ("fbas_04lwr1_shorts_00a", "Images/SpriteSheets/Characters/CharacterBase/FarmerSprite/04lwr1/fbas_04lwr1_shorts_00a"),
                        ("fbas_04lwr1_undies_00a", "Images/SpriteSheets/Characters/CharacterBase/FarmerSprite/04lwr1/fbas_04lwr1_undies_00a"),

                        // 05shrt
                        ("fbas_05shrt_bra_00a", "Images/SpriteSheets/Characters/CharacterBase/FarmerSprite/05shrt/fbas_05shrt_bra_00a"),
                        ("fbas_05shrt_longshirt_00a", "Images/SpriteSheets/Characters/CharacterBase/FarmerSprite/05shrt/fbas_05shrt_longshirt_00a"),
                        ("fbas_05shrt_longshirtboobs_00a", "Images/SpriteSheets/Characters/CharacterBase/FarmerSprite/05shrt/fbas_05shrt_longshirtboobs_00a"),
                        ("fbas_05shrt_shortshirt_00a", "Images/SpriteSheets/Characters/CharacterBase/FarmerSprite/05shrt/fbas_05shrt_shortshirt_00a"),
                        ("fbas_05shrt_shortshirtboobs_00a", "Images/SpriteSheets/Characters/CharacterBase/FarmerSprite/05shrt/fbas_05shrt_shortshirtboobs_00a"),
                        ("fbas_05shrt_tanktop_00a", "Images/SpriteSheets/Characters/CharacterBase/FarmerSprite/05shrt/fbas_05shrt_tanktop_00a"),
                        ("fbas_05shrt_tanktopboobs_00a", "Images/SpriteSheets/Characters/CharacterBase/FarmerSprite/05shrt/fbas_05shrt_tanktopboobs_00a"),

                        // 06lwr2
                        ("fbas_06lwr2_overalls_00a", "Images/SpriteSheets/Characters/CharacterBase/FarmerSprite/06lwr2/fbas_06lwr2_overalls_00a"),
                        ("fbas_06lwr2_overallsboobs_00a", "Images/SpriteSheets/Characters/CharacterBase/FarmerSprite/06lwr2/fbas_06lwr2_overallsboobs_00a"),
                        ("fbas_06lwr2_shortalls_00a", "Images/SpriteSheets/Characters/CharacterBase/FarmerSprite/06lwr2/fbas_06lwr2_shortalls_00a"),
                        ("fbas_06lwr2_shortallsboobs_00a", "Images/SpriteSheets/Characters/CharacterBase/FarmerSprite/06lwr2/fbas_06lwr2_shortallsboobs_00a"),

                        // 07fot2
                        ("fbas_07fot2_cuffedboots_00a", "Images/SpriteSheets/Characters/CharacterBase/FarmerSprite/07fot2/fbas_07fot2_cuffedboots_00a"),
                        ("fbas_07fot2_curlytoeshoes_00a", "Images/SpriteSheets/Characters/CharacterBase/FarmerSprite/07fot2/fbas_07fot2_curlytoeshoes_00a"),

                        // 08lwr3
                        ("fbas_08lwr3_frillydress_00a", "Images/SpriteSheets/Characters/CharacterBase/FarmerSprite/08lwr3/fbas_08lwr3_frillydress_00a"),
                        ("fbas_08lwr3_frillydressboobs_00a", "Images/SpriteSheets/Characters/CharacterBase/FarmerSprite/08lwr3/fbas_08lwr3_frillydressboobs_00a"),
                        ("fbas_08lwr3_frillyskirt_00a", "Images/SpriteSheets/Characters/CharacterBase/FarmerSprite/08lwr3/fbas_08lwr3_frillyskirt_00a"),
                        ("fbas_08lwr3_longdress_00a", "Images/SpriteSheets/Characters/CharacterBase/FarmerSprite/08lwr3/fbas_08lwr3_longdress_00a"),
                        ("fbas_08lwr3_longdressboobs_00a", "Images/SpriteSheets/Characters/CharacterBase/FarmerSprite/08lwr3/fbas_08lwr3_longdressboobs_00a"),
                        ("fbas_08lwr3_longskirt_00a", "Images/SpriteSheets/Characters/CharacterBase/FarmerSprite/08lwr3/fbas_08lwr3_longskirt_00a"),

                        // 09hand
                        ("fbas_09hand_gloves_00a", "Images/SpriteSheets/Characters/CharacterBase/FarmerSprite/09hand/fbas_09hand_gloves_00a"),

                        // 10outr
                        ("fbas_10outr_suspenders_00a", "Images/SpriteSheets/Characters/CharacterBase/FarmerSprite/10outr/fbas_10outr_suspenders_00a"),

                        // 11neck
                        ("fbas_11neck_cloakplain_00d", "Images/SpriteSheets/Characters/CharacterBase/FarmerSprite/11neck/fbas_11neck_cloakplain_00d"),
                        ("fbas_11neck_scarf_00b", "Images/SpriteSheets/Characters/CharacterBase/FarmerSprite/11neck/fbas_11neck_scarf_00b"),

                        // 12face
                        ("fbas_12face_glasses_00a", "Images/SpriteSheets/Characters/CharacterBase/FarmerSprite/12face/fbas_12face_glasses_00a"),
                        ("fbas_12face_shades_00a", "Images/SpriteSheets/Characters/CharacterBase/FarmerSprite/12face/fbas_12face_shades_00a"),

                        // 13hair
                        ("fbas_13hair_afro_00", "Images/SpriteSheets/Characters/CharacterBase/FarmerSprite/13hair/fbas_13hair_afro_00"),
                        ("fbas_13hair_afropuffs_00", "Images/SpriteSheets/Characters/CharacterBase/FarmerSprite/13hair/fbas_13hair_afropuffs_00"),
                        ("fbas_13hair_bob1_00", "Images/SpriteSheets/Characters/CharacterBase/FarmerSprite/13hair/fbas_13hair_bob1_00"),
                        ("fbas_13hair_bob2_00", "Images/SpriteSheets/Characters/CharacterBase/FarmerSprite/13hair/fbas_13hair_bob2_00"),
                        ("fbas_13hair_dapper_00", "Images/SpriteSheets/Characters/CharacterBase/FarmerSprite/13hair/fbas_13hair_dapper_00"),
                        ("fbas_13hair_flattop_00", "Images/SpriteSheets/Characters/CharacterBase/FarmerSprite/13hair/fbas_13hair_flattop_00"),
                        ("fbas_13hair_ponytail1_00", "Images/SpriteSheets/Characters/CharacterBase/FarmerSprite/13hair/fbas_13hair_ponytail1_00"),
                        ("fbas_13hair_spiky1_00", "Images/SpriteSheets/Characters/CharacterBase/FarmerSprite/13hair/fbas_13hair_spiky1_00"),
                        ("fbas_13hair_spiky2_00", "Images/SpriteSheets/Characters/CharacterBase/FarmerSprite/13hair/fbas_13hair_spiky2_00"),
                        ("fbas_13hair_twintail_00", "Images/SpriteSheets/Characters/CharacterBase/FarmerSprite/13hair/fbas_13hair_twintail_00"),

                        // 14head
                        ("fbas_14head_bandana_00b_e", "Images/SpriteSheets/Characters/CharacterBase/FarmerSprite/14head/fbas_14head_bandana_00b_e"),
                        ("fbas_14head_boaterhat_00d", "Images/SpriteSheets/Characters/CharacterBase/FarmerSprite/14head/fbas_14head_boaterhat_00d"),
                        ("fbas_14head_boaterhat_01", "Images/SpriteSheets/Characters/CharacterBase/FarmerSprite/14head/fbas_14head_boaterhat_01"),
                        ("fbas_14head_cowboyhat_00d", "Images/SpriteSheets/Characters/CharacterBase/FarmerSprite/14head/fbas_14head_cowboyhat_00d"),
                        ("fbas_14head_cowboyhat_01", "Images/SpriteSheets/Characters/CharacterBase/FarmerSprite/14head/fbas_14head_cowboyhat_01"),
                        ("fbas_14head_floppyhat_00d", "Images/SpriteSheets/Characters/CharacterBase/FarmerSprite/14head/fbas_14head_floppyhat_00d"),
                        ("fbas_14head_floppyhat_01", "Images/SpriteSheets/Characters/CharacterBase/FarmerSprite/14head/fbas_14head_floppyhat_01"),
                        ("fbas_14head_strawhat_00d", "Images/SpriteSheets/Characters/CharacterBase/FarmerSprite/14head/fbas_14head_strawhat_00d"),
                        ("fbas_14head_strawhat_01", "Images/SpriteSheets/Characters/CharacterBase/FarmerSprite/14head/fbas_14head_strawhat_01"),

                        // 15over
                        /* currently empty */

                        // /* ---- COMBAT CHARACTER ---- */

                        // 0bot
                        ("inpl_v01", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/0bot/lnpl_v01"),
                        ("inpl_v02", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/0bot/lnpl_v02"),
                        ("inpl_v03", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/0bot/lnpl_v03"),
                        ("inpl_v04", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/0bot/lnpl_v04"),
                        ("inpl_v05", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/0bot/lnpl_v05"),
                        ("inpl_v06", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/0bot/lnpl_v06"),
                        ("inpl_v07", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/0bot/lnpl_v07"),
                        ("inpl_v08", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/0bot/lnpl_v08"),
                        ("inpl_v09", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/0bot/lnpl_v09"),
                        ("inpl_v10", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/0bot/lnpl_v10"),

                        // 1out
                        ("alch_v01", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/1out/alch_v01"),
                        ("alch_v02", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/1out/alch_v02"),
                        ("alch_v03", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/1out/alch_v03"),
                        ("alch_v04", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/1out/alch_v04"),
                        ("alch_v05", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/1out/alch_v05"),

                        ("angl_v01", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/1out/angl_v01"),
                        ("angl_v02", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/1out/angl_v02"),
                        ("angl_v03", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/1out/angl_v03"),
                        ("angl_v04", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/1out/angl_v04"),
                        ("angl_v05", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/1out/angl_v05"),

                        ("bksm_v01", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/1out/bksm_v01"),
                        ("bksm_v02", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/1out/bksm_v02"),
                        ("bksm_v03", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/1out/bksm_v03"),
                        ("bksm_v04", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/1out/bksm_v04"),
                        ("bksm_v05", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/1out/bksm_v05"),

                        ("boxr_v01", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/1out/boxr_v01"),

                        ("fstr_v01", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/1out/fstr_v01"),
                        ("fstr_v02", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/1out/fstr_v02"),
                        ("fstr_v03", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/1out/fstr_v03"),
                        ("fstr_v04", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/1out/fstr_v04"),
                        ("fstr_v05", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/1out/fstr_v05"),

                        ("pfdr_v01", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/1out/pfdr_v01"),
                        ("pfdr_v02", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/1out/pfdr_v02"),
                        ("pfdr_v03", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/1out/pfdr_v03"),
                        ("pfdr_v04", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/1out/pfdr_v04"),
                        ("pfdr_v05", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/1out/pfdr_v05"),

                        ("pfpn_v01", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/1out/pfpn_v01"),
                        ("pfpn_v02", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/1out/pfpn_v02"),
                        ("pfpn_v03", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/1out/pfpn_v03"),
                        ("pfpn_v04", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/1out/pfpn_v04"),
                        ("pfpn_v05", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/1out/pfpn_v05"),

                        ("undi_v01", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/1out/undi_v01"),

                        // 2clo
                        ("lnpl_v01", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/2clo/lnpl_v01"),
                        ("lnpl_v02", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/2clo/lnpl_v02"),
                        ("lnpl_v03", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/2clo/lnpl_v03"),
                        ("lnpl_v04", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/2clo/lnpl_v04"),
                        ("lnpl_v05", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/2clo/lnpl_v05"),
                        ("lnpl_v06", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/2clo/lnpl_v06"),
                        ("lnpl_v07", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/2clo/lnpl_v07"),
                        ("lnpl_v08", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/2clo/lnpl_v08"),
                        ("lnpl_v09", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/2clo/lnpl_v09"),
                        ("lnpl_v10", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/2clo/lnpl_v10"),

                        ("mnpl_v01", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/2clo/mnpl_v01"),
                        ("mnpl_v02", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/2clo/mnpl_v02"),
                        ("mnpl_v03", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/2clo/mnpl_v03"),
                        ("mnpl_v04", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/2clo/mnpl_v04"),
                        ("mnpl_v05", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/2clo/mnpl_v05"),
                        ("mnpl_v06", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/2clo/mnpl_v06"),
                        ("mnpl_v07", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/2clo/mnpl_v07"),
                        ("mnpl_v08", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/2clo/mnpl_v08"),
                        ("mnpl_v09", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/2clo/mnpl_v09"),
                        ("mnpl_v10", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/2clo/mnpl_v10"),

                        // 3fac
                        ("gogl_v01", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/3fac/gogl_v01"),
                        ("gogl_v02", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/3fac/gogl_v02"),
                        ("gogl_v03", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/3fac/gogl_v03"),
                        ("gogl_v04", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/3fac/gogl_v04"),
                        ("gogl_v05", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/3fac/gogl_v05"),

                        // 4har
                        ("bob1_v01", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/bob1_v01"),
                        ("bob1_v02", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/bob1_v02"),
                        ("bob1_v03", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/bob1_v03"),
                        ("bob1_v04", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/bob1_v04"),
                        ("bob1_v05", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/bob1_v05"),
                        ("bob1_v06", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/bob1_v06"),
                        ("bob1_v07", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/bob1_v07"),
                        ("bob1_v08", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/bob1_v08"),
                        ("bob1_v09", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/bob1_v09"),
                        ("bob1_v10", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/bob1_v10"),
                        ("bob1_v11", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/bob1_v11"),
                        ("bob1_v12", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/bob1_v12"),
                        ("bob1_v13", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/bob1_v13"),

                        ("bob2_v01", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/bob2_v01"),
                        ("bob2_v02", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/bob2_v02"),
                        ("bob2_v03", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/bob2_v03"),
                        ("bob2_v04", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/bob2_v04"),
                        ("bob2_v05", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/bob2_v05"),
                        ("bob2_v06", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/bob2_v06"),
                        ("bob2_v07", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/bob2_v07"),
                        ("bob2_v08", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/bob2_v08"),
                        ("bob2_v09", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/bob2_v09"),
                        ("bob2_v10", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/bob2_v10"),
                        ("bob2_v11", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/bob2_v11"),
                        ("bob2_v12", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/bob2_v12"),
                        ("bob2_v13", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/bob2_v13"),

                        ("dap1_v01", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/dap1_v01"),
                        ("dap1_v02", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/dap1_v02"),
                        ("dap1_v03", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/dap1_v03"),
                        ("dap1_v04", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/dap1_v04"),
                        ("dap1_v05", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/dap1_v05"),
                        ("dap1_v06", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/dap1_v06"),
                        ("dap1_v07", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/dap1_v07"),
                        ("dap1_v08", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/dap1_v08"),
                        ("dap1_v09", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/dap1_v09"),
                        ("dap1_v10", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/dap1_v10"),
                        ("dap1_v11", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/dap1_v11"),
                        ("dap1_v12", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/dap1_v12"),
                        ("dap1_v13", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/dap1_v13"),

                        ("flat_v01", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/flat_v01"),
                        ("flat_v02", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/flat_v02"),
                        ("flat_v03", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/flat_v03"),
                        ("flat_v04", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/flat_v04"),
                        ("flat_v05", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/flat_v05"),
                        ("flat_v06", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/flat_v06"),
                        ("flat_v07", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/flat_v07"),
                        ("flat_v08", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/flat_v08"),
                        ("flat_v09", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/flat_v09"),
                        ("flat_v10", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/flat_v10"),
                        ("flat_v11", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/flat_v11"),
                        ("flat_v12", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/flat_v12"),
                        ("flat_v13", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/flat_v13"),

                        ("fro1_v01", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/fro1_v01"),
                        ("fro1_v02", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/fro1_v02"),
                        ("fro1_v03", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/fro1_v03"),
                        ("fro1_v04", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/fro1_v04"),
                        ("fro1_v05", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/fro1_v05"),
                        ("fro1_v06", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/fro1_v06"),
                        ("fro1_v07", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/fro1_v07"),
                        ("fro1_v08", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/fro1_v08"),
                        ("fro1_v09", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/fro1_v09"),
                        ("fro1_v10", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/fro1_v10"),
                        ("fro1_v11", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/fro1_v11"),
                        ("fro1_v12", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/fro1_v12"),
                        ("fro1_v13", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/fro1_v13"),

                        ("pon1_v01", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/pon1_v01"),
                        ("pon1_v02", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/pon1_v02"),
                        ("pon1_v03", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/pon1_v03"),
                        ("pon1_v04", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/pon1_v04"),
                        ("pon1_v05", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/pon1_v05"),
                        ("pon1_v06", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/pon1_v06"),
                        ("pon1_v07", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/pon1_v07"),
                        ("pon1_v08", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/pon1_v08"),
                        ("pon1_v09", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/pon1_v09"),
                        ("pon1_v10", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/pon1_v10"),
                        ("pon1_v11a", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/pon1_v11a"),
                        ("pon1_v11b", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/pon1_v11b"),
                        ("pon1_v12", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/pon1_v12"),
                        ("pon1_v13", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/pon1_v13"),

                        ("spk2_v01", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/spk2_v01"),
                        ("spk2_v02", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/spk2_v02"),
                        ("spk2_v03", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/spk2_v03"),
                        ("spk2_v04", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/spk2_v04"),
                        ("spk2_v05", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/spk2_v05"),
                        ("spk2_v06", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/spk2_v06"),
                        ("spk2_v07", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/spk2_v07"),
                        ("spk2_v08", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/spk2_v08"),
                        ("spk2_v09", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/spk2_v09"),
                        ("spk2_v10", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/spk2_v10"),
                        ("spk2_v11", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/spk2_v11"),
                        ("spk2_v12", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/spk2_v12"),
                        ("spk2_v13", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/4har/spk2_v13"),

                        // 5hat
                        ("band_v01", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/5hat/band_v01"),
                        ("band_v02", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/5hat/band_v02"),
                        ("band_v03", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/5hat/band_v03"),
                        ("band_v04", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/5hat/band_v04"),
                        ("band_v05", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/5hat/band_v05"),

                        ("hddn_v01", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/5hat/hddn_v01"),
                        ("hddn_v02", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/5hat/hddn_v02"),
                        ("hddn_v03", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/5hat/hddn_v03"),
                        ("hddn_v04", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/5hat/hddn_v04"),
                        ("hddn_v05", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/5hat/hddn_v05"),
                        ("hddn_v06", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/5hat/hddn_v06"),
                        ("hddn_v07", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/5hat/hddn_v07"),
                        ("hddn_v08", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/5hat/hddn_v08"),
                        ("hddn_v09", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/5hat/hddn_v09"),
                        ("hddn_v10", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/5hat/hddn_v10"),

                        ("hdpl_v01", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/5hat/hdpl_v01"),
                        ("hdpl_v02", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/5hat/hdpl_v02"),
                        ("hdpl_v03", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/5hat/hdpl_v03"),
                        ("hdpl_v04", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/5hat/hdpl_v04"),
                        ("hdpl_v05", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/5hat/hdpl_v05"),
                        ("hdpl_v06", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/5hat/hdpl_v06"),
                        ("hdpl_v07", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/5hat/hdpl_v07"),
                        ("hdpl_v08", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/5hat/hdpl_v08"),
                        ("hdpl_v09", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/5hat/hdpl_v09"),
                        ("hdpl_v10", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/5hat/hdpl_v10"),

                        ("pfbn_v01", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/5hat/pfbn_v01"),
                        ("pfbn_v02", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/5hat/pfbn_v02"),
                        ("pfbn_v03", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/5hat/pfbn_v03"),
                        ("pfbn_v04", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/5hat/pfbn_v04"),
                        ("pfbn_v05", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/5hat/pfbn_v05"),

                        ("pfht_v01", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/5hat/pfht_v01"),
                        ("pfht_v02", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/5hat/pfht_v02"),
                        ("pfht_v03", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/5hat/pfht_v03"),
                        ("pfht_v04", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/5hat/pfht_v04"),
                        ("pfht_v05", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/5hat/pfht_v05"),

                        ("pnty_v01", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/5hat/pnty_v01"),
                        ("pnty_v02", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/5hat/pnty_v02"),
                        ("pnty_v03", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/5hat/pnty_v03"),
                        ("pnty_v04", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/5hat/pnty_v04"),
                        ("pnty_v05", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/5hat/pnty_v05"),

                        ("rnht_v01", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/5hat/rnht_v01"),
                        ("rnht_v02", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/5hat/rnht_v02"),
                        ("rnht_v03", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/5hat/rnht_v03"),
                        ("rnht_v04", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/5hat/rnht_v04"),
                        ("rnht_v05", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/5hat/rnht_v05"),

                        // 6tla
                        ("ax01_v01", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/6tla/ax01_v01"),
                        ("ax01_v02", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/6tla/ax01_v02"),
                        ("ax01_v03", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/6tla/ax01_v03"),
                        ("ax01_v04", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/6tla/ax01_v04"),
                        ("ax01_v05", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/6tla/ax01_v05"),

                        ("bo01_v01", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/6tla/bo01_v01"),
                        ("bo01_v02", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/6tla/bo01_v02"),
                        ("bo01_v03", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/6tla/bo01_v03"),
                        ("bo01_v04", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/6tla/bo01_v04"),
                        ("bo01_v05", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/6tla/bo01_v05"),

                        ("bo02_v01", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/6tla/bo02_v01"),
                        ("bo02_v02", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/6tla/bo02_v02"),
                        ("bo02_v03", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/6tla/bo02_v03"),
                        ("bo02_v04", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/6tla/bo02_v04"),
                        ("bo02_v05", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/6tla/bo02_v05"),

                        ("bo03_v01", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/6tla/bo03_v01"),
                        ("bo03_v02", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/6tla/bo03_v02"),
                        ("bo03_v03", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/6tla/bo03_v03"),
                        ("bo03_v04", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/6tla/bo03_v04"),
                        ("bo03_v05", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/6tla/bo03_v05"),

                        ("hb01_v01", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/6tla/hb01_v01"),
                        ("hb01_v02", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/6tla/hb01_v02"),
                        ("hb01_v03", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/6tla/hb01_v03"),
                        ("hb01_v04", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/6tla/hb01_v04"),
                        ("hb01_v05", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/6tla/hb01_v05"),

                        ("mc01_v01", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/6tla/mc01_v01"),
                        ("mc01_v02", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/6tla/mc01_v02"),
                        ("mc01_v03", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/6tla/mc01_v03"),
                        ("mc01_v04", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/6tla/mc01_v04"),
                        ("mc01_v05", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/6tla/mc01_v05"),

                        ("mine_v01", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/6tla/mine_v01"),
                        ("roda_v01", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/6tla/roda_v01"),
                        ("smth_v01", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/6tla/smth_v01"),

                        ("sp01_v01", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/6tla/sp01_v01"),
                        ("sp01_v02", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/6tla/sp01_v02"),
                        ("sp01_v03", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/6tla/sp01_v03"),
                        ("sp01_v04", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/6tla/sp01_v04"),
                        ("sp01_v05", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/6tla/sp01_v05"),

                        ("sw01_v01", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/6tla/sw01_v01"),
                        ("sw01_v02", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/6tla/sw01_v02"),
                        ("sw01_v03", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/6tla/sw01_v03"),
                        ("sw01_v04", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/6tla/sw01_v04"),
                        ("sw01_v05", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/6tla/sw01_v05"),

                        ("sw02_v01", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/6tla/sw02_v01"),
                        ("sw02_v02", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/6tla/sw02_v02"),
                        ("sw02_v03", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/6tla/sw02_v03"),
                        ("sw02_v04", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/6tla/sw02_v04"),
                        ("sw02_v05", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/6tla/sw02_v05"),

                        // 7tlb
                        ("qv01_v01", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/7tlb/qv01_v01"),
                        ("qv01_v02", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/7tlb/qv01_v02"),
                        ("qv01_v03", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/7tlb/qv01_v03"),
                        ("qv01_v04", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/7tlb/qv01_v04"),
                        ("qv01_v05", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/7tlb/qv01_v05"),
                        ("qv01_v06", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/7tlb/qv01_v06"),
                        ("qv01_v07", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/7tlb/qv01_v07"),
                        ("qv01_v08", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/7tlb/qv01_v08"),

                        ("sh01_v01", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/7tlb/sh01_v01"),
                        ("sh01_v02", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/7tlb/sh01_v02"),
                        ("sh01_v03", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/7tlb/sh01_v03"),
                        ("sh01_v04", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/7tlb/sh01_v04"),
                        ("sh01_v05", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/7tlb/sh01_v05"),

                        ("sh02_v01", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/7tlb/sh02_v01"),
                        ("sh02_v02", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/7tlb/sh02_v02"),
                        ("sh02_v03", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/7tlb/sh02_v03"),
                        ("sh02_v04", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/7tlb/sh02_v04"),
                        ("sh02_v05", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/7tlb/sh02_v05"),

                        ("sh03_v01", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/7tlb/sh03_v01"),
                        ("sh03_v02", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/7tlb/sh03_v02"),
                        ("sh03_v03", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/7tlb/sh03_v03"),
                        ("sh03_v04", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/7tlb/sh03_v04"),
                        ("sh03_v05", "Images/SpriteSheets/Characters/CharacterBase/CombatSprite/7tlb/sh03_v05")
        }
                },
                {
                    AssetSection.CharacterEffects, new List<(string, string)>
                    {
                        // Base effects.
                        ("baseEffects", "Images/SpriteSheets/Characters/Effects/BaseEffects"),
                        ("fishingEffects64x96v00", "Images/SpriteSheets/Characters/Effects/FishingEffects64x96v00"),
                        ("fishingEffects112x64v00", "Images/SpriteSheets/Characters/Effects/FishingEffects112x64v00"),

                        // Farmer effects.
                        ("farmer1hwpn32x32v00", "Images/SpriteSheets/Characters/Effects/Farmer1hwpn32x32v00"),
                        ("farmer1hwpn32x32v01", "Images/SpriteSheets/Characters/Effects/Farmer1hwpn32x32v01"),
                        ("farmer1hwpn32x32v02", "Images/SpriteSheets/Characters/Effects/Farmer1hwpn32x32v02"),
                        ("farmer1hwpn32x32v03", "Images/SpriteSheets/Characters/Effects/Farmer1hwpn32x32v03"),
                        ("farmerAnimations32x32v00", "Images/SpriteSheets/Characters/Effects/FarmerAnimations32x32v00"),
                        ("farmerAnimations64x64v00", "Images/SpriteSheets/Characters/Effects/FarmerAnimations64x64v00"),
                        ("farmerArrow16x16v00", "Images/SpriteSheets/Characters/Effects/FarmerArrow16x16v00"),
                        ("farmerBow32x32v00", "Images/SpriteSheets/Characters/Effects/FarmerBow32x32v00"),
                        ("farmerBow32x32v01", "Images/SpriteSheets/Characters/Effects/FarmerBow32x32v01"),
                        ("farmerIcons16x16v00", "Images/SpriteSheets/Characters/Effects/FarmerIcons16x16v00"),
                        ("farmerProps32x32v00", "Images/SpriteSheets/Characters/Effects/FarmerProps32x32v00"),
                        ("farmerSlashEffects64x64v00", "Images/SpriteSheets/Characters/Effects/FarmerSlashEffects64x64v00"),
                        ("farmerTool001v00", "Images/SpriteSheets/Characters/Effects/FarmerTool001v00"),
                        ("farmerTool002v00", "Images/SpriteSheets/Characters/Effects/FarmerTool002v00"),
                        ("farmerTool003v00", "Images/SpriteSheets/Characters/Effects/FarmerTool003v00"),
                    }
                },
                {
                    AssetSection.NPC, new List<(string, string)>
                    {
                        // Babies.S
                        ("npcBabyAv00", "Images/SpriteSheets/Characters/NPCs/npcBabyAv00"),
                        ("npcBabyAv01", "Images/SpriteSheets/Characters/NPCs/npcBabyAv01"),
                        ("npcBabyAv02", "Images/SpriteSheets/Characters/NPCs/npcBabyAv02"),
                        ("npcBabyAv03", "Images/SpriteSheets/Characters/NPCs/npcBabyAv03"),
                        ("npcBabyAv04", "Images/SpriteSheets/Characters/NPCs/npcBabyAv04"),
                        ("npcBabyBv00", "Images/SpriteSheets/Characters/NPCs/npcBabyBv00"),
                        ("npcBabyBv01", "Images/SpriteSheets/Characters/NPCs/npcBabyBv01"),
                        ("npcBabyBv02", "Images/SpriteSheets/Characters/NPCs/npcBabyBv02"),
                        ("npcBabyBv03", "Images/SpriteSheets/Characters/NPCs/npcBabyBv03"),
                        ("npcBabyBv04", "Images/SpriteSheets/Characters/NPCs/npcBabyBv04"),

                        // Bard.
                        ("npcBardAv00", "Images/SpriteSheets/Characters/NPCs/npcBardAv00"),
                        ("npcBardAv01", "Images/SpriteSheets/Characters/NPCs/npcBardAv01"),
                        ("npcBardAv02", "Images/SpriteSheets/Characters/NPCs/npcBardAv02"),
                        ("npcBardAv03", "Images/SpriteSheets/Characters/NPCs/npcBardAv03"),
                        ("npcBardAv04", "Images/SpriteSheets/Characters/NPCs/npcBardAv04"),
                        ("npcBardBv00", "Images/SpriteSheets/Characters/NPCs/npcBardBv00"),
                        ("npcBardBv01", "Images/SpriteSheets/Characters/NPCs/npcBardBv01"),
                        ("npcBardBv02", "Images/SpriteSheets/Characters/NPCs/npcBardBv02"),
                        ("npcBardBv03", "Images/SpriteSheets/Characters/NPCs/npcBardBv03"),
                        ("npcBardBv04", "Images/SpriteSheets/Characters/NPCs/npcBardBv04"),
                        
                        // Boy.
                        ("npcBoyV00", "Images/SpriteSheets/Characters/NPCs/npcBoyV00"),
                        ("npcBoyV01", "Images/SpriteSheets/Characters/NPCs/npcBoyV01"),
                        ("npcBoyV02", "Images/SpriteSheets/Characters/NPCs/npcBoyV02"),
                        ("npcBoyV03", "Images/SpriteSheets/Characters/NPCs/npcBoyV03"),
                        ("npcBoyV04", "Images/SpriteSheets/Characters/NPCs/npcBoyV04"),
                        
                        // Cat.
                        ("npcCatV00", "Images/SpriteSheets/Characters/NPCs/npcCatV00"),
                        ("npcCatV01", "Images/SpriteSheets/Characters/NPCs/npcCatV01"),
                        ("npcCatV02", "Images/SpriteSheets/Characters/NPCs/npcCatV02"),
                        ("npcCatV03", "Images/SpriteSheets/Characters/NPCs/npcCatV03"),
                        ("npcCatV04", "Images/SpriteSheets/Characters/NPCs/npcCatV04"),

                        // Chef.
                        ("npcChefV00", "Images/SpriteSheets/Characters/NPCs/npcChefV00"),
                        ("npcChefV01", "Images/SpriteSheets/Characters/NPCs/npcChefV01"),
                        ("npcChefV02", "Images/SpriteSheets/Characters/NPCs/npcChefV02"),
                        ("npcChefV03", "Images/SpriteSheets/Characters/NPCs/npcChefV03"),
                        ("npcChefV04", "Images/SpriteSheets/Characters/NPCs/npcChefV04"),

                        // Dancer.
                        ("npcDancerAv00", "Images/SpriteSheets/Characters/NPCs/npcDancerAv00"),
                        ("npcDancerAv01", "Images/SpriteSheets/Characters/NPCs/npcDancerAv01"),
                        ("npcDancerAv02", "Images/SpriteSheets/Characters/NPCs/npcDancerAv02"),
                        ("npcDancerAv03", "Images/SpriteSheets/Characters/NPCs/npcDancerAv03"),
                        ("npcDancerAv04", "Images/SpriteSheets/Characters/NPCs/npcDancerAv04"),
                        ("npcDancerBv00", "Images/SpriteSheets/Characters/NPCs/npcDancerBv00"),
                        ("npcDancerBv01", "Images/SpriteSheets/Characters/NPCs/npcDancerBv01"),
                        ("npcDancerBv02", "Images/SpriteSheets/Characters/NPCs/npcDancerBv02"),
                        ("npcDancerBv03", "Images/SpriteSheets/Characters/NPCs/npcDancerBv03"),
                        ("npcDancerBv04", "Images/SpriteSheets/Characters/NPCs/npcDancerBv04"),

                        // Dandy.
                        ("npcDandyV00", "Images/SpriteSheets/Characters/NPCs/npcDandyV00"),
                        ("npcDandyV01", "Images/SpriteSheets/Characters/NPCs/npcDandyV01"),
                        ("npcDandyV02", "Images/SpriteSheets/Characters/NPCs/npcDandyV02"),
                        ("npcDandyV03", "Images/SpriteSheets/Characters/NPCs/npcDandyV03"),
                        ("npcDandyV04", "Images/SpriteSheets/Characters/NPCs/npcDandyV04"),

                        // Dog.
                        ("npcDogV00", "Images/SpriteSheets/Characters/NPCs/npcDogV00"),
                        ("npcDogV01", "Images/SpriteSheets/Characters/NPCs/npcDogV01"),
                        ("npcDogV02", "Images/SpriteSheets/Characters/NPCs/npcDogV02"),
                        ("npcDogV03", "Images/SpriteSheets/Characters/NPCs/npcDogV03"),
                        ("npcDogV04", "Images/SpriteSheets/Characters/NPCs/npcDogV04"),

                        // Girl.
                        ("npcGirlV00", "Images/SpriteSheets/Characters/NPCs/npcGirlV00"),
                        ("npcGirlV01", "Images/SpriteSheets/Characters/NPCs/npcGirlV01"),
                        ("npcGirlV02", "Images/SpriteSheets/Characters/NPCs/npcGirlV02"),
                        ("npcGirlV03", "Images/SpriteSheets/Characters/NPCs/npcGirlV03"),
                        ("npcGirlV04", "Images/SpriteSheets/Characters/NPCs/npcGirlV04"),

                        // Guard.
                        ("npcGuardV00", "Images/SpriteSheets/Characters/NPCs/npcGuardV00"),
                        ("npcGuardV01", "Images/SpriteSheets/Characters/NPCs/npcGuardV01"),
                        ("npcGuardV02", "Images/SpriteSheets/Characters/NPCs/npcGuardV02"),
                        ("npcGuardV03", "Images/SpriteSheets/Characters/NPCs/npcGuardV03"),
                        ("npcGuardV04", "Images/SpriteSheets/Characters/NPCs/npcGuardV04"),
                        ("npcGuardV05", "Images/SpriteSheets/Characters/NPCs/npcGuardV05"),
                        ("npcGuardV06", "Images/SpriteSheets/Characters/NPCs/npcGuardV06"),
                        
                        // King.
                        ("npcKingAv00", "Images/SpriteSheets/Characters/NPCs/npcKingAv00"),
                        ("npcKingAv01", "Images/SpriteSheets/Characters/NPCs/npcKingAv01"),
                        ("npcKingAv02", "Images/SpriteSheets/Characters/NPCs/npcKingAv02"),
                        ("npcKingAv03", "Images/SpriteSheets/Characters/NPCs/npcKingAv03"),
                        ("npcKingAv04", "Images/SpriteSheets/Characters/NPCs/npcKingAv04"),
    
                        // knight.
                        ("npcKnightV00", "Images/SpriteSheets/Characters/NPCs/npcKnightV00"),
                        ("npcKnightV01", "Images/SpriteSheets/Characters/NPCs/npcKnightV01"),
                        ("npcKnightV02", "Images/SpriteSheets/Characters/NPCs/npcKnightV02"),
                        ("npcKnightV03", "Images/SpriteSheets/Characters/NPCs/npcKnightV03"),
                        ("npcKnightV04", "Images/SpriteSheets/Characters/NPCs/npcKnightV04"),
                        ("npcKnightV05", "Images/SpriteSheets/Characters/NPCs/npcKnightV05"),
                        ("npcKnightV06", "Images/SpriteSheets/Characters/NPCs/npcKnightV06"),

                        // Man.
                        ("npcManAv00", "Images/SpriteSheets/Characters/NPCs/npcManAv00"),
                        ("npcManAv01", "Images/SpriteSheets/Characters/NPCs/npcManAv01"),
                        ("npcManAv02", "Images/SpriteSheets/Characters/NPCs/npcManAv02"),
                        ("npcManAv03", "Images/SpriteSheets/Characters/NPCs/npcManAv03"),
                        ("npcManAv04", "Images/SpriteSheets/Characters/NPCs/npcManAv04"),
                        ("npcManBv00", "Images/SpriteSheets/Characters/NPCs/npcManBv00"),
                        ("npcManBv01", "Images/SpriteSheets/Characters/NPCs/npcManBv01"),
                        ("npcManBv02", "Images/SpriteSheets/Characters/NPCs/npcManBv02"),
                        ("npcManBv03", "Images/SpriteSheets/Characters/NPCs/npcManBv03"),
                        ("npcManBv04", "Images/SpriteSheets/Characters/NPCs/npcManBv04"),

                        // Merchant.
                        ("npcMerchantAv00", "Images/SpriteSheets/Characters/NPCs/npcMerchantAv00"),
                        ("npcMerchantAv01", "Images/SpriteSheets/Characters/NPCs/npcMerchantAv01"),
                        ("npcMerchantAv02", "Images/SpriteSheets/Characters/NPCs/npcMerchantAv02"),
                        ("npcMerchantBv00", "Images/SpriteSheets/Characters/NPCs/npcMerchantBv00"),
                        ("npcMerchantBv01", "Images/SpriteSheets/Characters/NPCs/npcMerchantBv01"),
                        ("npcMerchantBv02", "Images/SpriteSheets/Characters/NPCs/npcMerchantBv02"),
                        ("npcMerchantBv03", "Images/SpriteSheets/Characters/NPCs/npcMerchantBv03"),
                        ("npcMerchantCv00", "Images/SpriteSheets/Characters/NPCs/npcMerchantCv00"),
                        ("npcMerchantCv01", "Images/SpriteSheets/Characters/NPCs/npcMerchantCv01"),
                        ("npcMerchantCv02", "Images/SpriteSheets/Characters/NPCs/npcMerchantCv02"),
                        ("npcMerchantCv03", "Images/SpriteSheets/Characters/NPCs/npcMerchantCv03"),
                        ("npcMerchantDv00", "Images/SpriteSheets/Characters/NPCs/npcMerchantDv00"),
                        ("npcMerchantDv01", "Images/SpriteSheets/Characters/NPCs/npcMerchantDv01"),
                        ("npcMerchantDv02", "Images/SpriteSheets/Characters/NPCs/npcMerchantDv02"),
                        ("npcMerchantDv03", "Images/SpriteSheets/Characters/NPCs/npcMerchantDv03"),

                        // Mystic.
                        ("npcMysticAv00", "Images/SpriteSheets/Characters/NPCs/npcMysticAv00"),
                        ("npcMysticAv01", "Images/SpriteSheets/Characters/NPCs/npcMysticAv01"),
                        ("npcMysticAv02", "Images/SpriteSheets/Characters/NPCs/npcMysticAv02"),
                        ("npcMysticAv03", "Images/SpriteSheets/Characters/NPCs/npcMysticAv03"),

                        // Nun.
                        ("npcNunV00", "Images/SpriteSheets/Characters/NPCs/npcNunV00"),
                        ("npcNunV01", "Images/SpriteSheets/Characters/NPCs/npcNunV01"),
                        ("npcNunV02", "Images/SpriteSheets/Characters/NPCs/npcNunV02"),
                        ("npcNunV03", "Images/SpriteSheets/Characters/NPCs/npcNunV03"),
                        ("npcNunV04", "Images/SpriteSheets/Characters/NPCs/npcNunV04"),

                        // Old man.
                        ("npcOldManAv00", "Images/SpriteSheets/Characters/NPCs/npcOldManAv00"),
                        ("npcOldManAv01", "Images/SpriteSheets/Characters/NPCs/npcOldManAv01"),
                        ("npcOldManAv02", "Images/SpriteSheets/Characters/NPCs/npcOldManAv02"),
                        ("npcOldManAv03", "Images/SpriteSheets/Characters/NPCs/npcOldManAv03"),
                        ("npcOldManAv04", "Images/SpriteSheets/Characters/NPCs/npcOldManAv04"),
                        ("npcOldManBv00", "Images/SpriteSheets/Characters/NPCs/npcOldManBv00"),
                        ("npcOldManBv01", "Images/SpriteSheets/Characters/NPCs/npcOldManBv01"),
                        ("npcOldManBv02", "Images/SpriteSheets/Characters/NPCs/npcOldManBv02"),
                        ("npcOldManBv03", "Images/SpriteSheets/Characters/NPCs/npcOldManBv03"),
                        ("npcOldManBv04", "Images/SpriteSheets/Characters/NPCs/npcOldManBv04"),

                        // Old woman.
                        ("npcOldWomanAv00", "Images/SpriteSheets/Characters/NPCs/npcOldWomanAv00"),
                        ("npcOldWomanAv01", "Images/SpriteSheets/Characters/NPCs/npcOldWomanAv01"),
                        ("npcOldWomanAv02", "Images/SpriteSheets/Characters/NPCs/npcOldWomanAv02"),
                        ("npcOldWomanAv03", "Images/SpriteSheets/Characters/NPCs/npcOldWomanAv03"),
                        ("npcOldWomanAv04", "Images/SpriteSheets/Characters/NPCs/npcOldWomanAv04"),
                        ("npcOldWomanBv00", "Images/SpriteSheets/Characters/NPCs/npcOldWomanBv00"),
                        ("npcOldWomanBv01", "Images/SpriteSheets/Characters/NPCs/npcOldWomanBv01"),
                        ("npcOldWomanBv02", "Images/SpriteSheets/Characters/NPCs/npcOldWomanBv02"),
                        ("npcOldWomanBv03", "Images/SpriteSheets/Characters/NPCs/npcOldWomanBv03"),
                        ("npcOldWomanBv04", "Images/SpriteSheets/Characters/NPCs/npcOldWomanBv04"),
                        ("npcOldWomanCv00", "Images/SpriteSheets/Characters/NPCs/npcOldWomanCv00"),
                        ("npcOldWomanCv01", "Images/SpriteSheets/Characters/NPCs/npcOldWomanCv01"),
                        ("npcOldWomanCv02", "Images/SpriteSheets/Characters/NPCs/npcOldWomanCv02"),
                        ("npcOldWomanCv03", "Images/SpriteSheets/Characters/NPCs/npcOldWomanCv03"),
                        ("npcOldWomanCv04", "Images/SpriteSheets/Characters/NPCs/npcOldWomanCv04"),

                        // Queen.
                        ("npcQueenAv00", "Images/SpriteSheets/Characters/NPCs/npcQueenAv00"),
                        ("npcQueenAv01", "Images/SpriteSheets/Characters/NPCs/npcQueenAv01"),
                        ("npcQueenAv02", "Images/SpriteSheets/Characters/NPCs/npcQueenAv02"),
                        ("npcQueenAv03", "Images/SpriteSheets/Characters/NPCs/npcQueenAv03"),
                        ("npcQueenAv04", "Images/SpriteSheets/Characters/NPCs/npcQueenAv04"),

                        // Woman.
                        ("npcWomanAv00", "Images/SpriteSheets/Characters/NPCs/npcWomanAv00"),
                        ("npcWomanAv01", "Images/SpriteSheets/Characters/NPCs/npcWomanAv01"),
                        ("npcWomanAv02", "Images/SpriteSheets/Characters/NPCs/npcWomanAv02"),
                        ("npcWomanAv03", "Images/SpriteSheets/Characters/NPCs/npcWomanAv03"),
                        ("npcWomanAv04", "Images/SpriteSheets/Characters/NPCs/npcWomanAv04"),
                        ("npcWomanBv00", "Images/SpriteSheets/Characters/NPCs/npcWomanBv00"),
                        ("npcWomanBv01", "Images/SpriteSheets/Characters/NPCs/npcWomanBv01"),
                        ("npcWomanBv02", "Images/SpriteSheets/Characters/NPCs/npcWomanBv02"),
                        ("npcWomanBv03", "Images/SpriteSheets/Characters/NPCs/npcWomanBv03"),
                        ("npcWomanBv04", "Images/SpriteSheets/Characters/NPCs/npcWomanBv04"),
                    }
                },
                {
                    AssetSection.PaletteSwap, new List<(string, string)>
                    {
                        // Ramp variants.
                        ("manaSeedCommonRamps3", "Images/SpriteSheets/Characters/PaletteSwap/ManaSeedCommonRamps3"),
                        ("manaSeedCommonRamps4", "Images/SpriteSheets/Characters/PaletteSwap/ManaSeedCommonRamps4"),
                        ("manaSeedRareRamps3", "Images/SpriteSheets/Characters/PaletteSwap/ManaSeedRareRamps3"),
                        ("manaSeedRareRamps4", "Images/SpriteSheets/Characters/PaletteSwap/ManaSeedRareRamps4"),
                        ("manaSeedHairRamps", "Images/SpriteSheets/Characters/PaletteSwap/ManaSeedHairRamps"),
                        ("manaSeedSkinRamps", "Images/SpriteSheets/Characters/PaletteSwap/ManaSeedSkinRamps"),
                        ("manaSeedToolRamps", "Images/SpriteSheets/Characters/PaletteSwap/ManaSeedToolRamps"),

                        // Base ramps.
                        ("2x3colorBaseRamp", "Images/SpriteSheets/Characters/PaletteSwap/BaseRamps/2x3ColorBaseRamp"),
                        ("3colorBaseRamp00a", "Images/SpriteSheets/Characters/PaletteSwap/BaseRamps/3ColorBaseRamp00a"),
                        ("4colorBaseRamp00b", "Images/SpriteSheets/Characters/PaletteSwap/BaseRamps/4ColorBaseRamp00b"),
                        ("4colorBaseRamp00d", "Images/SpriteSheets/Characters/PaletteSwap/BaseRamps/4ColorBaseRamp00d"),
                        ("hairColorBaseRamp", "Images/SpriteSheets/Characters/PaletteSwap/BaseRamps/HairColorBaseRamp"),
                        ("instrumentColorBaseRamp", "Images/SpriteSheets/Characters/PaletteSwap/BaseRamps/InstrumentColorBaseRamp"),
                        ("skinColorBaseRamp", "Images/SpriteSheets/Characters/PaletteSwap/BaseRamps/SkinColorBaseRamp"),
                        ("weaponToolBaseRamp", "Images/SpriteSheets/Characters/PaletteSwap/BaseRamps/WeaponToolBaseRamp")
                    }
                },
                {
                    AssetSection.SpriteSheets, new List<(string, string)>
                    { 
                        // SPRITESHEETS:
                        // Alchemy.
                        ("alchemyGear", "Images/SpriteSheets/ALchemyGear/AlchemyGear"),
                        ("alchemyGear16x16", "Images/SpriteSheets/ALchemyGear/AlchemyGear16x16"),
                        ("alchemyGear16x48", "Images/SpriteSheets/ALchemyGear/AlchemyGear16x48"),
                        ("alchemyGear32x32", "Images/SpriteSheets/ALchemyGear/AlchemyGear32x32"),
                        ("alchemyPotions16x16", "Images/SpriteSheets/ALchemyGear/AlchemyPotions16x16"),
                        ("alchemyReagents16x16", "Images/SpriteSheets/ALchemyGear/AlchemyReagents16x16"),
                        ("alchemySymbols16x16", "Images/SpriteSheets/ALchemyGear/AlchemySymbols16x16"),

                        // Farming.
                        ("extras16x16", "Images/SpriteSheets/FarmingCrops/Extras16x16"),
                        ("extras16x32", "Images/SpriteSheets/FarmingCrops/Extras16x32"),
                        ("farmingCrops1A16x32", "Images/SpriteSheets/FarmingCrops/FarmingCrops1A16x32"),
                        ("farmingCrops1B16x32", "Images/SpriteSheets/FarmingCrops/FarmingCrops1B16x32"),
                        ("farmingCrops1C16x32", "Images/SpriteSheets/FarmingCrops/FarmingCrops1C16x32"),
                        ("farmingCrops2A16x32", "Images/SpriteSheets/FarmingCrops/FarmingCrops2A16x32"),
                        ("farmingCrops2B16x32", "Images/SpriteSheets/FarmingCrops/FarmingCrops2B16x32"),

                        ("gaintPumpkin48x48", "Images/SpriteSheets/FarmingCrops/GiantPumpkin48x48"),
                        ("gaintVeggies32x80", "Images/SpriteSheets/FarmingCrops/GiantVeggies32x80"),

                        // Fishing.
                        ("fishingIcons16x16", "Images/SpriteSheets/FishingGear/FishingIcons16x16"),
                        ("fishingObjects16x32", "Images/SpriteSheets/FishingGear/FishingObjects16x32"),
                        ("fishingObjects32x32", "Images/SpriteSheets/FishingGear/FishingObjects32x32"),
                        ("fishingObjects32x48", "Images/SpriteSheets/FishingGear/FishingObjects32x48"),

                        // fishing animations.
                        ("fishingAutumn32x32", "Images/SpriteSheets/FishingGear/FishAnimations/Autumn32x32"),
                        ("fishingSpring32x32", "Images/SpriteSheets/FishingGear/FishAnimations/Spring32x32"),
                        ("fishingSummer32x32", "Images/SpriteSheets/FishingGear/FishAnimations/Summer32x32"),
                        ("fishingWinter32x32", "Images/SpriteSheets/FishingGear/FishAnimations/Winter32x32"),
                        ("fishingMuddyV132x32", "Images/SpriteSheets/FishingGear/FishAnimations/MuddyV1"),
                        ("fishingMuddyV232x32", "Images/SpriteSheets/FishingGear/FishAnimations/MuddyV2"),
                        ("fishingMuddyV332x32", "Images/SpriteSheets/FishingGear/FishAnimations/MuddyV3"),
                        ("fishingMuddyV432x32", "Images/SpriteSheets/FishingGear/FishAnimations/MuddyV4"),

                        // Smithing.
                        ("blacksmithing16x16", "Images/SpriteSheets/SmithingGear/Blacksmithing16x16"),
                        ("blacksmithing16x32", "Images/SpriteSheets/SmithingGear/Blacksmithing16x32"),
                        ("blacksmithing32x16", "Images/SpriteSheets/SmithingGear/Blacksmithing32x16"),
                        ("blacksmithing32x48", "Images/SpriteSheets/SmithingGear/Blacksmithing32x48"),
                        ("blacksmithingForge", "Images/SpriteSheets/SmithingGear/BlacksmithingForge"),
                        ("craftingBlacksmith", "Images/SpriteSheets/SmithingGear/CraftingBlacksmith"),

                        // smithing icons.
                        ("smithingAutumn32x32", "Images/SpriteSheets/SmithingGear/Icons/Autumn"),
                        ("smithingSpring32x32", "Images/SpriteSheets/SmithingGear/Icons/Spring"),
                        ("smithingSummer32x32", "Images/SpriteSheets/SmithingGear/Icons/Summer"),
                        ("smithingWinter32x32", "Images/SpriteSheets/SmithingGear/Icons/Winter"),
                        ("smithingMuddyV132x32", "Images/SpriteSheets/SmithingGear/Icons/MuddyV1"),
                        ("smithingMuddyV232x32", "Images/SpriteSheets/SmithingGear/Icons/MuddyV2"),
                        ("smithingMuddyV332x32", "Images/SpriteSheets/SmithingGear/Icons/MuddyV3"),
                        ("smithingMuddyV432x32", "Images/SpriteSheets/SmithingGear/Icons/MuddyV4"),
                    }
                },
                {
                    AssetSection.TileSheets, new List<(string, string)>
                    { 
                        // ENVIRONMENT:
                        // TODO: re-add environment tiles.

                        // INTERIOR:
                        // Dungeon.
                        ("castleDungeonV01", "Images/TileSheets/Interior/CastleDungeon/CastleDungeonV01"),
                        ("castleDungeonV02", "Images/TileSheets/Interior/CastleDungeon/CastleDungeonV02"),
                        ("castleDungeonV03", "Images/TileSheets/Interior/CastleDungeon/CastleDungeonV03"),

                        // Interior.
                        ("castleInteriors", "Images/TileSheets/Interior/CastleInterior/CastleInteriors"),
                        ("carpetedStair", "Images/TileSheets/Interior/CastleInterior/CarpetedStair"),

                        // Furnishings.
                        ("cozyFurnishings", "Images/TileSheets/Interior/CozyFurnishings/CozyFurnishings"),
                        ("halfTimberInterior", "Images/TileSheets/Interior/CozyFurnishings/HalfTimber"),
                        ("lanternCenterpiece", "Images/TileSheets/Interior/CozyFurnishings/LanternCenterpiece"),

                        // Library.
                        ("emptyBookshelveAv01", "Images/TileSheets/Interior/GrandLibrary/EmptyBookshelveAv01"),
                        ("emptyBookshelveAv02", "Images/TileSheets/Interior/GrandLibrary/EmptyBookshelveAv02"),
                        ("emptyBookshelveBv01", "Images/TileSheets/Interior/GrandLibrary/EmptyBookshelveBv01"),
                        ("emptyBookshelveBv02", "Images/TileSheets/Interior/GrandLibrary/EmptyBookshelveBv02"),
                        ("grandLibraryV01", "Images/TileSheets/Interior/GrandLibrary/GrandLibraryV01"),
                        ("grandLibraryV02", "Images/TileSheets/Interior/GrandLibrary/GrandLibraryV02")
                    }
                },
                {
                    AssetSection.Fonts, new List<(string, string)>
                    { 
                        // Game fonts.
                        ("manaSeedBody", "Fonts/ManaSeedBody"),
                        ("manaSeedHeader", "Fonts/ManaSeedHeader"),
                        ("manaSeedTitle", "Fonts/ManaSeedTitle"),
                        ("manaSeedTitleMono", "Fonts/ManaSeedTitleMono")
                    }
                }
            };
        protected enum AssetSection
        {
            SFX,
            OST,
            LDtk,
            CharacterSheets,
            CharacterEffects,
            NPC,
            PaletteSwap,
            SpriteSheets,
            TileSheets,
            Fonts,
        }

    }
}
