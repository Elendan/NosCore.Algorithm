﻿using System;

namespace NosCore.Algorithm.HpService
{
    public class HpService : IHpService
    {
        private readonly double[,] _hpData = new double[Constants.ClassCount, Constants.MaxLevel];

        public HpService()
        {
            // Adventurer HP
            int basicHp = 205;
            int basicInc = 15;
            for (var i = 0; i < Constants.MaxLevel; i++)
            {
                basicInc++;
                basicHp += basicInc;

                _hpData[0, i] = basicHp;
            }

            // Swordsman HP
            int swordHp = 190;
            int swordInc = 14;
            for (var i = 0; i < Constants.MaxLevel; i++)
            {
                bool increase2 = (i - 2) % 10 == 0;
                bool increase3 = (i - 3) % 10 == 0;
                bool increase4 = (i - 4) % 10 == 0;
                bool increase5 = (i - 5) % 10 == 0;
                bool increase7 = (i - 7) % 10 == 0;
                bool increase8 = (i - 8) % 10 == 0;
                bool increase9 = (i - 9) % 10 == 0;

                swordInc++;
                swordHp += swordInc;

                if (increase2 || increase3 || increase4 || increase5 || increase7 || increase8 || increase9 || i % 10 == 0)
                {
                    swordInc++;
                    swordHp += swordInc;
                }

                _hpData[1, i] = swordHp;
            }

            // Magician HP
            for (var i = 0; i < Constants.MaxLevel; i++)
            {
                basicInc++;
                basicHp += basicInc;

                _hpData[3, i] = basicHp;
            }

            // Archer HP
            int archerHp = 190;
            int archerInc = 14;
            for (var i = 0; i < Constants.MaxLevel; i++)
            {
                bool increase4 = (i - 4) % 10 == 0;
                bool increase7 = (i - 7) % 10 == 0;

                archerInc++;
                archerHp += archerInc;

                if (increase4 || increase7 || i % 10 == 0)
                {
                    archerInc++;
                    archerHp += archerInc;
                }

                _hpData[2, i] = archerHp;
            }

            // MartialArtist HP
            int fighterHp = 190;
            int fighterInc = 14;
            for (var i = 0; i < Constants.MaxLevel; i++)
            {
                bool increase2 = (i - 2) % 10 == 0;
                bool increase4 = (i - 4) % 10 == 0;
                bool increase6 = (i - 6) % 10 == 0;
                bool increase7 = (i - 7) % 10 == 0;

                fighterInc++;
                fighterHp += fighterInc;

                if (increase2 || increase4 || increase6 || increase7 || i % 10 == 0)
                {
                    fighterInc++;
                    fighterHp += fighterInc;
                }

                _hpData[4, i] = fighterHp;
            }
        }
        public long GetHp(byte @class, byte level)
        {
            return (long)_hpData![@class, level-1];
        }
    }
}
