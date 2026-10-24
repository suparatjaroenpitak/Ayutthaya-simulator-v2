using System;
using UnityEngine;

namespace AyutthayaSimulator.Narrative
{
    [Serializable] public struct QuestWriting { public string questId; public QuestType type; public LocalizedText title; public LocalizedText summary; }
    [CreateAssetMenu(menuName = "Ayutthaya/Narrative/Quest Writing Pack", fileName = "QuestWritingPack")]
    public sealed class QuestWritingPack : ScriptableObject
    {
        public QuestWriting[] entries =
        {
            new QuestWriting { questId = "main_01_return", type = QuestType.Main, title = new LocalizedText { thai = "กลับบ้านริมเจ้าพระยา", english = "Home by the River" }, summary = new LocalizedText { thai = "สมชายกลับถึงอยุธยาและพบว่านาของครอบครัวต้องการคนดูแล", english = "Somchai returns to Ayutthaya and finds the family farm waiting for someone to care for it." } },
            new QuestWriting { questId = "main_02_first_water", type = QuestType.Main, title = new LocalizedText { thai = "น้ำแรกของนา", english = "The First Water" }, summary = new LocalizedText { thai = "เปิดทางน้ำและเรียนรู้ว่าการฟื้นนาต้องทำร่วมกับคนในชุมชน", english = "Open the water route and learn that restoring the farm is a community effort." } },
            new QuestWriting { questId = "main_03_seed_memory", type = QuestType.Main, title = new LocalizedText { thai = "เมล็ดพันธุ์ของบ้าน", english = "Seeds of Home" }, summary = new LocalizedText { thai = "ตามหาเมล็ดพันธุ์ที่แม่เคยเก็บไว้และตัดสินใจว่าจะปลูกแปลงแรกอย่างไร", english = "Find the seeds your mother kept and decide how to plant the first plot." } },
            new QuestWriting { questId = "main_04_market_morning", type = QuestType.Main, title = new LocalizedText { thai = "เช้าที่ตลาด", english = "Market Morning" }, summary = new LocalizedText { thai = "นำผลผลิตแรกไปตลาดและสร้างความไว้ใจกับผู้ซื้อ", english = "Bring the first harvest to market and build trust with a buyer." } },
            new QuestWriting { questId = "main_05_new_roof", type = QuestType.Main, title = new LocalizedText { thai = "หลังคาใหม่", english = "A New Roof" }, summary = new LocalizedText { thai = "ใช้รายได้ก้อนแรกซ่อมบ้านและยืนยันว่าฟาร์มจะมีอนาคต", english = "Use the first income to repair the house and commit to the farm's future." } },
            new QuestWriting { questId = "side_01_bicycle", type = QuestType.Side, title = new LocalizedText { thai = "จักรยานของนที", english = "Natee's Bicycle" }, summary = new LocalizedText { thai = "ช่วยเด็กข้างบ้านตามหาชิ้นส่วนจักรยานก่อนฝนมา", english = "Help a neighbor find bicycle parts before the rain arrives." } },
            new QuestWriting { questId = "side_02_old_recipe", type = QuestType.Side, title = new LocalizedText { thai = "สูตรในสมุดเก่า", english = "The Old Recipe" }, summary = new LocalizedText { thai = "ทำอาหารตามสูตรที่พบในครัวและแบ่งให้เพื่อนบ้าน", english = "Cook from a recipe found in the kitchen and share it with a neighbor." } },
            new QuestWriting { questId = "side_03_bridge_lanterns", type = QuestType.Side, title = new LocalizedText { thai = "โคมไฟที่สะพาน", english = "Lanterns on the Bridge" }, summary = new LocalizedText { thai = "นำโคมไฟไปแขวนตามทางเดินชุมชน", english = "Carry lanterns to light the community path." } },
            new QuestWriting { questId = "side_04_rice_song", type = QuestType.Side, title = new LocalizedText { thai = "เพลงของชาวนา", english = "The Farmer's Song" }, summary = new LocalizedText { thai = "ฟังเรื่องเล่าจากผู้เฒ่าและบันทึกเพลงเกี่ยวกับฤดูเก็บเกี่ยว", english = "Listen to an elder and record a song about harvest season." } },
            new QuestWriting { questId = "side_05_small_favor", type = QuestType.Side, title = new LocalizedText { thai = "น้ำใจเล็ก ๆ", english = "A Small Favor" }, summary = new LocalizedText { thai = "ช่วยซ่อมรั้วแปลงผักของเพื่อนบ้าน", english = "Repair a neighbor's vegetable-garden fence." } }
        };
    }
}
