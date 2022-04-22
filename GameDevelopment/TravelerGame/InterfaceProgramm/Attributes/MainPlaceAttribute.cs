
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TravelerGame
{/// <summary>
/// Атрибут, служит для пометки зданий в городах, для выборки через линк по класам его реализующим
/// не содержит реализации.
/// К главным зданиям относятся таверна, магазин, мед центр.
/// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false)] //  Inherited = false, не наследуется в классах наследниках. AttributeTargets.All - может применяться ко всем членам класса и к самому типу 
    internal class MainPlaceAttribute : Attribute
    {
    }
}