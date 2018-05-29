using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelerGame
{
    enum BiomTypes
    {
        //TODO: скорее всего сделать из этого списка, классы наследники от Biom.

        L1forest,
        L2forestDeep,// валежник, плохо проходимый
        L1meadow,
        L1bog, // болото
        L1hill,
        L1rock,
        L1highRock,
        L1cave,
        L2caveDeep, // пройти только с помощью вервки
        L1barrens,
        L1river, // пройти с помощью моста
        L1lake,
        L1nuclearPlace, // место ядерного взрыва
        L1сity,
        L1town,
        L1village,
        L1militaryBase,
        L1militaryCamp,
        L1factory,
        L1storege

    }


}
