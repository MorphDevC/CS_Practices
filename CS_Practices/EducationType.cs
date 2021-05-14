using System;
using System.Collections.Generic;


namespace CS_Practices
{
    public class EducationType
    {
        public readonly List<string> _vectorEducationCode = new List<string>()
        {
            "09.03.02",
            "09.03.03",
            "01.03.02",
            "01.03.04",
            "02.02.02",
            "03.03.03"
        };
        public readonly List<string> _vectorEducationName = new List<string>()
        {
            "Информационные системы и технологии",
            "Прикладная информатика",
            "Прикладная математика и информатика",
            "Прикладная математика",
            "Вымышленная программа 1",
            "Лучшая Вымышленная программа 2"
        };

        public readonly List<List<string>> Disciplines = new List<List<string>>()
        {
            new List<string>()
            {
                "09.03.02 Discipline 1",
                "09.03.02 Discipline 2",
                "09.03.02 Discipline 3",
                "09.03.02 Discipline 4",
                "09.03.02 Discipline 5",
                "09.03.02 Discipline 6",
                "09.03.02 Discipline 7",
                "09.03.02 Discipline 8",
                "09.03.02 Discipline 9",
                "09.03.02 Discipline 10",
                
            },
            new List<string>()
            {
                "09.03.03 Discipline 1",
                "09.03.03 Discipline 2",
                "09.03.03 Discipline 3",
                "09.03.03 Discipline 4",
                "09.03.03 Discipline 5",
                "09.03.03 Discipline 6",
                "09.03.03 Discipline 7",
                "09.03.03 Discipline 8",
                "09.03.03 Discipline 9",
                "09.03.03 Discipline 10",
            },
            new List<string>()
            {
                "01.03.02 Discipline 1",
                "01.03.02 Discipline 2",
                "01.03.02 Discipline 3",
                "01.03.02 Discipline 4",
                "01.03.02 Discipline 5",
                "01.03.02 Discipline 6",
                "01.03.02 Discipline 7",
                "01.03.02 Discipline 8",
                "01.03.02 Discipline 9",
                "01.03.02 Discipline 10",
            },
            new List<string>()
            {
                "01.03.04 Discipline 1",
                "01.03.04 Discipline 2",
                "01.03.04 Discipline 3",
                "01.03.04 Discipline 4",
                "01.03.04 Discipline 5",
                "01.03.04 Discipline 6",
                "01.03.04 Discipline 7",
                "01.03.04 Discipline 8",
                "01.03.04 Discipline 9",
                "01.03.04 Discipline 10",
            },
            new List<string>()
            {
                "02.02.02 Discipline 1",
                "02.02.02 Discipline 2",
                "02.02.02 Discipline 3",
                "02.02.02 Discipline 4",
                "02.02.02 Discipline 5",
                "02.02.02 Discipline 6",
                "02.02.02 Discipline 7",
                "02.02.02 Discipline 8",
                "02.02.02 Discipline 9",
                "02.02.02 Discipline 10",
            },
            new List<string>()
            {
                "03.03.03 Discipline 1",
                "03.03.03 Discipline 2",
                "03.03.03 Discipline 3",
                "03.03.03 Discipline 4",
                "03.03.03 Discipline 5",
                "03.03.03 Discipline 6",
                "03.03.03 Discipline 7",
                "03.03.03 Discipline 8",
                "03.03.03 Discipline 9",
                "03.03.03 Discipline 10",
            },
        };

        public readonly static List<string> VectorEducationLetters = new List<string>()
        {
            "CT",
            "PI",
            "MI",
            "PM",
            "VP",
            "BV"
        };

        
    }
}