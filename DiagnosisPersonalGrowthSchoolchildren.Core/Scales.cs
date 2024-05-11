namespace DiagnosisPersonalGrowthSchoolchildren
{
    internal static class Scales
    {
        /// <summary>
        /// Возвращает информацию для списка вопросов по теме
        /// "Диагностика и мониторинг процесса воспитания в школе / П.В. Степанов, Д.В. Григорьев, И.В.Кулешова"
        /// </summary>
        /// <returns>
        /// Возвращает массив кортежей для списка вопросов.
        /// Первое значение в кортеже означает номер шкалы.
        /// Второе значение в кортеже означает нужно ли менять знак у ответа на данный вопрос или нет.
        /// </returns>
        public static (int, bool)[] GetValues()
        {
            return [
                (1, false),  // 1
                (2, true),   // 2
                (3, true),   // 3
                (4, false),  // 4
                (5, false),  // 5
                (6, true),   // 6
                (7, true),   // 7
                (8, true),   // 8
                (9, true),   // 9
                (10, false), // 10
                (11, false), // 11
                (12, true),  // 12
                (13, false), // 13
                (1, true),   // 14
                (2, false),  // 15
                (3, true),   // 16
                (4, true),   // 17
                (5, true),   // 18
                (6, false),  // 19
                (7, false),  // 20
                (8, true),   // 21
                (9, false),  // 22
                (10, true),   // 23
                (11, true),  // 24
                (12, true),  // 25
                (13, false), // 26
                (1, true),   // 27
                (2, false),  // 28
                (3, false),  // 29
                (4, true),   // 30
                (5, false),  // 31
                (6, false),  // 32
                (7, true),   // 33
                (8, true),   // 34
                (9, false),  // 35
                (10, true),  // 36
                (11, true),  // 37
                (12, true),  // 38
                (13, false), // 39
                (1, false),  // 40
                (2, true),   // 41
                (3, true),   // 42
                (4, true),   // 43
                (5, false),  // 44
                (6, true),   // 45
                (7, true),   // 46
                (8, false),  // 47
                (9, true),   // 48
                (10, true),  // 49
                (11, false), // 50
                (12, true),  // 51
                (13, false), // 52
                (1, true),   // 53
                (2, true),   // 54
                (3, true),   // 55
                (4, true),   // 56
                (5, false),  // 57
                (6, true),   // 58
                (7, false),  // 59
                (8, false),  // 60
                (9, false),  // 61
                (10, true),  // 62
                (11, false), // 63
                (12, true),  // 64
                (13, true),  // 65
                (1, true),   // 66
                (2, false),  // 67
                (3, true),   // 68
                (4, true),   // 69
                (5, true),   // 70
                (6, true),   // 71
                (7, true),   // 72
                (8, false),  // 73
                (9, true),   // 74
                (10, true),  // 75
                (11, true),  // 76
                (12, false), // 77
                (13, true),  // 78
                (1, false),  // 79
                (2, false),  // 80
                (3, false),  // 81
                (4, false),  // 82
                (5, false),  // 83
                (6, true),   // 84
                (7, true),   // 85
                (8, true),   // 86
                (9, true),   // 87
                (10, true),  // 88
                (11, true),  // 89
                (12, true),  // 90
                (13, false), // 91
            ];
        }
    }
}
